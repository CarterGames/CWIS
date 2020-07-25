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
                    break;
                }
            }

            yield return new WaitForSeconds(delay);
            isCoR = false;
        }


        private Vector3 ChooseSpawnLocation()
        {
            return Random.onUnitSphere * (Random.Range(500, 2000));
        }
    }
}