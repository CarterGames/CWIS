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
        private int[] shipStats;
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
            shipStats = new int[7];
            shipStats[0] = playerStats.shipHealth;

            // ship ammo
            shipStats[1] = playerStats.fiveInchAmmo;
            shipStats[2] = playerStats.bowMissileAmmo;
            shipStats[3] = playerStats.bowCWISAmmo;
            shipStats[4] = playerStats.chaftAmmo;
            shipStats[5] = playerStats.sternCWISAmmo;
            shipStats[6] = playerStats.sternMissileAmmo;
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
#if UNITY_STANDALONE
            ToggleCICWeapon();
#endif
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
            shipStats[0] = playerStats.shipHealth;
            shipStats[1] = playerStats.fiveInchAmmo;
            shipStats[2] = playerStats.bowMissileAmmo;
            shipStats[3] = playerStats.bowCWISAmmo;
            shipStats[4] = playerStats.chaftAmmo;
            shipStats[5] = playerStats.sternCWISAmmo;
            shipStats[6] = playerStats.sternMissileAmmo;
        }


        /// <summary>
        /// Reduces the ship health by the amount entered.
        /// (Default = 1)
        /// </summary>
        /// <param name="value">Int | amount of health to reduce.</param>
        public void ReduceShipHealth(int value = 1)
        {
            // Edit health value
            shipStats[0] -= value;

            // Update the health UI
            uITextElements[0].SetTextValue(shipStats[0].ToString());
        }


        /// <summary>
        /// Returns the amount of health the ship currently has.
        /// </summary>
        /// <returns>Int | The player ship health.</returns>
        public int GetShipHealth()
        {
            return shipStats[0];
        }


        /// <summary>
        /// Returns the ship stats int array
        /// </summary>
        /// <returns>Int Array | The ship stats.</returns>
        public int[] GetShipStats()
        {
            return shipStats;
        }
    }
}