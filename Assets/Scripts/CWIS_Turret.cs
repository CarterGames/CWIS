using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class CWIS_Turret : MonoBehaviour
    {
        [SerializeField] private CWIS_Controller.Controller thisTurret;
        [SerializeField] internal GameManager.Ranks thisRank;

        private Camera cam;
        private ShipController ship;
        private CWIS_Controller control;

        private bool canShoot;
        private bool hasAmmo;
        private bool isFiring;

        [SerializeField] internal float timeHeldDown;
        [SerializeField] private float maxTime;

        internal int rateOfFire = 0;
        internal int coolerEff = 0;
        internal int ammoCap = 0;


        private void Start()
        {
            cam = Camera.main;
            control = FindObjectOfType<CWIS_Controller>();
            ship = FindObjectOfType<ShipController>();
            canShoot = true;
            hasAmmo = true;
        }


        private void Update()
        {
            if (control.activeTurret == thisTurret)
            {
                RotateToMousePos();

                if (timeHeldDown > maxTime)
                {
                    canShoot = false;
                }
                else
                {
                    canShoot = true;
                }

                if (Input.GetMouseButton(0))
                {
                    IncrementTimeHeldDown();
                    isFiring = true;

                    if (hasAmmo && canShoot)
                    {
                        RaycastHit hit;
                        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                        {
                            control.ShootBullet(transform.position, (hit.point - transform.position).normalized, thisTurret);
                        }
                    }
                }
                else
                {
                    if (isFiring)
                    {
                        isFiring = false;
                    }
                }
            }

            if (!isFiring)
            {
                if (timeHeldDown != 0)
                {
                    timeHeldDown -= Time.deltaTime / 6;
                }
            }
        }


        private void RotateToMousePos()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                Vector3 direction = target - transform.position;
                float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 90f;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
        }


        private void IncrementTimeHeldDown()
        {
            timeHeldDown += Time.deltaTime;
        }


        private void Ranking()
        {

        }
    }
}