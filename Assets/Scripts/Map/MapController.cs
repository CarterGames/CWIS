using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Map
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private Canvas mapPanel;
        [SerializeField] private PauseGameController pause;
        [SerializeField] private bool canTab = true;
        private Actions action;
        private bool isMapOpen = false;

        private void OnEnable()
        {
            action = new Actions();
            action.Enable();
        }

        private void OnDisable()
        {
            action.Disable();
        }


        private void Start()
        {
            mapPanel.enabled = false; 
            isMapOpen = false;
        }


        private void Update()
        {
            if (action.Menu.Map.ReadValue<float>() > .3f)
            {
                canTab = true;
            }

            if (!isMapOpen && canTab)
            {
                mapPanel.enabled = true;
                isMapOpen = true;
                pause.PauseGame(false);
            }
            else if (isMapOpen && !canTab)
            {
                mapPanel.enabled = false;
                isMapOpen = false;
                pause.ResumeGame();
            }
        }
    }
}