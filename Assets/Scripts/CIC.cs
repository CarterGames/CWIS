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
    public enum ShipWeapons { FiveInch, BowCWIS, BowMissiles, Chafts, SternCWIS, SternMissiles }

    public class CIC : MonoBehaviour
    {
        public ShipWeapons activeCICWeapon;
    }
}