using CarterGames.Utilities;
using CarterGames.Assets.AudioManager;
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
        [Header("Turret")]
        [Tooltip("Which turret is this?")]
        [SerializeField] internal ShipWeapons thisTurret;      // Only interal due to it being needed in CIC Script

        [Header("Turret Projectile")]
        [Tooltip("What does this turret shoot?")]
        [SerializeField] private GameObject bulletPrefab;

        [Tooltip("How many of the projectile should the turret have?")]
        [SerializeField] private int poolSize;

        [Header("Turret Ammo")]
        [SerializeField] internal int maxAmmo;
        [SerializeField] internal int ammo;

        [Header("*Optional")]
        [SerializeField] internal float bulletSpeed;
        [SerializeField] internal float fireRate;
        [SerializeField] internal bool notOverheating;

        private Camera cam;
        private GameObject[] bulletPool;
        private AudioManager _audio;

        internal bool canShoot = true;
        internal bool shouldFireFiveInch;
        internal bool shouldFireCWIS;
        internal bool shouldFireMissile;
        internal Actions actions;
        internal CIC cic;


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

            _audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
            cam = GameObject.FindGameObjectWithTag("GameCam").GetComponent<Camera>();
        }


        public void Update()
        {
            if (shouldFireFiveInch)
            {
                FireBullet();
            }            
            
            if (shouldFireCWIS)
            {
                FireCWISBullet();
            }

            if (shouldFireMissile)
            {
                //FireMissile();
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Rotates the turret to the mouse position
        /// </summary>
        /// <param name="_min">Min rotation</param>
        /// <param name="_max">Max rotation</param>
        /// <returns>Quaternion rotation for the object</returns>
        /// ------------------------------------------------------------------------------------------------------
        internal Quaternion RotateToMousePos(float offset = 0)
        {
            Ray ray = cam.ScreenPointToRay(actions.Weapons.Position.ReadValue<Vector2>());
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            float rotation = 0;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                Vector3 direction = target - transform.position;
                rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 180f;
            }

            return Quaternion.Euler(0, rotation, 0);
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Shoots a bullet if the range is good...
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        public void FireBullet()
        {
            if (canShoot)
            {
                Debug.Log("shoot called");
                StartCoroutine(ShootBulletCO(transform.position, fireRate));
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Actually shoots the bullet (normally the 5")
        /// </summary>
        /// <param name="spawnPosition">Vec3 | place to spawn</param>
        /// <param name="rateOfFire">Float | the speed of which the next bullet will be allowed</param>
        /// ------------------------------------------------------------------------------------------------------
        private IEnumerator ShootBulletCO(Vector3 spawnPosition, float rateOfFire)
        {
            canShoot = false;

            for (int i = 0; i < poolSize; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    // Place and spawn
                    bulletPool[i].transform.position = spawnPosition;
                    bulletPool[i].transform.rotation = transform.rotation;
                    bulletPool[i].GetComponent<Rigidbody>().velocity = -transform.forward * bulletSpeed;
                    bulletPool[i].SetActive(true);

                    // Audio on shoot
                    //_audio.PlayFromTime("cwisShoot", .65f, GetRandom.Float(.2f, .3f), GetRandom.Float(.6f, .75f));

                    break;
                }
            }

            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;
        }

        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Shoots a bullet if the range is good...
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        public void FireCWISBullet()
        {
            if (canShoot)
            {
                Debug.Log("shoot called");
                StartCoroutine(ShootCWISBulletCO(transform.position, fireRate));
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Actually shoots the C.W.I.S style bullet
        /// </summary>
        /// <param name="spawnPosition">Vec3 | place to spawn</param>
        /// <param name="rateOfFire">Float | the speed of which the next bullet will be allowed</param>
        /// ------------------------------------------------------------------------------------------------------
        private IEnumerator ShootCWISBulletCO(Vector3 spawnPosition, float rateOfFire)
        {
            canShoot = false;

            for (int i = 0; i < poolSize; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    // Place and spawn
                    bulletPool[i].transform.position = spawnPosition;
                    bulletPool[i].transform.rotation = Quaternion.Euler(GetRandom.Vector3(transform.rotation.eulerAngles, 0, 0, 3f, 3f, 0, 0));
                    bulletPool[i].GetComponent<Rigidbody>().velocity = -bulletPool[i].transform.forward * bulletSpeed;
                    bulletPool[i].SetActive(true);

                    // Audio on shoot
                    _audio.PlayFromTime("cwisShoot", .65f, GetRandom.Float(.2f, .3f), GetRandom.Float(.6f, .75f));
                    break;
                }
            }

            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Fires a missile from a silo, the misisle itself will have the targeting info passed into it here or elsewhere.
        /// </summary>
        /// <param name="spawnPosition">Vec3 | place to spawn</param>
        /// <param name="rateOfFire">Float | the speed of which the next missile will be allowed</param>
        /// ------------------------------------------------------------------------------------------------------
        public void FireMissile(Transform spawnPosition, GameObject target, float rateOfFire, ParticleSystem particle)
        {
            if (canShoot)
            {
                StartCoroutine(ShootMissileCO(spawnPosition, target, rateOfFire, particle));
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spawnPosition"></param>
        /// <param name="rateOfFire"></param>
        /// ------------------------------------------------------------------------------------------------------
        private IEnumerator ShootMissileCO(Transform spawnPosition, GameObject target, float rateOfFire, ParticleSystem particle)
        {
            canShoot = false;
            particle.Play();
            yield return new WaitForSeconds(.75f);
            particle.Stop();

            for (int i = 0; i < poolSize; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    bulletPool[i].transform.position = spawnPosition.position;
                    bulletPool[i].transform.rotation = transform.rotation;
                    bulletPool[i].GetComponent<PlayerMissile>().targetPos = target;
                    bulletPool[i].SetActive(true);
                    break;
                }
            }

            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;
        }
    }
}