using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarterGames.CWIS
{
    public class CWIS : Turret
    {
        private void Update()
        {
            transform.localRotation = base.RotateToMousePos(-180f, 0f);
        }
    }
}