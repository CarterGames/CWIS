using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class EditRank : MonoBehaviour
    {
        [SerializeField] private GameObject[] rankImages;

        [SerializeField] private GameManager.Ranks lastRank = GameManager.Ranks.None;

        public CWIS_Turret turret;


        private void Update()
        {
            if (turret.thisRank != lastRank)
            {
                UpdateRankDisplay();
            }
        }


        private void UpdateRankDisplay()
        {
            if (lastRank != GameManager.Ranks.None)
            {
                rankImages[(int)turret.thisRank - 2].SetActive(false);
            }

            rankImages[(int)turret.thisRank - 1].SetActive(true);
            lastRank = turret.thisRank;
        }
    }
}