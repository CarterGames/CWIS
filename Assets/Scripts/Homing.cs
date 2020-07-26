using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class Homing : MonoBehaviour
    {
        private Rigidbody rb;
        internal GameObject targetPos;
        public int missileSpd = 150;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }


        private void FixedUpdate()
        {
            Vector3 dir = new Vector3(targetPos.transform.position.x - transform.position.x, 0, targetPos.transform.position.z - transform.position.z);
            rb.velocity = (dir).normalized * missileSpd;
            transform.LookAt(dir);

            if (!targetPos.gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}