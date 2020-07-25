using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class RankupUI : MonoBehaviour
    {
        public CWIS_Turret turret;

        private int[] openOptions;

        [SerializeField] private GameObject[] rateButtons;
        [SerializeField] private GameObject[] ammoButtons;
        [SerializeField] private GameObject[] coolButtons;

        private void OnEnable()
        {
            openOptions = new int[3] { turret.rateOfFire, turret.ammoCap, turret.coolerEff };
        }


        private void Start()
        {

        }



        private void SortLocks()
        {
            for (int i = 0; i < rateButtons.Length; i++)
            {
                if (i > (openOptions[0] + 1))
                {
                    // lock option
                    rateButtons[i].GetComponent<Button>().interactable = false;
                    rateButtons[i].GetComponentInChildren<Image>().enabled = true;
                }
            }
        }
    }
}