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
        [SerializeField] private Camera cam = default;
        [SerializeField] private MissileSpawer activeEnemyMisisles = default;
        [SerializeField] private bool hasTarget = default;
        [SerializeField] private float maxRange = default;

        private Vector3 startPos;
        private Vector3 targetingLine;
        private LineRenderer visualLine;
        private MissileLauncher missileLauncher;
        private bool isActive;
        private Actions actions;
        private InputDevice device;


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
            visualLine = GetComponentInParent<LineRenderer>();
            missileLauncher = GetComponentInParent<MissileLauncher>();
            startPos = new Vector3(transform.position.x, 4, transform.position.z);
            cam = GameObject.FindGameObjectWithTag("GameCam").GetComponent<Camera>();
        }


        private void Update()
        {
            if (isActive)
            {
                startPos = new Vector3(transform.position.x, 4, transform.position.z);

                Plane plane = new Plane(Vector3.up, 0);


                InputSystem.onActionChange += (obj, change) =>
                {
                    if (change == InputActionChange.ActionPerformed)
                    {
                        var inputAction = (InputAction)obj;
                        var lastControl = inputAction.activeControl;
                        device = lastControl.device;
                    }
                };

                Ray ray = new Ray();

                if (device != null)
                {
                    if (device.displayName.Equals("Mouse"))
                    {
                        ray = cam.ScreenPointToRay(actions.Weapons.Position.ReadValue<Vector2>());

                        float distance;

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
                    else
                    {
                        ray = cam.ScreenPointToRay(actions.Weapons.PositionJoystick.ReadValue<Vector2>());

                        visualLine.SetPosition(0, startPos);
                        visualLine.SetPosition(1, transform.forward * 1000);

                        transform.rotation = Quaternion.Euler(0, Mathf.Atan2(actions.Weapons.PositionJoystick.ReadValue<Vector2>().x, actions.Weapons.PositionJoystick.ReadValue<Vector2>().y) * Mathf.Rad2Deg + 180f, 0);

                        RaycastHit hit;

                        if (Physics.Linecast(startPos, transform.forward * maxRange + targetingLine, out hit))
                        {
                            if (hit.collider.gameObject.GetComponent<RadarIcons>())
                                missileLauncher.SetTarget(hit.collider.gameObject);
                        }
                    }
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