using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int poolSize;

        public ShipWeapons thisTurret;
        public int maxAmmo;
        public int ammo;
        public float bulletSpeed;
        public float fireRate;
        public bool shouldFireBullet;
        public bool shouldFireMissile;

        internal CIC cic;
        private GameObject[] bulletPool;
        internal bool canShoot = true;
        internal Actions actions;


        private void OnEnable()
        {
            // Input actions setup
            actions = new Actions();
            actions.Enable();
            canShoot = true;
            cic = GameObject.FindGameObjectWithTag("CIC").GetComponent<CIC>();
        }


        private void OnDisable()
        {
            actions.Disable();
        }


        public void Start()
        {
            // Bullet object pooling
            bulletPool = new GameObject[poolSize];

            for (int i = 0; i < poolSize; i++)
            {
                GameObject _bullet = Instantiate(bulletPrefab);
                _bullet.name = "** Bullet Object Pool Item **";
                _bullet.SetActive(false);
                bulletPool[i] = _bullet;
            }
        }


        public void Update()
        {
            if (shouldFireBullet)
            {
                FireBullet();
            }

            if (shouldFireMissile)
            {

            }
        }


        /// <summary>
        /// Rotates the turret to the mouse position
        /// </summary>
        /// <param name="_min">Min rotation</param>
        /// <param name="_max">Max rotation</param>
        /// <returns>Quaternion</returns>
        internal Quaternion RotateToMousePos(float offset = 0)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            float rotation = 0;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                Vector3 direction = target - transform.position;
                rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 90f - offset;
            }

            return Quaternion.Euler(0, rotation, 0);
        }


        /// <summary>
        /// Shoots a bullet if the range is good...
        /// </summary>
        internal void FireBullet()
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (canShoot)
            {
                Debug.Log("shoot called");
                StartCoroutine(ShootBulletCO(transform.position, (ray.direction * 1000 - transform.position).normalized, fireRate));
            }
        }



        private IEnumerator ShootBulletCO(Vector3 spawnPosition, Vector3 direction, float rateOfFire)
        {
            canShoot = false;
            for (int i = 0; i < poolSize; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    bulletPool[i].transform.position = spawnPosition;
                    bulletPool[i].transform.rotation = transform.rotation;
                    bulletPool[i].GetComponent<Rigidbody>().velocity = (new Vector3(direction.x, 0, direction.z)).normalized * bulletSpeed;
                    bulletPool[i].SetActive(true);
                    break;
                }
            }

            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;
        }



        internal void FireMissile(Transform spawnPosition, float rateOfFire)
        {
            if (canShoot)
            {
                StartCoroutine(ShootMissileCO(spawnPosition, rateOfFire));
            }
        }


        private IEnumerator ShootMissileCO(Transform spawnPosition, float rateOfFire)
        {
            canShoot = false;

            for (int i = 0; i < poolSize; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    bulletPool[i].transform.position = spawnPosition.position;
                    bulletPool[i].transform.rotation = transform.rotation;
                    
                    bulletPool[i].SetActive(true);
                    break;
                }
            }

            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;
        }
    }
}