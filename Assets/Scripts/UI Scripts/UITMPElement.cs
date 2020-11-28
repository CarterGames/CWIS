﻿using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class UITMPElement : MonoBehaviour
    {
        /// <summary>
        /// Reference to text componenet on this object.
        /// </summary>
        private TextMesh _text;

        /// <summary>
        /// Unity Awake | sets the text reference up.
        /// </summary>
        private void Awake()
        {
            _text = GetComponent<TextMesh>();
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
    }
}