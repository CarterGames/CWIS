using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class FiveInch : Turret
    {
        [Header("5-Inch Custom Settings")]
        [Range(0f, 5f)]
        [SerializeField] private float rotSpeed = .3f;

        private ParticleSystem barrelParticles;


        private new void Start()
        {
            base.Start();

            barrelParticles = transform.GetChild(2).GetComponentInChildren<ParticleSystem>();
        }


        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, base.RotateToMousePos(), rotSpeed);

                // Shoot bullet...
                if (canShoot)
                {
                    if (base.actions.Weapons.Fire.phase.Equals(InputActionPhase.Performed))
                    {
                        barrelParticles.Play();
                        base.shouldFireFiveInch = true;
                    }
                }
                else
                    base.shouldFireFiveInch = false;


                base.Update();
            }
        }
    }
}