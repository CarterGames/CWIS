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
        public enum sliderType { Cw, Shaft, }; 

        [SerializeField] private CWIS_Turret CWIS_Turret;
        [SerializeField] private Shaft_Ability shaft;

        private Slider slider;

        public sliderType thistype;



        private void Start()
        {
            slider = GetComponent<Slider>();
        }


        private void Update()
        {
            switch (thistype)
            {
                case sliderType.Cw:

                    slider.value = CWIS_Turret.timeHeldDown;
                    
                    if (slider.maxValue != CWIS_Turret.maxTime)
                    {
                        slider.maxValue = CWIS_Turret.maxTime;
                    }

                    break;
                case sliderType.Shaft:

                    GetComponentsInChildren<Image>()[1].fillAmount = (Mathf.InverseLerp(0,1, shaft.cooldown));

                    break;
                default:
                    break;
            }
        }
    }
}