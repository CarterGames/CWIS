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
    public class EnemyMissile : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosion = default;
        [SerializeField] private Transform radarSprite = default;
        [SerializeField] private float missileSpd = 150f;

        private AudioManager am;
        private MissileSpawer ms;
        private Camera cam;
        private bool isTargeted;

        internal GameObject target;


        private void OnEnable()
        {
            radarSprite.localScale = Vector3.zero;
            isTargeted = false;
        }


        private void Start()
        {
            //if (!am)
            //{
            //    am = FindObjectOfType<AudioManager>();
            //}

            if (!ms)
            {
                ms = FindObjectOfType<MissileSpawer>();
            }

            if (!cam)
            {
                cam = GameObject.FindGameObjectWithTag("GameCam").GetComponent<Camera>();
            }
        }


        private void Update()
        {
            if (!isTargeted)
            {
                if (radarSprite.localScale.x > 0f)
                {
                    radarSprite.localScale += new Vector3(-1, -1, 0) * Time.deltaTime * 10;
                }
            }

            Vector3 dir = new Vector3(target.gameObject.transform.position.x - transform.position.x, 0, target.gameObject.transform.position.z - transform.position.z);
            GetComponent<Rigidbody>().velocity = (dir).normalized * missileSpd;
            Vector3 _dir = target.transform.position - transform.position;
            float _rot = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _rot, 0), 10f);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("CWISBullet"))
            {
                // explosion
                GameObject _go = Instantiate(explosion.gameObject, transform.position, transform.rotation);
                _go.GetComponent<ParticleSystem>().Play();



                if (IsVisibleFrom(this.GetComponentInChildren<Renderer>(), cam))
                {
                    //am.Play("missileHitFar", Random.Range(.2f, .3f), Random.Range(1f, 1.25f));
                }
                else
                {
                    //am.Play("missileHitFar", Random.Range(.05f, .2f), Random.Range(.75f, .95f));
                }

                ms.activeMissiles.Remove(this.gameObject);
                gameObject.SetActive(false);
            }



            if (other.gameObject.CompareTag("Chaft"))
            {
                // explosion
                GameObject _go = Instantiate(explosion.gameObject, transform.position, transform.rotation);
                _go.GetComponent<ParticleSystem>().Play();

                //am.Play("missileHitFar", .25f, Random.Range(.75f, .95f));

                ms.activeMissiles.Remove(this.gameObject);
                gameObject.SetActive(false);
            }



            if (other.gameObject.CompareTag("Player"))
            {
                //am.Play("hit", .5f);
                GameObject _go = Instantiate(explosion.gameObject, transform.position, transform.rotation);
                _go.GetComponent<ParticleSystem>().Play();

                if (other.gameObject.GetComponent<Ship>())
                {
                    other.gameObject.GetComponent<Ship>().ReduceShipHealth();
                }

                gameObject.SetActive(false);
            }



            if (other.gameObject.CompareTag("Radar"))
            {
                radarSprite.localScale = Vector3.one * 50;
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