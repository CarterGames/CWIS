using System.Collections;
using System.Collections.Generic;
using CarterGames.Utilities;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class ShipController : MonoBehaviour
    {
        public int shipHealth = 5;
        public int shipMissiles = 0;
        public GameObject mast;

        public void DamageShip(int damage)
        {
            shipHealth -= damage;
        }
    }
}