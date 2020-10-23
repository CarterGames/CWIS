using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class UIImageElement : MonoBehaviour
    {
        /// <summary>
        /// Reference to text componenet on this object.
        /// </summary>
        private Image _image;

        /// <summary>
        /// Unity Awake | sets the image reference up.
        /// </summary>
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        /// <summary>
        /// Sets the UI iaage to the inputted value.
        /// </summary>
        /// <param name="value">Sprite | image to display.</param>
        public void SetImageValue(Sprite value)
        {
            _image.sprite = value;
        }
    }
}