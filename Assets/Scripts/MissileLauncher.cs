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
    public class MissileLauncher : Turret
    {
        [SerializeField] private GameObject[] missileSpawnLocations;
        [SerializeField] private int lastSiloUsed = 0;

        private new void Start()
        {
            base.Start();
        }


        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                // Shoot bullet...
                if (actions.Weapons.Fire.phase == InputActionPhase.Performed)
                {
                    if (!shouldFireMissile && canShoot)
                    {
                        Debug.Log("fire");
                        base.shouldFireMissile = true;
                        FireMissile(missileSpawnLocations[lastSiloUsed].transform, fireRate);
                        UpdateSiloNumber();
                    }
                }
                else
                    base.shouldFireMissile = false;
            }
        }


        private void UpdateSiloNumber()
        {
            if ((lastSiloUsed + 1).Equals(missileSpawnLocations.Length))
                lastSiloUsed = 0;
            else
                lastSiloUsed++;
        }
    }
}