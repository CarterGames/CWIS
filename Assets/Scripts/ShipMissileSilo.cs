using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Player
{
    public class ShipMissileSilo : Turret
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int lastSiloUsed = 0;

        private new void Start()
        {
            base.Start();
        }


        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                // Shoot missile if able to...
                if (actions.Weapons.Fire.phase == InputActionPhase.Performed)
                {
                    if (!shouldFireMissile && canShoot)
                    {
                        Debug.Log("fire");
                        base.shouldFireMissile = true;
                        FireMissile(spawnPoints[lastSiloUsed].transform, fireRate);
                        UpdateSiloNumber();
                    }
                }
                else
                    base.shouldFireMissile = false;
            }
        }


        private void UpdateSiloNumber()
        {
            if ((lastSiloUsed + 1).Equals(spawnPoints.Length))
                lastSiloUsed = 0;
            else
                lastSiloUsed++;
        }
    }
}