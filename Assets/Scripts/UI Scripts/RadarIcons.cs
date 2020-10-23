using System.Collections.Generic;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class RadarIcons : MonoBehaviour
    {
        private List<SpriteRenderer> spriteRenderers;
        private Color defaultCol;


        private void Awake()
        {
            spriteRenderers = new List<SpriteRenderer>();

            for (int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length; i++)
            {
                spriteRenderers.Add(GetComponentsInChildren<SpriteRenderer>()[i]);
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sets the sprite colour to a new colour
        /// </summary>
        /// <param name="col">Color | Colour to change to.</param>
        /// ------------------------------------------------------------------------------------------------------
        public void SetIconColour(Color col)
        {
            defaultCol = spriteRenderers[0].color;

            for (int i = 0; i < spriteRenderers.Count; i++)
            {
                spriteRenderers[i].color = col;
            }
        }
    }
}