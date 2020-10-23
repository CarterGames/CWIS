using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class Chaft : Turret
    {
        [SerializeField] private ParticleSystem[] particles;
        [SerializeField] private bool canUseChaft;
        private WaitForSeconds wait;
        private float waitTime = 15f;

        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private new void Start()
        {
            wait = new WaitForSeconds(waitTime);
            particles = GetComponentsInChildren<ParticleSystem>();
            canUseChaft = true;

            base.Start();
        }


        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                if (canUseChaft)
                {
                    if (actions.Weapons.Fire.phase == InputActionPhase.Performed)
                    {
                        for (int i = 0; i < particles.Length; i++)
                        {
                            particles[i].Play();
                        }
                    }

                    StartCoroutine(Cooldown());
                }

                base.Update();
            }
        }


        public void ChangeWaitTime(float value)
        {
            waitTime = value;
            wait = new WaitForSeconds(waitTime);
        }


        private IEnumerator Cooldown()
        {
            canUseChaft = false;
            yield return wait;
            canUseChaft = true;
        }
    }
}