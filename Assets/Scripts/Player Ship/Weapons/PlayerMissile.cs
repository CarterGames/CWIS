using CarterGames.Assets.AudioManager;
using CarterGames.Utilities;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class PlayerMissile : MonoBehaviour
    {
        [SerializeField] private Transform radarIcon = default;

        private AudioManager am;
        private Rigidbody rb;

        internal GameObject targetPos;
        internal Score scoring;

        public int missileSpd = 150;


        private void OnDisable()
        {
            targetPos = null;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            am = FindObjectOfType<AudioManager>();
            scoring = GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>();
        }


        private void FixedUpdate()
        {
            Vector3 dir = new Vector3(targetPos.transform.position.x - transform.position.x, 0, targetPos.transform.position.z - transform.position.z);
            rb.velocity = (dir).normalized * missileSpd;
            transform.LookAt(targetPos.transform.position);

            if (!targetPos.gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }
        }


        private void LateUpdate()
        {
            radarIcon.transform.rotation = Quaternion.Euler(90, -90, 0);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
            {
                other.gameObject.GetComponent<RadarIcons>().SetIconColour(Color.green);
                other.gameObject.SetActive(false);
                am.Play("missileHitFar", .25f, Random.Range(.75f, .95f));
                scoring.IncrementScore(GetRandom.Int(150, 175));
                gameObject.SetActive(false);
            }
        }
    }
}