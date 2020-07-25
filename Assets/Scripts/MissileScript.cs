using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class MissileScript : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosion;
        [SerializeField] private Transform radarSprite;

        private GameManager gm;

        private void OnEnable()
        {
            radarSprite.localScale = Vector3.zero;
        }

        private void Start()
        {
            if (!gm)
            {
                gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            }
        }


        private void Update()
        {
            if (radarSprite.localScale.x < 30f)
            {
                radarSprite.localScale += new Vector3(1, 1, 0) * Time.deltaTime * 30;
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                // explosion
                GameObject _go = Instantiate(explosion.gameObject, transform.position, transform.rotation);
                _go.GetComponent<ParticleSystem>().Play();

                switch (other.gameObject.GetComponent<Bullet>().shotBy)
                {
                    case 1:
                        gm.IncrementCWIS1HitCount();
                        break;
                    case 2:
                        gm.IncrementCWIS2HitCount();
                        break;
                    default:
                        break;
                }

                gameObject.SetActive(false);
            }

            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<ShipController>().DamageShip(1);
                GameObject _go = Instantiate(explosion.gameObject, transform.position, transform.rotation);
                _go.GetComponent<ParticleSystem>().Play();
                gameObject.SetActive(false);
            }
        }
    }
}