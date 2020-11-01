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
    public enum MissileSetting { SingleShot, DoubleShot, TripleShot };

    public class MissileLauncher : Turret
    {
        [Header("Missile Launcher Custom Settings")]
        [SerializeField] private MissileSetting setting = MissileSetting.SingleShot;
        [SerializeField] private GameObject[] missileSpawnLocations = default;
        [SerializeField] private int lastSiloUsed = 0;
        [SerializeField] private UIImageElement[] uIImageElements = default;
        [SerializeField] private Color highlightColour;

        private GameObject target;
        private LineRenderer lr;
        private MissileTargeting missileTargeting;
        private ParticleSystem particles;
        private WaitForSeconds wait;

        private Color defaultColour;


        private new void Start()
        {
            base.Start();

            lr = GetComponent<LineRenderer>();
            lr.enabled = false;

            missileTargeting = GetComponent<MissileTargeting>();
            particles = GetComponentInChildren<ParticleSystem>();

            wait = new WaitForSeconds(.2f);

            if (uIImageElements.Length > 0)
                defaultColour = uIImageElements[0].GetImageColour();
        }


        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                if (!lr.enabled)
                    lr.enabled = true;

                if (!missileTargeting.GetActiveStatus())
                    missileTargeting.EnableTargeting();

                // Misisle setting toggle and actions.
                MissileSettingsToggle();
                MissileSettings();

                // Shoot missiles...
                ShootMissiles();

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
        /// Shots the missiles based on the active missile setting.
        /// </summary>
        private void ShootMissiles()
        {
            if (actions.Weapons.Fire.phase.Equals(InputActionPhase.Performed))
            {
                switch (setting)
                {
                    case MissileSetting.SingleShot:

                        if (target)
                        {
                            if (!shouldFireMissile && canShoot && target.GetComponent<RadarIcons>())
                            {
                                target.GetComponent<RadarIcons>().SetIconColour(Color.white);
                                FireMissile(missileSpawnLocations[lastSiloUsed].transform, target, fireRate, particles);
                                UpdateSiloNumber();
                            }
                        }

                        break;
                    case MissileSetting.DoubleShot:

                        if (target)
                        {
                            if (!shouldFireMissile && canShoot && target.GetComponent<RadarIcons>())
                            {
                                if (!isCoR)
                                    StartCoroutine(DoubleShotCo());
                            }
                        }

                        break;
                    case MissileSetting.TripleShot:

                        if (target)
                        {
                            if (!shouldFireMissile && canShoot && target.GetComponent<RadarIcons>())
                            {
                                if (!isCoR)
                                    StartCoroutine(TripleShotCo());
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Toggles the missile attack type.
        /// </summary>
        private void MissileSettingsToggle()
        {
            if (!base.isCoR && base.actions.CIC.ToggleWeaponAbility.phase.Equals(InputActionPhase.Performed))
            {
                if ((setting + 1).Equals(MissileSetting.TripleShot + 1))
                {
                    setting = 0;
                    base.StartInputCooldown(.25f);
                }
                else
                {
                    ++setting;
                    base.StartInputCooldown(.25f);
                }
            }
        }


        /// <summary>
        /// Configures the missile setting.
        /// </summary>
        private void MissileSettings()
        {
            switch (setting)
            {
                case MissileSetting.SingleShot:

                    if (!uIImageElements[0].GetImageColour().Equals(highlightColour))
                        uIImageElements[0].SetImageColour(highlightColour);
                    else if (uIImageElements[1].GetImageColour().Equals(highlightColour))
                        uIImageElements[1].SetImageColour(defaultColour);
                    else if (uIImageElements[2].GetImageColour().Equals(highlightColour))
                        uIImageElements[2].SetImageColour(defaultColour);

                    break;
                case MissileSetting.DoubleShot:

                    if (!uIImageElements[1].GetImageColour().Equals(highlightColour))
                        uIImageElements[1].SetImageColour(highlightColour);
                    else if (uIImageElements[0].GetImageColour().Equals(highlightColour))
                        uIImageElements[0].SetImageColour(defaultColour);
                    else if (uIImageElements[2].GetImageColour().Equals(highlightColour))
                        uIImageElements[2].SetImageColour(defaultColour);

                    break;
                case MissileSetting.TripleShot:

                    if (!uIImageElements[2].GetImageColour().Equals(highlightColour))
                        uIImageElements[2].SetImageColour(highlightColour);
                    else if (uIImageElements[1].GetImageColour().Equals(highlightColour))
                        uIImageElements[1].SetImageColour(defaultColour);
                    else if (uIImageElements[0].GetImageColour().Equals(highlightColour))
                        uIImageElements[0].SetImageColour(defaultColour);

                    break;
                default:
                    break;
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


        /// <summary>
        /// Fires 2 missiles in sequence on call, should only be run is IsCoR is false..
        /// </summary>
        private IEnumerator DoubleShotCo()
        {
            isCoR = true;
            base.canShoot = true;
            FireMissile(missileSpawnLocations[lastSiloUsed].transform, target, fireRate, particles);
            UpdateSiloNumber();
            yield return wait;
            base.canShoot = true;
            FireMissile(missileSpawnLocations[lastSiloUsed].transform, target, fireRate, particles);
            UpdateSiloNumber();
            isCoR = false;
        }


        /// <summary>
        /// Fires 3 missiles in sequence on call, should only be run is IsCoR is false..
        /// </summary>
        private IEnumerator TripleShotCo()
        {
            isCoR = true;
            base.canShoot = true;
            FireMissile(missileSpawnLocations[lastSiloUsed].transform, target, fireRate, particles);
            UpdateSiloNumber();
            yield return wait;
            base.canShoot = true;
            FireMissile(missileSpawnLocations[lastSiloUsed].transform, target, fireRate, particles);
            UpdateSiloNumber();
            yield return wait;
            base.canShoot = true;
            FireMissile(missileSpawnLocations[lastSiloUsed].transform, target, fireRate, particles);
            UpdateSiloNumber();
            isCoR = false;
        }
    }
}