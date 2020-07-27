using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class CrateUI : MonoBehaviour
    {
        public Text[] text;
        public SupplyCrate contents;


        private void Start()
        {
            text[0].text = "+ (" + contents.ammoStandard + ") CWIS Ammo";

            if (contents.missiles > 0)
            {
                text[1].text = "+ (" + contents.missiles + ") Missiles";
            }
            else
            {
                text[1].text = "";
            }

            if (contents.health > 0)
            {
                text[2].text = "+ (" + contents.health + ") Ship Health";
            }
            else
            {
                text[2].text = "";
            }

        }
    }
}