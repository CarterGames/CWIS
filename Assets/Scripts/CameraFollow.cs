using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform toFollow;


        private void Update()
        {
            if (!Vector3Match(transform.position, toFollow.position))
            {
                transform.position = new Vector3(toFollow.position.x, transform.position.y, toFollow.position.z);
            }
        }


        private bool Vector3Match(Vector3 a, Vector3 b)
        {
            if (!a.x.Equals(b.x) || !a.y.Equals(b.y) || !a.z.Equals(b.z))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}