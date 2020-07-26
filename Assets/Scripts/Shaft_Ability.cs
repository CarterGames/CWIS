using System.Collections;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(ParticleSystem))]
    public class Shaft_Ability : MonoBehaviour
    {
        public GameManager.Ranks currentRank;
        [SerializeField] private FlickerButton flicker;
        private int timesUsed = 0;

        private bool isCoR = false;
        private ParticleSystem ps;
        private CapsuleCollider cc;
        [SerializeField] private CWIS_Controller.Controller thisControl;
        private CWIS_Controller control;

        private int[] rankUpRequirements;

        public float duration = 1.5f;
        public float size = 1;

        private bool useAbility = false;
        public bool canUseAbilty = true;

        internal float cooldown = 0;
        public float cooldownStart = 10;

        private GameManager gm;


        private void Start()
        {
            rankUpRequirements = new int[6]
            {
            Random.Range(1, 2),
            Random.Range(3, 4),
            Random.Range(5, 7),
            Random.Range(9, 11),
            Random.Range(13, 16),
            Random.Range(20, 25)
            };

            ps = GetComponent<ParticleSystem>();
            cc = GetComponent<CapsuleCollider>();
            gm = FindObjectOfType<GameManager>();
            control = FindObjectOfType<CWIS_Controller>();
            var em = ps.emission;
            em.enabled = false;
        }


        private void Update()
        {
            if ((Input.GetMouseButton(0)) && canUseAbilty)
            {
                if (control.activeTurret == thisControl)
                {
                    useAbility = true;
                }
            }

            if (useAbility && !isCoR && canUseAbilty)
            {
                var main = ps.main;
                main.duration = duration;
                var em = ps.emission;
                em.enabled = true;
                StartCoroutine(DelayShafts());
            }

            if (!canUseAbilty)
            {
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime / 2;
                }
                else
                {
                    canUseAbilty = true;
                }
            }
        }


        private IEnumerator DelayShafts()
        {
            timesUsed++;
            CheckForNewRank();
            canUseAbilty = false;
            isCoR = true;
            cc.enabled = true;
            ps.Play();
            yield return new WaitForSeconds(duration);
            ps.Stop();
            cc.enabled = false;
            cooldown = cooldownStart;
            isCoR = false;
            var em = ps.emission;
            em.enabled = false;
            useAbility = false;
        }


        private void CheckForNewRank()
        {
            if (timesUsed == rankUpRequirements[0])
            {
                currentRank = gm.Rankup(GameManager.Ranks.None);
                duration += .5f;
                //flicker.shouldFlicker = true;
            }

            if (timesUsed == rankUpRequirements[1])
            {
                currentRank = gm.Rankup(GameManager.Ranks.Chev1);
                duration += .5f;
                cooldownStart = 9;
                //flicker.shouldFlicker = true;
            }

            if (timesUsed == rankUpRequirements[2])
            {
                currentRank = gm.Rankup(GameManager.Ranks.Chev2);
                duration += .5f;
                cooldownStart = 8;
                //flicker.shouldFlicker = true;
            }

            if (timesUsed == rankUpRequirements[3])
            {
                currentRank = gm.Rankup(GameManager.Ranks.Chev3);
                duration += .5f;
                //flicker.shouldFlicker = true;
            }

            if (timesUsed == rankUpRequirements[4])
            {
                currentRank = gm.Rankup(GameManager.Ranks.Star1);
                duration += .5f;
                cooldownStart = 7;
                //flicker.shouldFlicker = true;
            }

            if (timesUsed == rankUpRequirements[5])
            {
                currentRank = gm.Rankup(GameManager.Ranks.Star2);
                cooldownStart = 6;
                //flicker.shouldFlicker = true;
            }
        }
    }
}