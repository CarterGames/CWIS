using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public enum Ranks { None, Chev1, Chev2, Chev3, Star1, Star2, Star3 }

    public class Rankup : MonoBehaviour
    {
        private Ranks currentRank;


        public void SetRank(Ranks value)
        {
            currentRank = value;
        }


        public Ranks GetRank()
        {
            return currentRank;
        }
    }
}