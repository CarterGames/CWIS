using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class EditSlider : MonoBehaviour
    {
        [SerializeField] private CWIS_Turret CWIS_Turret;

        private Slider slider;

        public bool isCwis;


        private void Start()
        {
            slider = GetComponent<Slider>();
        }


        private void Update()
        {
            if (isCwis)
            {
                slider.value = CWIS_Turret.timeHeldDown;
            }
        }
    }
}