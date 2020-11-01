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
        [SerializeField] private Ship ship;
        [SerializeField] private MissileTargeting[] missileTargeting;
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
                if (!pauseUI.enabled)
                {
                    pauseUI.enabled = true;
                    ship.action.Disable();
                    ship.GetComponentInChildren<CIC>().action.Disable();
                    missileTargeting[0].DisableTargeting();
                    missileTargeting[1].DisableTargeting();
                    Time.timeScale = 0;
                }
            }
        }
    }
}