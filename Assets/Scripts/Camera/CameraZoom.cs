using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private Camera mainCam;
        [SerializeField] private GameObject[] zooms;

        private Actions actions;
        private bool isCoR;
        [SerializeField] private int pos;


        private void OnEnable()
        {
            actions = new Actions();
            actions.Enable();
        }

        private void OnDisable()
        {
            actions.Disable();
        }


        private void Update()
        {
            if (!isCoR)
            {
                if (actions.CIC.CameraZoom.ReadValue<float>() > .1f)
                {
                    EditPosition(1);
                }
                else if (actions.CIC.CameraZoom.ReadValue<float>() < -.1f)
                {
                    EditPosition(-1);
                }
            }

            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, zooms[pos].transform.position, Time.deltaTime * 2);
        }


        private void EditPosition(int _change)
        {
            pos += _change;

            if (pos.Equals(zooms.Length))
            {
                pos = 0;
            }
            else if (pos.Equals(-1))
            {
                pos = zooms.Length - 1;
            }

            StartCoroutine(InputDelay());
        }


        private IEnumerator InputDelay()
        {
            isCoR = true;
            yield return new WaitForSeconds(.25f);
            isCoR = false;
        }
    }
}