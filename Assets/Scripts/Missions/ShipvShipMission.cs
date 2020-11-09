using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS.Missions
{
    [CreateAssetMenu(fileName = "Ship vs Ship", menuName = "C.W.I.S/Missions/Ship Vs Ship")]
    public class ShipvShipMission : Mission
    {
        public GameObject[] shipsToDestroy;
    }
}