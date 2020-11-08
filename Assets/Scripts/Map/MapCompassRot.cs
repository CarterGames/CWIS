using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class MapCompassRot : MonoBehaviour
    {
        [SerializeField] private Transform rotToMatch;


        private void Update()
        {
            if (!transform.rotation.Equals(rotToMatch.rotation))
                transform.rotation = new Quaternion(0, 0, rotToMatch.rotation.y, 0);
        }
    }
}