using System.Collections;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class ShipController : MonoBehaviour
    {
        public int shipHealth = 5;
        public int shipMissiles = 0;
        public GameObject mast;

        private int timesHit = 0;
        private bool isCoR;
        private GameManager gm;
        private MissileSpawer ms;

        private float gameTimer;
        private bool timerRunning;
        private bool shipDead;

        private void Start()
        {
            isCoR = false;
            gm = FindObjectOfType<GameManager>();
            ms = FindObjectOfType<MissileSpawer>();
            timerRunning = true;
            gameTimer = 0;
        }


        private void Update()
        {
            if (gm.isGameRunning)
            {
                if (timerRunning)
                {
                    gameTimer += Time.deltaTime;

                    if (gameTimer % 5 == 1)
                    {
                        gm.AddToScore(25);
                    }
                }
            }

            if (shipDead)
            {
                if (gm.gameoverUI.alpha != 1)
                {
                    gm.gameoverUI.alpha += 2 * Time.unscaledDeltaTime;
                    gm.gameoverUI.interactable = true;
                    gm.gameoverUI.blocksRaycasts = true;
                }
            }
        }


        public void DamageShip(int damage)
        {
            timesHit++;
            shipHealth -= damage;
            gm.ReduceScore((1 * timesHit) * 150);

            if (shipHealth == 0)
            {
                shipDead = true;

                if (!isCoR)
                {
                    StartCoroutine(GameOver());
                }
            }
        }


        private IEnumerator GameOver()
        {
            isCoR = true;
            yield return new WaitForSecondsRealtime(.1f);

            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
                gm.cwis1Turret.enabled = false;
                gm.cwis2Turret.enabled = false;
                gm.isGameRunning = false;

                for (int i = 0; i < ms.activeMissiles.Count; i++)
                {
                    ms.activeMissiles[i].SetActive(false);
                }

                ms.enabled = false;
            }
        }
    }
}