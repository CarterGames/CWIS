using UnityEngine;
using System.Collections;
using CarterGames.Utilities;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/


namespace CarterGames.CWIS.EndlessSurvival
{
    public class CrateSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject crateObject;
        [SerializeField] private float[] minMaxWait;
        [SerializeField] private int maxCrates;

        private GameObject[] cratePool;
        private bool isCoR;


        private void Start()
        {
            cratePool = new GameObject[maxCrates];

            for (int i = 0; i < cratePool.Length; i++)
            {
                GameObject _go = Instantiate(crateObject);
                _go.name = "*** Crate Object Pool ***";
                _go.SetActive(false);
                cratePool[i] = _go;
            }
        }


        private void Update()
        {
            if (!isCoR)
            {
                StartCoroutine(CrateSpawnerCo());
            }
        }


        private IEnumerator CrateSpawnerCo()
        {
            isCoR = true;

            for (int i = 0; i < maxCrates; i++)
            {
                if (!cratePool[i].activeInHierarchy)
                {
                    //Vector3 spawnPos = ChooseSpawnLocation();
                    cratePool[i].transform.position = new Vector3(GetRandom.Float(-150f, 150f), 3, -150f);
                    cratePool[i].SetActive(true);
                    break;
                }
            }

            yield return new WaitForSeconds(GetRandom.Float(minMaxWait[0], minMaxWait[1]));
            isCoR = false;
        }


        //private Vector3 ChooseSpawnLocation()
        //{
        //    return Random.onUnitSphere * (Random.Range(500, 2000));
        //}
    }
}