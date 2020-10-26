using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    [CreateAssetMenu(fileName = "New Ship Stats", menuName = "C.W.I.S/Ship Stats (SO)")]
    public class ShipStats : ScriptableObject
    {
        public int shipHealth;
        public int[] fiveInchAmmo;
        public int[] bowMissileAmmo;
        public int[] bowCWISAmmo;
        public int[] chaftAmmo;
        public int[] sternCWISAmmo;
        public int[] sternMissileAmmo;
    }
}