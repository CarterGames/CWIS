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
        private CIC _cic;
        private Actions action;
        public int shipHealth;

        private void OnEnable()
        {
            action = new Actions();
            action.Enable();
        }


        private void Start()
        {
            _cic = GetComponentInChildren<CIC>();
        }


        private void Update()
        {
            ToggleCICWeapon();
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
    }
}