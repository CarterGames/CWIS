using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class MissileLauncher : Turret
    {
        [Header("Missile Launcher Custom Settings")]
        [SerializeField] private GameObject[] missileSpawnLocations;
        [SerializeField] private int lastSiloUsed = 0;

        private GameObject target;
        private LineRenderer lr;
        private MissileTargeting missileTargeting;
        private ParticleSystem particles;


        private new void Start()
        {
            base.Start();

            lr = GetComponent<LineRenderer>();
            lr.enabled = false;

            missileTargeting = GetComponent<MissileTargeting>();
            particles = GetComponentInChildren<ParticleSystem>();
        }


        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                if (!lr.enabled)
                    lr.enabled = true;

                if (!missileTargeting.GetActiveStatus())
                    missileTargeting.EnableTargeting();

                // Shoot bullet...
                if (actions.Weapons.Fire.phase.Equals(InputActionPhase.Performed))
                {
                    if (!shouldFireMissile && canShoot && target.GetComponent<RadarIcons>())
                    {
                        target.GetComponent<RadarIcons>().SetIconColour(Color.white);
                        FireMissile(missileSpawnLocations[lastSiloUsed].transform, target, fireRate, particles);
                        UpdateSiloNumber();
                    }
                }

                base.Update();
            }
            else
            {
                if (lr.enabled)
                    lr.enabled = false;

                if (missileTargeting.GetActiveStatus())
                    missileTargeting.DisableTargeting();
            }
        }


        /// <summary>
        /// Updates the silo number used.
        /// </summary>
        private void UpdateSiloNumber()
        {
            if ((lastSiloUsed + 1).Equals(missileSpawnLocations.Length))
                lastSiloUsed = 0;
            else
                lastSiloUsed++;
        }


        /// <summary>
        /// Sets the target for the missile and updates the radar icon colour to match.
        /// </summary>
        /// <param name="value">Target GameObject</param>
        public void SetTarget(GameObject value)
        {
            if (target && target.GetComponent<RadarIcons>())
                target.GetComponent<RadarIcons>().SetIconColour(Color.green);

            target = value;

            if (target && target.GetComponent<RadarIcons>())
                target.GetComponent<RadarIcons>().SetIconColour(Color.red);
        }
    }
}