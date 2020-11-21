using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Menu
{
    public class UIButtonSwitch : MonoBehaviour
    {
        [Header("UI Buttons")]
        [SerializeField] private GameObject[] buttons;

        [Header("Scaling Settings")]
        [SerializeField] private bool shouldScaleOnHover;
        [SerializeField] private float scaleFactor;

        private int pos;
        private int maxPos;
        private bool isCoR;
        private Actions action;
        public InputDevice currentActiveDevice;


        private void OnEnable()
        {
            action = new Actions();
            action.Enable();
        }


        private void OnDisable()
        {
            StopAllCoroutines();
            action.Disable();
        }


        private void Start()
        {
            pos = 0;
            maxPos = buttons.Length - 1;
            isCoR = false;

            if (currentActiveDevice != null)
                if (currentActiveDevice.displayName.Contains("Xbox") || currentActiveDevice.displayName.Contains("Play"))
                    HoverButton();
        }


        private void Update()
        {
            if (currentActiveDevice != null)
            {
                if (currentActiveDevice.displayName.Contains("Xbox") || currentActiveDevice.displayName.Contains("Play"))
                {
                    if (!isCoR)
                    {
                        if (action.Menu.Joystick.ReadValue<Vector2>().y > .1f)
                        {
                            UpdatePos(1);
                        }
                        else if (action.Menu.Joystick.ReadValue<Vector2>().y < -.1f)
                        {
                            UpdatePos(-1);
                        }
                    }
                }
            }
        }


        private void FixedUpdate()
        {
            InputSystem.onActionChange += (obj, change) =>
            {
                if (change == InputActionChange.ActionPerformed)
                {
                    var inputAction = (InputAction)obj;
                    var lastControl = inputAction.activeControl;
                    currentActiveDevice = lastControl.device;
                }
            };
        }


        /// <summary>
        /// Updates the position 
        /// </summary>
        /// <param name="value">value to change to.</param>
        private void UpdatePos(int value)
        {
            pos += value;

            if (pos.Equals(maxPos + 1))
            {
                pos = 0;
            }
            else if (pos.Equals(-1))
            {
                pos = maxPos;
            }

            if (currentActiveDevice != null)
                if (currentActiveDevice.displayName.Contains("Xbox") || currentActiveDevice.displayName.Contains("Play"))
                    HoverButton();

            StartCoroutine(ButtonDelay());
        }


        /// <summary>
        /// Controls the hover factor.
        /// </summary>
        private void HoverButton()
        {
            if (shouldScaleOnHover)
            {
                buttons[pos].transform.localScale = Vector3.one * scaleFactor;

                if (!(pos - 1).Equals(-1))
                {
                    if (!buttons[pos - 1].transform.localScale.Equals(Vector3.one))
                    {
                        buttons[pos - 1].transform.localScale = Vector3.one;
                    }
                }
                else if (!(pos + 1).Equals(maxPos + 1))
                {
                    if (!buttons[pos + 1].transform.localScale.Equals(Vector3.one))
                    {
                        buttons[pos + 1].transform.localScale = Vector3.one;
                    }
                }
            }
        }


        /// <summary>
        /// Runs a short button delay on the menu buttons.
        /// </summary>
        private IEnumerator ButtonDelay()
        {
            isCoR = true;
            yield return new WaitForSeconds(.3f);
            isCoR = false;
        }
    }
}