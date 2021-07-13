using UnityEngine;
using CarterGames.Utilities;
using TMPro;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text textElement;
        private int playerScore;


        private void Update()
        {
            if (!textElement.text.Equals(playerScore.ToString()))
            {
                textElement.text = playerScore.ToString();
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