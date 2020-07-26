using System.Collections.Generic;
using UnityEngine;
using CarterGames.Utilities;
using System.Collections;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class MissileSpawer : MonoBehaviour, IObjectPool<GameObject>
    {
        [SerializeField] private int missilesWanted;
        [SerializeField] private float minDistance;

        private bool isCoR;
        private ShipController ship;

        public GameObject missilePrefab;

        public int objectLimit { get; set; }
        public List<GameObject> objectPool { get; set; }

        public List<GameObject> activeMissiles;

        public float minWait;
        public float maxWait;
        

        private void Start()
        {
            objectLimit = missilesWanted;

            objectPool = new List<GameObject>();

            for (int i = 0; i < objectLimit; i++)
            {
                GameObject _go = Instantiate(missilePrefab);
                _go.SetActive(false);
                objectPool.Add(_go);
            }

            ship = FindObjectOfType<ShipController>();
        }


        private void Update()
        {
            if (!isCoR)
            {
                StartCoroutine(FireMissileCo(Random.Range(minWait, maxWait)));
            }


            switch (ship.gameTimer)
            {
                case 5:
                    minWait = 7f;
                    maxWait = 10f;
                    break;
                case 10:
                    minWait = 6f;
                    maxWait = 9f;
                    break;
                case 20:
                    minWait = 6f;
                    maxWait = 8.5f;
                    break;
                case 35:
                    minWait = 5f;
                    maxWait = 7f;
                    break;
                case 50:
                    minWait = 4f;
                    maxWait = 7f;
                    break;
                case 75:
                    minWait = 3f;
                    maxWait = 7f;
                    break;
                case 100:
                    minWait = 2f;
                    maxWait = 5f;
                    break;
                case 125:
                    minWait = 2f;
                    maxWait = 4f;
                    break;
                case 150:
                    minWait = 1f;
                    maxWait = 4f;
                    break;
                case 200:
                    minWait = 1f;
                    maxWait = 3f;
                    break;
                default:
                    break;
            }
        }


        private IEnumerator FireMissileCo(float delay)
        {
            isCoR = true;

            for (int i = 0; i < objectLimit; i++)
            {
                if (!objectPool[i].activeInHierarchy)
                {
                    Vector3 newPos = ChooseSpawnLocation();
                    objectPool[i].transform.position = new Vector3(newPos.x, 4, newPos.z);
                    Vector3 dir = new Vector3(ship.mast.transform.position.x - objectPool[i].transform.position.x, 0, ship.mast.transform.position.z - objectPool[i].transform.position.z);
                    objectPool[i].GetComponent<Rigidbody>().velocity = (dir).normalized * 100;
                    objectPool[i].transform.LookAt(dir);
                    objectPool[i].SetActive(true);
                    activeMissiles.Add(objectPool[i]);
                    break;
                }
            }

            yield return new WaitForSeconds(delay);
            isCoR = false;
        }


        private Vector3 ChooseSpawnLocation()
        {
            return Random.onUnitSphere * (Random.Range(minDistance, 1500));
        }
    }
}