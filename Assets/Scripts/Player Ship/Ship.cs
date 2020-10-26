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
    public class Ship : MonoBehaviour
    {
        [SerializeField] private UITextElement[] uITextElements;

        private CIC _cic;
        private Actions action;

        // Ship stats 
        private int shipHealth;
        private int[,] shipStats;
        public ShipStats playerStats;


        private void OnEnable()
        {
            action = new Actions();
            action.Enable();
        }


        private void OnDisable()
        {
            action.Disable();
        }


        private void Awake()
        {
            // ship health setup
            shipStats = new int[6,2];

            // ship ammo
            shipStats[0,0] = playerStats.fiveInchAmmo[0];
            shipStats[0,1] = playerStats.fiveInchAmmo[1];
            shipStats[1,0] = playerStats.bowMissileAmmo[0];
            shipStats[1,1] = playerStats.bowMissileAmmo[1];
            shipStats[2,0] = playerStats.bowCWISAmmo[0];
            shipStats[2,1] = playerStats.bowCWISAmmo[1];
            shipStats[3,0] = playerStats.chaftAmmo[0];
            shipStats[3,1] = playerStats.chaftAmmo[1];
            shipStats[4,0] = playerStats.sternCWISAmmo[0];
            shipStats[4,1] = playerStats.sternCWISAmmo[1];
            shipStats[5,0] = playerStats.sternMissileAmmo[0];
            shipStats[5,1] = playerStats.sternMissileAmmo[1];
        }


        private void Start()
        {
            _cic = GetComponentInChildren<CIC>();

#if UNITY_ANDROID
            Cursor.visible = true;
#else
            Cursor.visible = false;
#endif
        }


        private void Update()
        {
//#if UNITY_STANDALONE
            ToggleCICWeapon();
//#endif
        }


        /// <summary>
        /// Toggles the CIC active weapon based on the 1-6 input.
        /// </summary>
        private void ToggleCICWeapon()
        {
            if (action.CIC.ToggleWeaponOne.phase.Equals(InputActionPhase.Performed))
                _cic.activeCICWeapon = ShipWeapons.FiveInch;
            else if (action.CIC.ToggleWeaponTwo.phase.Equals(InputActionPhase.Performed))
                _cic.activeCICWeapon = ShipWeapons.BowMissiles;
            else if (action.CIC.ToggleWeaponThree.phase.Equals(InputActionPhase.Performed))
                _cic.activeCICWeapon = ShipWeapons.BowCWIS;
            else if (action.CIC.ToggleWeaponFour.phase.Equals(InputActionPhase.Performed))
                _cic.activeCICWeapon = ShipWeapons.Chafts;
            else if (action.CIC.ToggleWeaponFive.phase.Equals(InputActionPhase.Performed))
                _cic.activeCICWeapon = ShipWeapons.SternCWIS;
            else if (action.CIC.ToggleWeaponSix.phase.Equals(InputActionPhase.Performed))
                _cic.activeCICWeapon = ShipWeapons.SternMissiles;
        }


        /// <summary>
        /// Reset the ship stats to their default values for a new round of the game.
        /// </summary>
        public void ResetShip()
        {
            shipStats[0, 0] = playerStats.fiveInchAmmo[0];
            shipStats[0, 1] = playerStats.fiveInchAmmo[1];
            shipStats[1, 0] = playerStats.bowMissileAmmo[0];
            shipStats[1, 1] = playerStats.bowMissileAmmo[1];
            shipStats[2, 0] = playerStats.bowCWISAmmo[0];
            shipStats[2, 1] = playerStats.bowCWISAmmo[1];
            shipStats[3, 0] = playerStats.chaftAmmo[0];
            shipStats[3, 1] = playerStats.chaftAmmo[1];
            shipStats[4, 0] = playerStats.sternCWISAmmo[0];
            shipStats[4, 1] = playerStats.sternCWISAmmo[1];
            shipStats[5, 0] = playerStats.sternMissileAmmo[0];
            shipStats[5, 1] = playerStats.sternMissileAmmo[1];
        }


        /// <summary>
        /// Reduces the ship health by the amount entered.
        /// (Default = 1)
        /// </summary>
        /// <param name="value">Int | amount of health to reduce.</param>
        public void ReduceShipHealth(int value = 1)
        {
            // Edit health value
            shipHealth -= value;

            // Update the health UI
            uITextElements[0].SetTextValue(shipHealth.ToString());
        }


        /// <summary>
        /// Returns the amount of health the ship currently has.
        /// </summary>
        /// <returns>Int | The player ship health.</returns>
        public int GetShipHealth()
        {
            return shipHealth;
        }


        /// <summary>
        /// Returns the ship stats int array.
        /// </summary>
        /// <returns>Int Array | The ship stats.</returns>
        public int[,] GetShipStats()
        {
            return shipStats;
        }


        /// <summary>
        /// Retruns the max and default ammo for the ship weapon.
        /// </summary>
        /// <param name="Weapon">Weapon to check</param>
        /// <returns>Int[] with the max followed by the default ammo.</returns>
        public int[] GetWeaponAmmo(int Weapon)
        {
            return new int[2] { shipStats[Weapon, 0], shipStats[Weapon, 1] };
        }
    }
}