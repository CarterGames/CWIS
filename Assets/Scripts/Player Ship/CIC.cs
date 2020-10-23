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
    public enum ShipWeapons { FiveInch, BowCWIS, BowMissiles, Chafts, SternCWIS, SternMissiles }

    public class CIC : MonoBehaviour
    {
        /// <summary>
        /// The active weapon 
        /// </summary>
        public ShipWeapons activeCICWeapon;
    }
}