using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public enum ShipWeapons { FiveInch, BowMissiles, BowCWIS, Chafts, SternCWIS, SternMissiles }

    public class CIC : MonoBehaviour
    {
        private Turret[] shipWeapons; 

        /// <summary>
        /// The active weapon 
        /// </summary>
        public ShipWeapons activeCICWeapon;


        private void Start()
        {
            shipWeapons = GetComponentsInChildren<Turret>();
        }


        /// <summary>
        /// Changes the active ship weapon
        /// </summary>
        /// <param name="weapon">ShipWeapon | Weapon to change to.</param>
        public void ChangeCICWeapon(int weapon)
        {
            activeCICWeapon = (ShipWeapons)weapon;
        }


        public void FireWeapon()
        {
            
        }
    }
}