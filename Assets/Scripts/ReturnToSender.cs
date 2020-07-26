using CarterGames.Utilities;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class ReturnToSender : MonoBehaviour, IObjectPool<GameObject>
    {
        [SerializeField] private CWIS_Controller.Controller thisturret;
        [SerializeField] private CWIS_Controller control;
        [SerializeField] private GameObject missilePrafab;
        [SerializeField] private MissileSpawer ms;

        private ParticleSystem missileFire;
        private bool isCoR;

        public int playerMissiles;

        public int objectLimit { get; set; }
        public List<GameObject> objectPool { get; set; }


        private void Start()
        {
            objectLimit = playerMissiles;
            objectPool = new List<GameObject>();

            for (int i = 0; i < objectLimit; i++)
            {
                GameObject _go = Instantiate(missilePrafab);
                _go.SetActive(false);
                objectPool.Add(_go);
            }

            missileFire = GetComponent<ParticleSystem>();
        }


        private void Update()
        {
            if (control.activeTurret == thisturret && Input.GetMouseButton(0))
            {
                ShootMissileBack();
            }
        }


        public void ShootMissileBack()
        {
            if (!isCoR)
            {
                StartCoroutine(ShootMissileCo());
            }
        }


        private IEnumerator ShootMissileCo()
        {
            isCoR = true;

            if (ms.activeMissiles.Count > 0)
            {
                for (int i = 0; i < objectLimit; i++)
                {
                    if (!objectPool[i].activeInHierarchy)
                    {
                        missileFire.Play();
                        objectPool[i].transform.position = new Vector3(transform.position.x, 4, transform.position.z);
                        objectPool[i].GetComponent<Homing>().targetPos = ms.activeMissiles[ms.activeMissiles.Count - 1].transform.position;
                        objectPool[i].SetActive(true);
                        break;
                    }
                }
            }

            yield return new WaitForSeconds(.5f);
            isCoR = false;
        }
    }
}