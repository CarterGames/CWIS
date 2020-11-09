using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Missions
{
    public enum MissionTypes { SearchAndDestroy, DefendTarget };

    public class MissionController : MonoBehaviour
    {
        private MissionTypes missionType;


        public Mission activeMission;



        private void Start()
        {
            MissionSetup();
        }


        private void Update()
        {

        }



        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sets the mission up on the mission controller.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void MissionSetup()
        {
            missionType = activeMission.type;
        }
    }
}