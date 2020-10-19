using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarterGames.CWIS
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Camera cam;

        public int maxAmmo;
        public int ammo;
        public float fireRate;


        /// <summary>
        /// Rotates the turret to the mouse position
        /// </summary>
        /// <returns>Quaternion</returns>
        internal Quaternion RotateToMousePos()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
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
        /// Rotates the turret to the mouse position
        /// </summary>
        /// <param name="_min">Min rotation</param>
        /// <param name="_max">Max rotation</param>
        /// <returns>Quaternion</returns>
        internal Quaternion RotateToMousePos(float _min, float _max, bool invert = false)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            float rotation = 0;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                Vector3 direction = target - transform.position;
                rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 90f;
                Debug.Log(rotation);

                rotation = Mathf.Clamp(rotation, _min, _max);

                if (invert)
                {
                    rotation = -rotation;
                }
            }

            return Quaternion.Euler(0, rotation, 0);
        }
    }
}