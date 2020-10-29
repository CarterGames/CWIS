using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.Utilities
{
    public class OpenURL : MonoBehaviour
    {
        public void OpenCarterGamesWebsite()
        {
            Application.OpenURL("https://carter.games");
        }


        public void OpenCarterGamesTwitter()
        {
            Application.OpenURL("https://twitter.com/CarterGamesUK");
        }


        public void OpenCarterGamesDiscord()
        {
            Application.OpenURL("https://carter.games/discord");
        }


        public void OpenCarterGamesBugReportForm()
        {
            Application.OpenURL("https://forms.gle/jxqJgBAp6sdgee9V8");
        }


        public void OpenCarterGamesItchPageForCWIS()
        {
            Application.OpenURL("https://carter-games.itch.io/cwis");
        }
    }
}