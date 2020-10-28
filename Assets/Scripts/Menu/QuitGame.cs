using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Menu
{
    public class QuitGame : MonoBehaviour
    {
        [SerializeField] private GameObject quitPanel;

        private bool isPanelOpen;


        public void OpenPanel()
        {
            quitPanel.SetActive(true);
        }


        public void ClosePanel()
        {
            quitPanel.SetActive(false);
        }
    }
}