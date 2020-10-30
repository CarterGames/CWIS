using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class DummyTarget : Target
    {
        private void Start()
        {
            base.health = 100;
        }
    }
}