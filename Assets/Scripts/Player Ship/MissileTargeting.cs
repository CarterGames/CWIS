using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class MissileTargeting : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private MissileSpawer activeEnemyMisisles;
        [SerializeField] private bool hasTarget;
        [SerializeField] private float maxRange;

        private Vector3 startPos;
        private Vector3 targetingLine;
        private LineRenderer visualLine;
        private MissileLauncher missileLauncher;
        private bool isActive;
        private Actions actions;


        private void OnEnable()
        {
            actions = new Actions();
            actions.Enable();
        }

        private void OnDisable()
        {
            actions.Disable();
        }

        private void Start()
        {
            visualLine = GetComponent<LineRenderer>();
            missileLauncher = GetComponent<MissileLauncher>();
            startPos = new Vector3(transform.position.x, 4, transform.position.z);
            cam = GameObject.FindGameObjectWithTag("GameCam").GetComponent<Camera>();
        }


        private void Update()
        {
            if (isActive)
            {
                Plane plane = new Plane(Vector3.up, 0);

                float distance;
                Ray ray = cam.ScreenPointToRay(actions.Weapons.Position.ReadValue<Vector2>());

                if (plane.Raycast(ray, out distance))
                {
                    targetingLine = ray.GetPoint(distance);
                    targetingLine.y = 4;
                }

                visualLine.SetPosition(0, startPos);
                visualLine.SetPosition(1, (targetingLine - startPos).normalized * maxRange + targetingLine);

                RaycastHit hit;

                if (Physics.Linecast(startPos, (targetingLine - startPos).normalized * maxRange + targetingLine, out hit))
                {
                    if (hit.collider.gameObject.GetComponent<RadarIcons>())
                        missileLauncher.SetTarget(hit.collider.gameObject);
                }
            }
        }

        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Enables the targeting system for missiles.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        public void EnableTargeting()
        {
            isActive = true;
        }

        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Dnables the targeting system for missiles.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        public void DisableTargeting()
        {
            isActive = false;
        }

        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the active status of the targeting system
        /// </summary>
        /// <returns>Bool | Is this system active?</returns>
        /// ------------------------------------------------------------------------------------------------------
        public bool GetActiveStatus()
        {
            return isActive;
        }
    }
}