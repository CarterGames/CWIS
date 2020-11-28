using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Menu
{
    public class RootMenuController : MonoBehaviour
    {
        [SerializeField] internal bool navigateRoot;
        [SerializeField] internal bool navigatePlayMenu;
        [SerializeField] internal bool navigateSettingsMenu;
        [SerializeField] private UIButtonSwitch rootOptions;
        [SerializeField] private UIButtonSwitch playOptions;
        [SerializeField] private UIButtonSwitch settingsOptions;


        private void Start()
        {
            navigateRoot = true;
            navigatePlayMenu = false;
            navigateSettingsMenu = false;
        }


        private void Update()
        {
            MenuSetup();   
        }


        private void MenuSetup()
        {
            if (navigateRoot)
                rootOptions.enabled = true;
            else
                rootOptions.enabled = false;


            if (navigatePlayMenu)
                playOptions.enabled = true;
            else
                playOptions.enabled = false;


            if (navigateSettingsMenu)
                settingsOptions.enabled = true;
            else
                settingsOptions.enabled = false;
        }


        public void OpenPlayMenu()
        {
            navigatePlayMenu = true;
            navigateRoot = false;
        }


        public void OpenSettingsMenu()
        {
            navigateSettingsMenu = true;
            navigateRoot = false;
        }


        public void OpenRoot()
        {
            navigateRoot = true;
            navigatePlayMenu = false;
            navigateSettingsMenu = false;
        }
    }
}