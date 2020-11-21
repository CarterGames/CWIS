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
    /// <summary>
    /// A collection of all the avalible weapons on the ship
    /// </summary>
    public enum ShipWeapons { FiveInch, BowMissiles, BowCWIS, Chafts, SternCWIS, SternMissiles, Null }

    public class CIC : MonoBehaviour
    {
        [SerializeField] internal Turret[] shipWeapons;

        private WaitForSeconds wait;
        private bool isCoR;
        internal Actions action;

        /// <summary>
        /// The active weapon 
        /// </summary>
        public ShipWeapons activeCICWeapon;


        private void Awake()
        {
            action = new Actions();
            action.Enable();
        }


        private void OnDisable()
        {
            action.Disable();
        }


        private void Start()
        {
            wait = new WaitForSeconds(.35f);
        }


        private void Update()
        {
            ToggleCICWeaponPC();
            ToggleCICWeaponController();
        }


        /// <summary>
        /// Changes the active ship weapon
        /// </summary>
        /// <param name="weapon">ShipWeapon | Weapon to change to.</param>
        public void ChangeCICWeapon(int weapon)
        {
            activeCICWeapon = (ShipWeapons)weapon;
        }


        /// <summary>
        /// Toggles the CIC active weapon based on the 1-6 input.
        /// </summary>
        private void ToggleCICWeaponPC()
        {
            if (action.CIC.ToggleWeaponOne.phase.Equals(InputActionPhase.Performed))
                activeCICWeapon = ShipWeapons.FiveInch;
            else if (action.CIC.ToggleWeaponTwo.phase.Equals(InputActionPhase.Performed))
                activeCICWeapon = ShipWeapons.BowMissiles;
            else if (action.CIC.ToggleWeaponThree.phase.Equals(InputActionPhase.Performed))
                activeCICWeapon = ShipWeapons.BowCWIS;
            else if (action.CIC.ToggleWeaponFour.phase.Equals(InputActionPhase.Performed))
                activeCICWeapon = ShipWeapons.Chafts;
            else if (action.CIC.ToggleWeaponFive.phase.Equals(InputActionPhase.Performed))
                activeCICWeapon = ShipWeapons.SternCWIS;
            else if (action.CIC.ToggleWeaponSix.phase.Equals(InputActionPhase.Performed))
                activeCICWeapon = ShipWeapons.SternMissiles;
        }


        /// <summary>
        /// Toggles the CIC active weapon based on triggers on a game controller.
        /// </summary>
        private void ToggleCICWeaponController()
        {
            if (!isCoR)
            {
                if (action.CIC.ToggleWesponUD.ReadValue<float>() > .1f && action.CIC.ToggleWesponUD.phase.Equals(InputActionPhase.Performed))
                {
                    if (activeCICWeapon + 1 > ShipWeapons.SternMissiles)
                    {
                        activeCICWeapon = 0;
                        StartCoroutine(ToggleCooldown());
                    }
                    else
                    {
                        activeCICWeapon++;
                        StartCoroutine(ToggleCooldown());
                    }
                }
                else if (action.CIC.ToggleWesponUD.ReadValue<float>() < -.1f)
                {
                    if (((int)activeCICWeapon - 1).Equals(-1))
                    {
                        activeCICWeapon = ShipWeapons.SternMissiles;
                        StartCoroutine(ToggleCooldown());
                    }
                    else
                    {
                        activeCICWeapon--;
                        StartCoroutine(ToggleCooldown());
                    }
                }
            }
        }



        private IEnumerator ToggleCooldown()
        {
            isCoR = true;
            yield return wait;
            isCoR = false;
        }


        /// <summary>
        /// Fires the active weapon.
        /// </summary>
        public void FireWeapon()
        {
            
        }
    }
}