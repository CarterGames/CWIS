using System.Collections;
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
        private CIC cic;
        private bool isOpen;
        private WaitForSeconds wait;


        private void Awake()
        {
            actions = new Actions();
            actions.Enable();

            pauseUI = GetComponent<Canvas>();
            wait = new WaitForSeconds(10f);
            cic = ship.GetComponentInChildren<CIC>();
        }

        private void OnDisable()
        {
            actions.Disable();
            StopAllCoroutines();
        }

        private void Update()
        {
            if (!isOpen && actions.Menu.Pause.phase.Equals(InputActionPhase.Performed))
            {
                if (!pauseUI.enabled)
                {
                    PauseGame();
                }
            }
            else if (isOpen && actions.Menu.Back.phase.Equals(InputActionPhase.Performed))
            {
                if (pauseUI.enabled)
                {
                    ResumeGame();
                }
            }
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public void PauseGame(bool showPausePanel = true)
        {
            if (showPausePanel)
                pauseUI.enabled = true;

            ship.action.Disable();
            ship.GetComponentInChildren<CIC>().action.Disable();
            missileTargeting[0].DisableTargeting();
            missileTargeting[1].DisableTargeting();
            Time.timeScale = 0;
            DisableWeapons();
            isOpen = true;
        }


        /// <summary>
        /// Resumes the game and closes the pause menu UI panel.
        /// </summary>
        public void ResumeGame()
        {
            pauseUI.enabled = false;
            ship.action.Enable();
            ship.GetComponentInChildren<CIC>().action.Enable();
            missileTargeting[0].EnableTargeting();
            missileTargeting[1].EnableTargeting();
            Time.timeScale = 1;
            isOpen = false;
            EnableWeapons();
            //StartCoroutine(EnableWithDelay());
        }


        private void DisableWeapons()
        {
            for (int i = 0; i < cic.shipWeapons.Length; i++)
            {
                cic.shipWeapons[i].actions.Disable();
            }
        }


        private void EnableWeapons()
        {
            for (int i = 0; i < cic.shipWeapons.Length; i++)
            {
                cic.shipWeapons[i].actions.Enable();
            }
        }


        private IEnumerator EnableWithDelay()
        {
            yield return wait;
            EnableWeapons();
        }
    }
}