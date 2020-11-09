using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Missions
{
    [CreateAssetMenu(fileName = "Search & Destroy", menuName = "C.W.I.S/Missions/Search n Destory")]
    public class SnDMission : Mission
    {
        public int minNeededToWin;
        public GameObject[] targetsToDestroy;
    }
}