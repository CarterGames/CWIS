using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Menu
{
    public class UIBSColourChange : UIButtonSwitch
    {
        [Header("Colour Change Setting")]
        [SerializeField] private bool shouldChangeColour;
        [SerializeField] private Color defaultColour;
        [SerializeField] private Color hoverColour;


        public override void Start()
        {
            base.Start();
            ChangeColour();
        }


        private void ChangeColour()
        {
            if (shouldChangeColour)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (!i.Equals(pos))
                    {
                        buttons[i].GetComponent<Image>().color = defaultColour;
                    }
                    else
                    {
                        buttons[i].GetComponent<Image>().color = hoverColour;
                    }
                }
            }
        }


        public override void UpdatePos(int value)
        {
            base.UpdatePos(value);
            ChangeColour();
        }
    }
}