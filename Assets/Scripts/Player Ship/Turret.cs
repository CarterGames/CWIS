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
        [SerializeField] internal ShipWeapons thisTurret = ShipWeapons.Null;      // Only interal due to it being needed in CIC Script

        [Header("Turret Projectile")]
        [Tooltip("What does this turret shoot?")]
        [SerializeField] private GameObject bulletPrefab = default;

        [Tooltip("How many of the projectile should the turret have?")]
        [SerializeField] private int poolSize = default;

        [Header("Turret Ammo")]
        [SerializeField] internal int maxAmmo = default;
        [SerializeField] internal int ammo = default;
        [SerializeField] private UITextElement ammoCounter = default;

        [Header("*Optional")]
        [SerializeField] internal float bulletSpeed = default;
        [SerializeField] internal float fireRate = default;
        [SerializeField] internal GameObject bulletSpawnPoint = default;
 
        private Camera cam;
        private GameObject[] bulletPool;
        private AudioManager _audio;

        internal float firingTimer = 0f;
        internal float maxFiringTime = 10f;

        internal bool canShoot = true;
        internal bool shouldFireFiveInch;
        internal bool shouldFireCWIS;
        internal bool shouldFireMissile = default;
        internal bool shouldFireSmallArms = default;
        internal Actions actions;
        internal CIC cic;
        internal Ship ship;


        private void OnEnable()
        {
            // Input actions setup
            actions = new Actions();
            actions.Enable();
            canShoot = true;
            cic = GameObject.FindGameObjectWithTag("CIC").GetComponent<CIC>();
            ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();
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

            firingTimer = 0f;
            maxFiringTime = 5f;

            if (!thisTurret.Equals(ShipWeapons.Null))
                AmmoSetup(thisTurret);
        }


        public void Update()
        {
            // Five Inch Firing
            if (shouldFireFiveInch)
            {
                FireBullet();
            }

            if (shouldFireSmallArms)
            {
                FireSmallBullet();
            }


            // CWIS Weapon Firing 
            if (shouldFireCWIS && !CheckGunOverheating())
            {
                FireCWISBullet();
                IncrementFiringTimer();
            }
            else if (shouldFireCWIS && CheckGunOverheating())
                IncrementFiringTimer();
            else if (firingTimer > 0f && !shouldFireCWIS)
                DecrementFiringTimer();

            // Update Ammo Counters
            if (ammoCounter)
            {
                if (!IsAmmoCountCorrect(ammo, ammoCounter.GetTextValue()))
                    ammoCounter.SetTextValue(ammo.ToString());
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Rotates the turret to the mouse position.
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
            if (canShoot && ammo > 0)
            {
                if (bulletSpawnPoint)
                    StartCoroutine(ShootBulletCO(bulletSpawnPoint.transform.position, fireRate));
                else
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
                    ammo -= 1;
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
        public void FireSmallBullet()
        {
            if (canShoot)
            {
                if (bulletSpawnPoint)
                    StartCoroutine(ShootSmallBulletCO(bulletSpawnPoint.transform.position, fireRate));
                else
                    StartCoroutine(ShootSmallBulletCO(transform.position, fireRate));
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Actually shoots the bullet
        /// </summary>
        /// <param name="spawnPosition">Vec3 | place to spawn</param>
        /// <param name="rateOfFire">Float | the speed of which the next bullet will be allowed</param>
        /// ------------------------------------------------------------------------------------------------------
        private IEnumerator ShootSmallBulletCO(Vector3 spawnPosition, float rateOfFire)
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
            if (canShoot && ammo > 0)
            {
                if (bulletSpawnPoint)
                    StartCoroutine(ShootCWISBulletCO(bulletSpawnPoint.transform.position, fireRate));
                else
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
                    ammo -= 1;

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
            if (canShoot && ammo > 0)
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
                    ammo -= 1;
                    break;
                }
            }

            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sets up the amount of ammo this gun has automatically from the ship stats.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void AmmoSetup(ShipWeapons gun)
        {
            int _toGet = (int)gun;
            int[] _weaponStats = ship.GetWeaponAmmo(_toGet);
            maxAmmo = _weaponStats[0];
            ammo = _weaponStats[1];
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Increments the gun overheat timer, which stops guns working when fired too often.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void IncrementFiringTimer()
        {
            firingTimer += Time.deltaTime;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Decrements the gun overheat timer, which stops guns working when fired too often.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void DecrementFiringTimer()
        {
            if (firingTimer > 0f)
                firingTimer -= (Time.deltaTime / 2);
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Check to see if the gun is overheating.
        /// </summary>
        /// <returns>true or false</returns>
        /// ------------------------------------------------------------------------------------------------------
        private bool CheckGunOverheating()
        {
            if (firingTimer < maxFiringTime)
                return false;
            else
                return true;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Checks to see if the ammo count is correct, avoids updating it when not needed.
        /// </summary>
        /// <returns></returns>
        /// ------------------------------------------------------------------------------------------------------
        private bool IsAmmoCountCorrect(int ammo, string toCheck)
        {
            int _toCheckAsInt = int.Parse(toCheck);

            if (!ammo.Equals(_toCheckAsInt))
                return false;
            else
                return true;
        }
    }
}