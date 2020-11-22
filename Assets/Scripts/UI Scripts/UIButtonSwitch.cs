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
        [SerializeField] private GameObject[] buttons;
        [SerializeField] private bool isUD;

        [Header("Scaling Settings")]
        [SerializeField] private bool shouldScaleOnHover;
        [SerializeField] private float scaleFactor;

        [Header("Colour Change Setting")]
        [SerializeField] private bool shouldChangeColour;
        [SerializeField] private Color defaultColour;
        [SerializeField] private Color hoverColour;

        [SerializeField] private int pos;
        [SerializeField] private int maxPos;
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
                {
                    HoverButton();
                    ChangeColour();
                }
        }


        private void Update()
        {
            if (currentActiveDevice != null)
            {
                if (currentActiveDevice.displayName.Contains("Xbox") || currentActiveDevice.displayName.Contains("Play"))
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
                {
                    HoverButton();
                    ChangeColour();
                }

            StartCoroutine(ButtonDelay());
        }


        /// <summary>
        /// Controls the hover factor.
        /// </summary>
        private void HoverButton()
        {
            if (shouldScaleOnHover)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (!i.Equals(pos))
                    {
                        buttons[i].transform.localScale = Vector3.one;
                    }
                    else
                    {
                        buttons[i].transform.localScale = Vector3.one * scaleFactor;
                    }
                }
            }
        }


        private void ChangeColour()
        {
            if (shouldChangeColour)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (!i.Equals(pos))
                    {
                        buttons[i].GetComponent<Image>().color = defaultColour;
                    }
                    else
                    {
                        buttons[i].GetComponent<Image>().color = hoverColour;
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
            yield return new WaitForSecondsRealtime(.3f);
            isCoR = false;
        }
    }
}