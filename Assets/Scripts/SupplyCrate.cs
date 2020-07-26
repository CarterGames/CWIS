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
        [SerializeField] private float moveSpd = 10;
        private Rigidbody rB;
        private ShipController ship;
        private CWIS_Controller control;
        private GameManager gm;

        public int ammoStandard;
        public int ammoSpecial;
        public int health;
        public int missiles;


        private void OnEnable()
        {
            ammoStandard = Random.Range(30, 300);
            ammoSpecial = Random.Range(2, 10);
            health = Random.Range(-5, 1);
            missiles = Random.Range(-5, 2);
        }


        private void Start()
        {
            rB = GetComponent<Rigidbody>();
            ship = FindObjectOfType<ShipController>();
            control = FindObjectOfType<CWIS_Controller>();
            gm = FindObjectOfType<GameManager>();

            rB.velocity = (new Vector3(transform.position.x, transform.position.y, 100) - transform.position).normalized * moveSpd;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                // splits CWIS ammo evenly between both guns
                int ammoSplit = Mathf.Abs(ammoStandard / 2);
                control.AddAmmo_CW1(ammoSplit);
                control.AddAmmo_CW2(ammoSplit);

                // special ammo here if I get to it

                // health, only if it is a positive value and below the max value
                if (health > 0 && ship.shipHealth + health <= 5)
                {
                    ship.shipHealth += health;
                }

                // missiles, only if it is a positive value and below the max value
                if (missiles > 0 && ship.shipMissiles + missiles <= 3)
                {
                    ship.shipMissiles += missiles;
                }

                gm.AddToScore(50);
                gameObject.SetActive(false);
            }
        }
    }
}