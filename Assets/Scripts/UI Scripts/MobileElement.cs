using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Mobile
{
    public class MobileElement : MonoBehaviour
    {
        public enum MobileElementActions { SetActive, EnableButton };
        public MobileElementActions elementActions;


        private void Awake()
        {
            switch (elementActions)
            {
                case MobileElementActions.SetActive:
#if UNITY_ANDROID
                    gameObject.SetActive(true);
#else
            gameObject.SetActive(false);
#endif
                    break;
                case MobileElementActions.EnableButton:
#if UNITY_ANDROID
                    GetComponent<Button>().interactable = true;
#else
            GetComponent<Button>().interactable = false;
#endif
                    break;
                default:
                    break;
            }
        }
    }
}