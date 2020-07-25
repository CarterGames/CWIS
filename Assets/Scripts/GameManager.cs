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
        [SerializeField] private int cw1BestRank = 0;
        [SerializeField] private int cw2BestRank = 0;
        [SerializeField] internal bool openRankupUI;
        [SerializeField] private CanvasGroup rankui;

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
            CheckCWForRankup(cwis1Turret, cwis1Hits, 1);
            CheckCWForRankup(cwis2Turret, cwis2Hits, 2);


            if (openRankupUI && rankui.alpha != 1)
            {
                rankui.alpha += Time.unscaledDeltaTime * 3;
                Time.timeScale = 0;

                if (!rankui.blocksRaycasts)
                {
                    rankui.blocksRaycasts = true;
                    rankui.interactable = true;
                }
            }
            else if (!openRankupUI && rankui.alpha != 0)
            {
                rankui.alpha -= Time.unscaledDeltaTime * 3;
                Time.timeScale = 1;

                if (rankui.blocksRaycasts)
                {
                    rankui.blocksRaycasts = false;
                    rankui.interactable = false;
                }
            }
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

                switch (bestRank)
                {
                    case 1:
                        if (cw1BestRank == 0)
                        {
                            cw1BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    case 2:
                        if (cw2BestRank == 0)
                        {
                            cw2BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (hits >= rankUpRequirements[1])
            {
                turret.thisRank = Rankup(Ranks.Chev1);

                switch (bestRank)
                {
                    case 1:
                        if (cw1BestRank == 1)
                        {
                            cw1BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    case 2:
                        if (cw2BestRank == 1)
                        {
                            cw2BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (hits >= rankUpRequirements[2])
            {
                turret.thisRank = Rankup(Ranks.Chev2);

                switch (bestRank)
                {
                    case 1:
                        if (cw1BestRank == 2)
                        {
                            cw1BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    case 2:
                        if (cw2BestRank == 2)
                        {
                            cw2BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (hits >= rankUpRequirements[3])
            {
                turret.thisRank = Rankup(Ranks.Chev3);

                switch (bestRank)
                {
                    case 1:
                        if (cw1BestRank == 3)
                        {
                            cw1BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    case 2:
                        if (cw2BestRank == 3)
                        {
                            cw2BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (hits >= rankUpRequirements[4])
            {
                turret.thisRank = Rankup(Ranks.Star1);

                switch (bestRank)
                {
                    case 1:
                        if (cw1BestRank == 4)
                        {
                            cw1BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    case 2:
                        if (cw2BestRank == 4)
                        {
                            cw2BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (hits >= rankUpRequirements[5])
            {
                turret.thisRank = Rankup(Ranks.Star2);

                switch (bestRank)
                {
                    case 1:
                        if (cw1BestRank == 5)
                        {
                            cw1BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    case 2:
                        if (cw2BestRank == 5)
                        {
                            cw2BestRank++;
                            OpenRankupUI(turret);
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        private void OpenRankupUI(CWIS_Turret whichTurret)
        {
            rankui.gameObject.GetComponent<RankupUI>().turret = whichTurret;
            rankui.gameObject.GetComponent<RankupUI>().rate = whichTurret.rateOfFire;
            rankui.gameObject.GetComponent<RankupUI>().ammo = whichTurret.ammoCap;
            rankui.gameObject.GetComponent<RankupUI>().cool = whichTurret.coolerEff;
            rankui.gameObject.GetComponent<RankupUI>().Setup();
            openRankupUI = true;
        }
    }
}