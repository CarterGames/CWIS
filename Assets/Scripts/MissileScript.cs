using CarterGames.Assets.AudioManager;
using System.Collections;
using UnityEngine;

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
        private AudioManager am;

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

            if (!am)
            {
                am = FindObjectOfType<AudioManager>();
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


                if (IsVisibleFrom(this.GetComponentInChildren<Renderer>(), Camera.main))
                {
                    //am.Play("missileHitClose", .5f, .75f);
                }
                else
                {
                    am.Play("missileHitFar", .5f, .75f);
                }

                gm.AddToScore(50 + (int)(Vector3.Distance(transform.position, Vector3.zero)));

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



        /// <summary>
        /// Checks to see if the inputted camera can see the object
        /// </summary>
        /// <param name="renderer">Renderer to check</param>
        /// <param name="camera">Camera view to check</param>
        /// <returns>true / false</returns>
        private bool IsVisibleFrom(Renderer renderer, Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
    }
}