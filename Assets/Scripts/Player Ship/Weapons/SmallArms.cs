using System.Collections.Generic;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class SmallArms : Turret
    {
        [SerializeField] private GameObject targets = default;

        private Vector3 dir;
        private float rot;


        private new void Start()
        {
            base.Start();
        }


        private new void Update()
        {

            if (targets)
            {
                dir = targets.transform.position - transform.position;
                rot = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + 180f;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rot, 0), 10f);
            }

            if (targets)
            {
                base.shouldFireSmallArms = true;
            }
            else
            {
                base.shouldFireSmallArms = false;
            }

            base.Update();

            if (targets && !targets.activeInHierarchy)
            {
                targets = null;
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Target"))
            {
                targets = other.gameObject;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.Equals(targets))
                targets = null;
        }
    }
}