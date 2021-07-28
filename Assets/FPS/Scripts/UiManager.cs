using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
 
    public class UiManager : SingletonBase<UiManager>
    {
        [SerializeField] private WeaponSelectionScreen _weaponSelection;

        public void UpdateGunsCount(WeaponType weaponType,bool isSelected)
        {
            _weaponSelection.UpdateWeaponCount(weaponType,isSelected);
        }

        public bool CanChooseWeapon()
        {
            return _weaponSelection.CanSelectWeapon();
        }
    }
   
}