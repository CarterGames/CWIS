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


        private void Start()
        {
            visualLine = GetComponent<LineRenderer>();
            missileLauncher = GetComponent<MissileLauncher>();
            startPos = new Vector3(transform.position.x, 4, transform.position.z);
        }


        private void Update()
        {
            Plane plane = new Plane(Vector3.up, 0);

            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

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
}