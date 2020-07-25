using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class GameManager : MonoBehaviour
    {
        private int[] rankUpRequirements;
        private int cw1BestRank = 0;
        private int cw2BestRank = 0;

        public enum Ranks { None, Chev1, Chev2, Chev3, Star1, Star2, Star3 }
       

        public int cwis1Hits = 0;
        public int cwis2Hits = 0;

        public CWIS_Turret cwis1Turret;
        public CWIS_Turret cwis2Turret;


        private void Start()
        {
            rankUpRequirements = new int[6]
            {
            Random.Range(3, 7),
            Random.Range(8, 14),
            Random.Range(20, 25),
            Random.Range(30, 45),
            Random.Range(50, 65),
            Random.Range(75, 100)
            };
        }


        private void Update()
        {
            CheckCWForRankup(cwis1Turret, cwis1Hits, cw1BestRank);
            CheckCWForRankup(cwis2Turret, cwis2Hits, cw2BestRank);
        }


        public Ranks Rankup(Ranks currentRank)
        {
            switch (currentRank)
            {
                case Ranks.None:
                    return Ranks.Chev1;
                case Ranks.Chev1:
                    return Ranks.Chev2;
                case Ranks.Chev2:
                    return Ranks.Chev3;
                case Ranks.Chev3:
                    return Ranks.Star1;
                case Ranks.Star1:
                    return Ranks.Star2;
                case Ranks.Star2:
                    return Ranks.Star3;
                case Ranks.Star3:
                    return Ranks.Star3;
                default:
                    return Ranks.None;
            }
        }

        public void IncrementCWIS1HitCount()
        {
            cwis1Hits++;
        }

        public void IncrementCWIS2HitCount()
        {
            cwis2Hits++;
        }

        private void CheckCWForRankup(CWIS_Turret turret, int hits, int bestRank)
        {
            if (hits >= rankUpRequirements[0])
            {
                turret.thisRank = Rankup(Ranks.None);

                if (bestRank == 1)
                {
                    bestRank++;
                }
            }

            if (hits >= rankUpRequirements[1])
            {
                turret.thisRank = Rankup(Ranks.Chev1);

                if (bestRank == 2)
                {
                    bestRank++;
                }
            }

            if (hits >= rankUpRequirements[2])
            {
                turret.thisRank = Rankup(Ranks.Chev2);

                if (bestRank == 3)
                {
                    bestRank++;
                }
            }

            if (hits >= rankUpRequirements[3])
            {
                turret.thisRank = Rankup(Ranks.Chev3);

                if (bestRank == 4)
                {
                    bestRank++;
                }
            }

            if (hits >= rankUpRequirements[4])
            {
                turret.thisRank = Rankup(Ranks.Star1);

                if (bestRank == 5)
                {
                    bestRank++;
                }
            }

            if (hits >= rankUpRequirements[5])
            {
                turret.thisRank = Rankup(Ranks.Star2);

                if (bestRank == 6)
                {
                    bestRank++;
                }
            }
        }


        private void OpenRankupUI(CWIS_Turret whichTurret)
        {

        }
    }
}