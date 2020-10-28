using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class Chaft : Turret
    {
        [Header("Chaft Custom Settings")]
        [SerializeField] private ParticleSystem[] particles;
        [SerializeField] private bool canUseChaft;
        [SerializeField] private Image timerSlider;

        private float waitTime = 15f;
        private float timer = 15f;
        private bool startTimer;


        private new void Start()
        {
            particles = GetComponentsInChildren<ParticleSystem>();
            canUseChaft = true;

            if (timerSlider)
                timerSlider.fillAmount = 1f;
            

            base.Start();
        }


        private new void Update()
        {
            if (thisTurret.Equals(cic.activeCICWeapon))
            {
                if (actions.Weapons.Fire.phase.Equals(InputActionPhase.Performed))
                {
                    if (canUseChaft && base.ammo > 0)
                    {
                        for (int i = 0; i < particles.Length; i++)
                        {
                            particles[i].Play();
                        }

                        timer = 0f;
                        base.ammo--;
                        startTimer = true;
                    }
                }

                base.Update();
            }

            if (!timerSlider.fillAmount.Equals(NormaliseFloat(timer, 0f, 15f)))
                timerSlider.fillAmount = NormaliseFloat(timer, 0f, 15f);


            if (startTimer)
                RechargeTimer();
        }


        /// <summary>
        /// Runs the chaft recharge timer....
        /// </summary>
        private void RechargeTimer()
        {
            if (timer < waitTime)
            {
                canUseChaft = false;
                timer += Time.deltaTime;
            }
            else if (timer >= waitTime)
            {
                canUseChaft = true;
                startTimer = false;
            }
        }


        /// <summary>
        /// Normilises a float to a value between the min and max value
        /// </summary>
        /// <param name="_toConvert">The value to convert</param>
        /// <param name="_min">The min value</param>
        /// <param name="_max">The max value</param>
        /// <returns>the result of the maths xD</returns>
        private float NormaliseFloat(float _toConvert, float _min, float _max)
        {
            if (_min.Equals(0))
                return _toConvert / _max;
            else
                return _toConvert - _min / _min - _max;
        }
    }
}