using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class EditText : MonoBehaviour
    {
        private Text text;
        private CWIS_Controller controller;
        private ShipController ship;

        public bool isCwis1;
        public bool isCwis2;
        public bool isShipHealth;


        private void Start()
        {
            text = GetComponent<Text>();
            controller = FindObjectOfType<CWIS_Controller>();
            ship = FindObjectOfType<ShipController>();
        }

        private void Update()
        {
            if ((isCwis1) && (!isCwis2))
            {
                text.text = controller.GetAmmoCount_CW1();
            }
            else if ((!isCwis1) && (isCwis2))
            {
                text.text = controller.GetAmmoCount_CW2();
            }
            else if (isShipHealth)
            {
                text.text = ship.shipHealth.ToString();
            }
        }
    }
}