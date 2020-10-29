using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class RankupController : MonoBehaviour
    {
        [SerializeField] private Ranks[] weaponRanks = default;
        [SerializeField] private int[] usesKills = default;


        /// <summary>
        /// Sets the uses/kills value for use elsewhere. 
        /// </summary>
        /// <param name="valueToChange">element tp change</param>
        /// <param name="value">value to enter.</param>
        public void SetUsesKill(int valueToChange, int value)
        {
            usesKills[valueToChange] = value;
        }
    }
}