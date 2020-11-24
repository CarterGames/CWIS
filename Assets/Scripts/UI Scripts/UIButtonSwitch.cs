using UnityEngine;
using UnityEngine.UI;
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
        [SerializeField] internal GameObject[] buttons;
        [SerializeField] private bool isUD;

        private bool isCoR;
        private Actions action;

        internal bool isUsingController;
        internal int pos;
        internal int maxPos;

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


        public virtual void Start()
        {
            pos = 0;
            maxPos = buttons.Length - 1;
            isCoR = false;
        }


        private void Update()
        {
            isUsingController = IsControllerActive();

            if (isUsingController)
            {
                if (!isCoR)
                {
                    if (isUD)
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
                    else
                    {
                        if (action.Menu.Joystick.ReadValue<Vector2>().x > .1f)
                        {
                            UpdatePos(1);
                        }
                        else if (action.Menu.Joystick.ReadValue<Vector2>().x < -.1f)
                        {
                            UpdatePos(-1);
                        }
                    }

                    if (action.Menu.Accept.phase.Equals(InputActionPhase.Performed))
                    {
                        buttons[pos].GetComponent<Button>().onClick.Invoke();
                        StartCoroutine(ButtonDelay());
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
        /// Updates the position in the menu.
        /// </summary>
        /// <param name="value">value to change to.</param>
        public virtual void UpdatePos(int value)
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

            StartCoroutine(ButtonDelay());
        }

        /// <summary>
        /// Checks to see if a controller (either XB or PS is plugged in).
        /// </summary>
        /// <returns>True if there is a supported controller plugged in, false if not.</returns>
        private bool IsControllerActive()
        {
            if (currentActiveDevice != null)
                if (currentActiveDevice.displayName.Contains("Xbox") || currentActiveDevice.displayName.Contains("Play"))
                    return true;
                else
                    return false;
            else
                return false;
        }


        /// <summary>
        /// Runs a short button delay on the menu buttons.
        /// </summary>
        private IEnumerator ButtonDelay()
        {
            isCoR = true;
            yield return new WaitForSecondsRealtime(.3f);
            isCoR = false;
        }
    }
}