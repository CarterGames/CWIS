using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] weaponUI = default;
        private CIC cic;
        private ShipWeapons shipWeapon;


        private void Start()
        {
            cic = GameObject.FindGameObjectWithTag("CIC").GetComponent<CIC>();

            weaponUI[0].SetActive(true);
            shipWeapon = cic.activeCICWeapon;

            WeaponUISetup();
        }


        private void Update()
        {
            if (!cic.activeCICWeapon.Equals(shipWeapon))
                ChangeActiveWeaponUI();
        }


        /// <summary>
        /// Changes the weapon ui without doing a for loop.
        /// </summary>
        private void ChangeActiveWeaponUI()
        {
            int _pos = (int)cic.activeCICWeapon;
            int _lastPos = (int)shipWeapon;
            weaponUI[_pos].SetActive(true);
            weaponUI[_lastPos].SetActive(false);
            shipWeapon = cic.activeCICWeapon;
        }


        /// <summary>
        /// Sets up the weapon UI so the references work. 
        /// </summary>
        private void WeaponUISetup()
        {
            for (int i = 0; i < weaponUI.Length; i++)
            {
                if (!i.Equals(0))
                    weaponUI[i].SetActive(false);
            }
        }
    }
}