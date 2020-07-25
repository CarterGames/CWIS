using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarterGames.Utilities;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class CWIS_Controller : MonoBehaviour, IObjectPool<GameObject>
    {
        [SerializeField] private int maxController = 3;
        [SerializeField] private GameObject[] turrets;
        [SerializeField] private GameObject[] turretUI;

        private bool isCoR;
        private int ammo1 = 200;
        internal int maxAmmo1 = 200;
        private int ammo2 = 200;
        internal int maxAmmo2 = 200;

        private bool isShooting;

        internal float[] shootSpd;

        public GameObject bulletPrefab;
        public int bulletPoolLimit;

        public enum Controller { CWIS1, CWIS2, Shaft };
        public Controller activeTurret;


        public int objectLimit { get; set; }
        public List<GameObject> objectPool { get; set; }



        private void Start()
        {
            objectLimit = bulletPoolLimit;
            objectPool = new List<GameObject>();

            for (int i = 0; i < objectLimit; i++)
            {
                GameObject _go = Instantiate(bulletPrefab);
                _go.SetActive(false);
                objectPool.Add(_go);
            }

            shootSpd = new float[2] { 120f, 120f };
        }



        private void Update()
        {
            if ((Input.GetMouseButtonDown(1)) && (!isCoR))
            {
                StartCoroutine(Cycle());
            }
        }


        private void CycleController()
        {
            activeTurret++;

            switch (activeTurret)
            {
                case Controller.CWIS1:
                    turretUI[0].SetActive(true);
                    turretUI[1].SetActive(false);
                    break;
                case Controller.CWIS2:
                    turretUI[1].SetActive(true);
                    turretUI[0].SetActive(false);
                    break;
                case Controller.Shaft:
                    turretUI[0].SetActive(false);
                    turretUI[1].SetActive(false);
                    break;
                default:
                    break;
            }

            if ((int)activeTurret == maxController)
            {
                activeTurret = 0;
                turretUI[0].SetActive(true);
                turretUI[1].SetActive(false);
            }
        }


        private IEnumerator Cycle()
        {
            isCoR = true;
            CycleController();
            yield return new WaitForSeconds(.25f);
            isCoR = false;
        }


        public void ShootBullet(Vector3 startPos, Vector3 direction, Controller controller, float delay)
        {
            if (!isShooting)
            {
                StartCoroutine(ShootBulletCo(startPos, direction, controller, delay));
            }
        }


        private IEnumerator ShootBulletCo(Vector3 startPos, Vector3 direction, Controller controller, float delay)
        {
            isShooting = true;
            float moveSpd = 0;
            bool shoot = true;

            for (int i = 0; i < objectLimit; i++)
            {
                if (!objectPool[i].activeInHierarchy)
                {
                    switch (controller)
                    {
                        case Controller.CWIS1:

                            if (ammo1 > 0)
                            {
                                UseAmmo_CW1();
                                moveSpd = Random.Range(shootSpd[0] - 10, shootSpd[0] + 10);
                                objectPool[i].GetComponent<Bullet>().shotBy = 1;
                            }
                            else
                            {
                                shoot = false;
                            }

                            break;
                        case Controller.CWIS2:

                            if (ammo2 > 0)
                            {
                                UseAmmo_CW2();
                                moveSpd = Random.Range(shootSpd[1] - 10, shootSpd[1] + 10);
                                objectPool[i].GetComponent<Bullet>().shotBy = 2;
                            }
                            else
                            {
                                shoot = false;
                            }

                            break;
                        default:
                            moveSpd = 0;
                            break;
                    }

                    if (shoot)
                    {
                        objectPool[i].transform.position = startPos;
                        objectPool[i].transform.rotation = Quaternion.LookRotation(direction);
                        objectPool[i].GetComponent<Rigidbody>().velocity = (new Vector3(direction.x, 0, direction.z)).normalized * moveSpd;
                        objectPool[i].SetActive(true);
                    }

                    break;
                }
            }

            yield return new WaitForSeconds(delay);
            isShooting = false;
        }


        public string GetAmmoCount_CW1()
        {
            return ammo1.ToString();
        }

        public void UseAmmo_CW1()
        {
            ammo1--;
        }


        public void AddAmmo_CW1(int input)
        {
            if (ammo1 + input < maxAmmo1)
            {
                ammo1 += input;
            }
            else
            {
                ammo1 = maxAmmo1;
            }
        }

        public string GetAmmoCount_CW2()
        {
            return ammo2.ToString();
        }

        public void UseAmmo_CW2()
        {
            ammo2--;
        }


        public void AddAmmo_CW2(int input)
        {
            if (ammo2 + input < maxAmmo2)
            {
                ammo2 += input;
            }
            else
            {
                ammo2 = maxAmmo2;
            }
        }
    }
}