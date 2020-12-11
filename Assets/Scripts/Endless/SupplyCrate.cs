using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class SupplyCrate : MonoBehaviour
    {
        [SerializeField] private GameObject crateuiPrefab;
        [SerializeField] private float moveSpd = 10;

        private Rigidbody rB;
        private Transform crateAnchor;

        public int ammoStandard;
        public int ammoSpecial;
        public int missiles;


        private void OnEnable()
        {
            ammoStandard = Random.Range(30, 300);
            ammoSpecial = Random.Range(2, 10);
            missiles = Random.Range(-5, 4);
        }


        private void Start()
        {
            rB = GetComponent<Rigidbody>();

            rB.velocity = (Vector3.zero - transform.position).normalized * moveSpd;

            //crateAnchor = GameObject.FindGameObjectWithTag("crateanchor").transform;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Player"))
            {
                // splits CWIS ammo evenly between both guns
                int ammoSplit = Mathf.Abs(ammoStandard / 2);


                // missiles, only if it is a positive value and below the max value
                if (missiles > 0)
                {
                    //ship.shipMissiles += missiles;
                }


                // make the ui showing what was gotten
                GameObject _go = Instantiate(crateuiPrefab, crateAnchor);

                gameObject.SetActive(false);
            }
        }
    }
}