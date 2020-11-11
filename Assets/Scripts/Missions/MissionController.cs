using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Missions
{
    public enum MissionTypes { SearchAndDestroy, DefendTarget, ShipvShip };

    public class MissionController : MonoBehaviour
    {
        // Standard Mission Stuff
        [SerializeField] private Mission activeMission;
        private MissionTypes missionType;
        private string missionTitle;
        private string missionDesc;
        private int missionDiff;
        private bool hasWonMission;
        private bool hasLostMission;

        // Search N Destroy
        private SnDMission sd_ActiveMission;
        private int sd_TargetsDestroyed;
        private int sd_minAmountToWin;
        private GameObject[] sd_TargetsToDestroy;


        // Defend target
        private DefendTargetMission dt_ActiveMission;
        private float dt_TimeDefendedFor;
        private int dt_TimeToDefendFor;
        private GameObject dt_TargetToDefend;


        // Ship v Ship
        private ShipvShipMission svs_ActiveMission;
        private int svs_ShipsDestroyed;
        private GameObject[] svs_ShipsToDestroy;




        private void Start()
        {
            MissionSetup();

            switch (missionType)
            {
                case MissionTypes.SearchAndDestroy:

                    SearchDestroyMissionSetup();

                    break;
                case MissionTypes.DefendTarget:

                    DefendTargetSetup();

                    break;
                case MissionTypes.ShipvShip:

                    ShipVShipSetup();

                    break;
                default:
                    break;
            }
        }

 
        private void Update()
        {
            if (!hasLostMission && !hasWonMission)
            {
                switch (missionType)
                {
                    case MissionTypes.SearchAndDestroy:

                        SearchDestroyMissionRuntime();

                        break;
                    case MissionTypes.DefendTarget:

                        DefendTargetMissionRuntime();

                        break;
                    case MissionTypes.ShipvShip:

                        ShipVShipRuntime();

                        break;
                    default:
                        break;
                }
            }
        }



        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sets the mission up on the mission controller.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void MissionSetup()
        {
            missionType = activeMission.type;
            hasWonMission = false;
            hasLostMission = false;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sets up the specific mission type ready to go.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void SearchDestroyMissionSetup()
        {
            sd_TargetsDestroyed = 0;
            sd_minAmountToWin = sd_ActiveMission.minNeededToWin;
            sd_TargetsToDestroy = sd_ActiveMission.targetsToDestroy;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sets up the defend target mission.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void DefendTargetSetup()
        {
            dt_TimeDefendedFor = 0f;
            dt_TimeToDefendFor = dt_ActiveMission.timeToDefendFor;
            dt_TargetToDefend = dt_ActiveMission.targetToDefend;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sets up the Ship v Ship mission type.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void ShipVShipSetup()
        {
            svs_ShipsToDestroy = svs_ActiveMission.shipsToDestroy;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the search and destory mission.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void SearchDestroyMissionRuntime()
        {
            if (sd_TargetsDestroyed >= sd_minAmountToWin)
            {
                hasWonMission = true;
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Adds one to the destroyed targets.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        public void SearchDestroyTargetDestroyed()
        {
            sd_TargetsDestroyed++;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the main checks to a defend target mission.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void DefendTargetMissionRuntime()
        {
            if (dt_TargetToDefend.activeInHierarchy)
            {
                if (dt_TimeDefendedFor < dt_TimeToDefendFor)
                {
                    hasWonMission = true;
                }
                else
                {
                    dt_TimeDefendedFor += Time.deltaTime;
                }
            }
            else
            {
                hasLostMission = true;
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the main checks for a ship v ship battle mission.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        private void ShipVShipRuntime()
        {
            if (svs_ShipsDestroyed.Equals(svs_ShipsToDestroy.Length))
            {
                hasWonMission = true;
            }
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Increments the amount of ships destroyed.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------
        public void ShipDestroyed()
        {
            svs_ShipsDestroyed++;
        }
    }
}