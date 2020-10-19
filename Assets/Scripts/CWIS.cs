using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CarterGames.CWIS
{
    public class CWIS : Turret
    {
        private new void Start()
        {
            base.Start();
        }

        private void Update()
        {
            transform.localRotation = base.RotateToMousePos();

            // Shoot bullet...
            if (actions.Weapons.Fire.triggered)
            {
                Debug.Log("fire");
                FireBullet();
            }
        }
    }
}