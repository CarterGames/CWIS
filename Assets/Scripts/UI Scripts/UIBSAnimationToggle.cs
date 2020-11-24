using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Menu
{
    public class UIBSAnimationToggle : UIButtonSwitch
    {
        [Header("Animation Toggle Settings")]
        [SerializeField] private Animator[] anims;


        public override void Start()
        {
            base.Start();
            ToggleAnimation();
        }


        private void ToggleAnimation()
        {
            for (int i = 0; i < anims.Length; i++)
            {
                if (i.Equals(pos))
                {
                    anims[i].ResetTrigger("CloseCard");
                    anims[i].SetTrigger("OpenCard");
                }
                else
                {
                    anims[i].ResetTrigger("OpenCard");
                    anims[i].SetTrigger("CloseCard");
                }
            }
        }


        public override void UpdatePos(int value)
        {
            base.UpdatePos(value);
            ToggleAnimation();
        }
    }
}