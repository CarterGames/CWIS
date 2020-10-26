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
    public class CWIS : Turret
    {
        [Header("C.W.I.S Custom Settings")]
        [Range(0f, 10f)]
        [SerializeField] private float rotSpeed = 1.5f;

        private new void Start()
        {
            base.Start();
        }

        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, base.RotateToMousePos(), rotSpeed);

                // Shoot bullet...
                if (actions.Weapons.Fire.phase == InputActionPhase.Performed)
                    base.shouldFireCWIS = true;
                else
                    base.shouldFireCWIS = false;

                base.Update();
            }
        }
    }
}