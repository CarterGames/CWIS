using UnityEngine;
using UnityEngine.UI;

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
    }
}