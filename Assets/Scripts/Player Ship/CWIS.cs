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
        private new void Start()
        {
            base.Start();
        }

        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                transform.localRotation = base.RotateToMousePos();

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