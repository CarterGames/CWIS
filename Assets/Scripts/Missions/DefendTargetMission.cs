using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Missions
{
    [CreateAssetMenu(fileName = "Defend Taget", menuName = "C.W.I.S/Missions/Defend Target")]
    public class DefendTargetMission : Mission
    {
        public GameObject targetToDefend;
        public int timeToDefendFor;
    }
}