using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Mobile
{
    public class MobileElement : MonoBehaviour
    {
        private void Awake()
        {
#if UNITY_ANDROID
            gameObject.SetActive(true);
#else
            gameObject.SetActive(false);
#endif
        }
    }
}