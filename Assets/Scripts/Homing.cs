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
        internal Vector3 targetPos;
        public int missileSpd = 150;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }


        private void Update()
        {
            Vector3 dir = new Vector3(targetPos.x - transform.position.x, 0, targetPos.z - transform.position.z);
            rb.velocity = (dir).normalized * missileSpd;
            transform.LookAt(dir);
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