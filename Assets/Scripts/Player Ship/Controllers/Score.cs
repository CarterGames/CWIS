using UnityEngine;
using CarterGames.Utilities;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private UITextElement[] textElement;
        private int playerScore;

        private void Update()
        {
            if (!textElement[0].GetTextValue().Equals(playerScore.ToString()))
            {
                textElement[0].SetTextValue(playerScore.ToString());
                textElement[0].FlashText();
                textElement[1].SetTextValue(playerScore.ToString());
            }
        }

        public int GetScore()
        {
            return playerScore;
        }

        public void IncrementScore(int value)
        {
            playerScore += value;
        }

        public void DecrementScore(int value)
        {
            playerScore -= value;

            if (playerScore < 0)
            {
                playerScore = 0;
            }
        }
    }
}