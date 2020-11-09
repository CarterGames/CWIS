using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Missions
{
    public abstract class Mission : ScriptableObject
    {
        public MissionTypes type;
        public string missionTitle;
        public string missileDesc;
        public int missionDiff;
    }
}