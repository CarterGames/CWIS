using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.Assets.LeaderboardManager
{
    public class LeaderboardDisplay : MonoBehaviour
    {
        [SerializeField] private LeaderboardData[] data;
        [SerializeField] private Text[] namesTxt;
        [SerializeField] private Text[] scoreTxt;

        public bool updateLeaderboard;
        public bool useOnline;


        private void Start()
        {
            if (useOnline)
            {
                StartCoroutine(GetAllEntries());
            }
            else
            {

            }
        }


        private IEnumerator GetAllEntries()
        {
            List<LeaderboardData> ListData = new List<LeaderboardData>();

            List<string> ReceivedPlayerName = new List<string>();
            List<string> ReceivedPlayerScore = new List<string>();

            UnityWebRequest Request = UnityWebRequest.Get("getscores.php?");

            yield return Request.SendWebRequest();

            if (Request.error == null)
            {
                string[] Values = Request.downloadHandler.text.Split("\r"[0]);

                // only get the top 5 entries
                for (int i = 0; i < Values.Length; i++)
                {
                    if (i % 8 == 0)
                    {
                        ReceivedPlayerName.Add(Values[i]);
                    }
                    else if (i % 8 == 1)
                    {
                        ReceivedPlayerScore.Add(Values[i]);
                    }
                    else
                    {
                        Debug.LogError("Value to added to any list!");
                    }
                }


                for (int i = 0; i < ReceivedPlayerName.Count; i++)
                {
                    LeaderboardData Data = new LeaderboardData();

                    Data.name = ReceivedPlayerName[i];
                    Data.score = float.Parse(ReceivedPlayerScore[i]);

                    ListData.Add(Data);
                }

                data = ListData.ToArray();
            }
        }
    }
}