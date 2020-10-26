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
        [SerializeField] private GameObject[] weaponUI;
        private CIC cic;
        private ShipWeapons shipWeapon;


        private void Start()
        {
            cic = GameObject.FindGameObjectWithTag("CIC").GetComponent<CIC>();

            weaponUI[0].SetActive(true);
            shipWeapon = cic.activeCICWeapon;
        }


        private void Update()
        {
            if (!cic.activeCICWeapon.Equals(shipWeapon))
                ChangeActiveWeaponUI();
        }


        private void ChangeActiveWeaponUI()
        {
            int _pos = (int)cic.activeCICWeapon;
            int _lastPos = (int)shipWeapon;
            weaponUI[_pos].SetActive(true);
            weaponUI[_lastPos].SetActive(false);
            shipWeapon = cic.activeCICWeapon;
        }
    }
}