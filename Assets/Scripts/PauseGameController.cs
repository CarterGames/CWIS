using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class PauseGameController : MonoBehaviour
    {
        [SerializeField] private Canvas pauseUI = default;
        private Actions actions;


        private void Awake()
        {
            actions = new Actions();
            actions.Enable();
        }

        private void OnDisable()
        {
            actions.Disable();
        }

        private void Update()
        {
            if (actions.Menu.Pause.phase.Equals(InputActionPhase.Performed))
            {
                pauseUI.enabled = true;
                Time.timeScale = 0;
            }
        }
    }
}