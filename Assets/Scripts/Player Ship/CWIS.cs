using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class CWIS : Turret
    {
        [Header("C.W.I.S Custom Settings")]
        [Range(0f, 10f)]
        [SerializeField] private float rotSpeed = 1.5f;
        [SerializeField] private Slider tempSlider;


        private new void Start()
        {
            base.Start();

            if (tempSlider)
                tempSlider.maxValue = base.maxFiringTime;
        }


        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, base.RotateToMousePos(), rotSpeed);

                // Shoot bullet...
                if (actions.Weapons.Fire.phase.Equals(InputActionPhase.Performed))
                    base.shouldFireCWIS = true;
                else
                    base.shouldFireCWIS = false;

                base.Update();

                if (!tempSlider.value.Equals(base.firingTimer))
                {
                    tempSlider.value = base.firingTimer;
                }
            }
        }
    }
}