using System.Collections;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(ParticleSystem))]
    public class Shaft_Ability : MonoBehaviour
    {
        private bool isCoR = false;
        private ParticleSystem ps;
        private CapsuleCollider cc;
        [SerializeField] private CWIS_Controller.Controller thisControl;
        private CWIS_Controller control;

        public float duration = 1.5f;
        public float size = 1;

        public bool useAbility = false;
        public bool canUseAbilty = true;

        internal float cooldown = 0;
        public float cooldownStart = 10;



        private void Start()
        {
            ps = GetComponent<ParticleSystem>();
            cc = GetComponent<CapsuleCollider>();
            control = FindObjectOfType<CWIS_Controller>();
        }


        private void Update()
        {
            if ((Input.GetMouseButton(0)) && (control.activeTurret == thisControl) && canUseAbilty)
            {
                useAbility = true;
            }

            if (useAbility && !isCoR && canUseAbilty)
            {
                StartCoroutine(DelayShafts());
            }

            if (!canUseAbilty)
            {
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime / 2;
                }
                else
                {
                    canUseAbilty = true;
                }
            }
        }


        private IEnumerator DelayShafts()
        {
            canUseAbilty = false;
            isCoR = true;
            cc.enabled = true;
            var main = ps.main;
            main.duration = duration;
            ps.Play();
            yield return new WaitForSeconds(duration);
            ps.Stop();
            cc.enabled = false;
            cooldown = cooldownStart;
            isCoR = false;
        }
    }
}