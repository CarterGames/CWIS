using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CarterGames.CWIS
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int poolSize;

        public int maxAmmo;
        public int ammo;
        public float bulletSpeed;
        public float fireRate;

        private GameObject[] bulletPool;
        private bool canShoot = true;
        internal Actions actions;


        private void OnEnable()
        {
            // Input actions setup
            actions = new Actions();
            actions.Enable();
            canShoot = true;
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


        /// <summary>
        /// Rotates the turret to the mouse position
        /// </summary>
        /// <param name="_min">Min rotation</param>
        /// <param name="_max">Max rotation</param>
        /// <returns>Quaternion</returns>
        internal Quaternion RotateToMousePos()
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            float rotation = 0;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                Vector3 direction = target - transform.position;
                rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 90f;
            }

            return Quaternion.Euler(0, rotation, 0);
        }


        /// <summary>
        /// Shoots a bullet if the range is good...
        /// </summary>
        internal void FireBullet()
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("raycast called");

                if (canShoot)
                {
                    Debug.Log("shoot called");
                    StartCoroutine(ShootBulletCO(transform.position, (hit.point - transform.position).normalized, fireRate));
                }
            }
        }



        private IEnumerator ShootBulletCO(Vector3 spawnPosition, Vector3 direction, float rateOfFire)
        {
            Debug.Log("co called");
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
    }
}