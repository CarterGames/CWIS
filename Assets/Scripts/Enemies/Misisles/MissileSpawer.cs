using System.Collections.Generic;
using UnityEngine;
using CarterGames.Utilities;
using System.Collections;
using CarterGames.Assets.AudioManager;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class MissileSpawer : MonoBehaviour
    {
        [SerializeField] private int missilesWanted = 0;
        [SerializeField] private float minDistance = 2500;
        [SerializeField] private float maxDistance = 5000;

        private bool isCoR;
        private Ship ship;

        public GameObject missilePrefab;

        public int objectLimit { get; set; }
        public List<GameObject> objectPool { get; set; }

        public List<GameObject> activeMissiles;

        public float minWait;
        public float maxWait;

        private AudioManager am;
        

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

            ship = FindObjectOfType<Ship>();
            am = FindObjectOfType<AudioManager>();
        }


        private void Update()
        {
            if (!isCoR)
            {
                StartCoroutine(FireMissileCo(Random.Range(minWait, maxWait)));
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
                    Vector3 dir = new Vector3(ship.gameObject.transform.position.x - objectPool[i].transform.position.x, 0, ship.gameObject.transform.position.z - objectPool[i].transform.position.z);
                    objectPool[i].transform.LookAt(dir);
                    objectPool[i].SetActive(true);
                    objectPool[i].GetComponent<EnemyMissile>().target = ship.gameObject;
                    activeMissiles.Add(objectPool[i]);
                    break;
                }
            }

            yield return new WaitForSeconds(delay);
            isCoR = false;
        }


        private Vector3 ChooseSpawnLocation()
        {
            float innerRad = minDistance;
            float outerRad = maxDistance;

            Vector3 dir = Random.insideUnitSphere;
            float length = innerRad + outerRad * Random.value;

            Vector3 final = dir.normalized * length;

            return final;
        }
    }
}