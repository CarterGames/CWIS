using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Menu
{
    public class UIBSScalingEffect : UIButtonSwitch
    {
        [Header("Scaling Settings")]
        [SerializeField] private bool shouldScaleOnHover;
        [SerializeField] private float scaleFactor;


        public override void Start()
        {
            base.Start();
            HoverButton();
        }


        /// <summary>
        /// Controls the hover factor.
        /// </summary>
        private void HoverButton()
        {
            if (shouldScaleOnHover)
            {
                for (int i = 0; i < base.buttons.Length; i++)
                {
                    if (!i.Equals(pos))
                    {
                        buttons[i].transform.localScale = Vector3.one;
                    }
                    else
                    {
                        buttons[i].transform.localScale = Vector3.one * scaleFactor;
                    }
                }
            }
        }


        public override void UpdatePos(int value)
        {
            base.UpdatePos(value);
            HoverButton();
        }
    }
}