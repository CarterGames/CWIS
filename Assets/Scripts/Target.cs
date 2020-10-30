using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    [RequireComponent(typeof(BoxCollider))]
    public class Target : MonoBehaviour
    {
        [SerializeField] internal int health;

        private void Update()
        {
            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Contains("Bullet") || other.gameObject.tag.Contains("Round"))
            {
                --health;
                other.gameObject.SetActive(false);
            }
        }
    }
}