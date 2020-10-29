using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Menu
{
    public class PanelController : MonoBehaviour
    {
        [SerializeField] private Canvas panel = default;

        private bool isPanelOpen;


        public void OpenPanel()
        {
            panel.enabled = true;
        }


        public void ClosePanel()
        {
            panel.enabled = false;
        }
    }
}