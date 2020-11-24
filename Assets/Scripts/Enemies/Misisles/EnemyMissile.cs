using CarterGames.Assets.AudioManager;
using CarterGames.Utilities;
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
            //radarSprite.localScale = Vector3.zero;
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
            //if (!isTargeted)
            //{
            //    if (radarSprite.localScale.x > 0f)
            //    {
            //        radarSprite.localScale += new Vector3(-1, -1, 0) * Time.deltaTime * 10;
            //    }
            //}

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

                // play audio here....

                ms.activeMissiles.Remove(this.gameObject);
                ms.scoring.IncrementScore(GetRandom.Int(95, 100));
                gameObject.SetActive(false);
            }



            if (other.gameObject.CompareTag("Chaft"))
            {
                // explosion
                GameObject _go = Instantiate(explosion.gameObject, transform.position, transform.rotation);
                _go.GetComponent<ParticleSystem>().Play();

                //am.Play("missileHitFar", .25f, Random.Range(.75f, .95f));

                ms.activeMissiles.Remove(this.gameObject);
                ms.scoring.IncrementScore(GetRandom.Int(150, 200));
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

                ms.scoring.DecrementScore(500);
                gameObject.SetActive(false);
            }



            if (other.gameObject.CompareTag("Radar"))
            {
                radarSprite.localScale = Vector3.one * 50;
            }
        }
    }
}