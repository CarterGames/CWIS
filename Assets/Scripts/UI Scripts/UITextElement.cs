﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class UITextElement : MonoBehaviour
    {
        /// <summary>
        /// Reference to text componenet on this object.
        /// </summary>
        private Text _text;
        private bool isCoR;


        /// <summary>
        /// Unity Awake | sets the text reference up.
        /// </summary>
        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        /// <summary>
        /// Sets the UI text to the inputted value.
        /// </summary>
        /// <param name="value">String | text to display.</param>
        public void SetTextValue(string value)
        {
            _text.text = value;
        }

        /// <summary>
        /// Gets the current text value.
        /// </summary>
        /// <returns>String | The current text.</returns>
        public string GetTextValue()
        {
            return _text.text;
        }


        public void FlashText()
        {
            if (!isCoR)
                StartCoroutine(FlashTextCo());
        }

        private IEnumerator FlashTextCo()
        {
            Color _temp = _text.color;
            isCoR = true;
            _text.color = Color.white;
            yield return new WaitForSeconds(.25f);
            _text.color = _temp;
            isCoR = false;
        }
    }
}