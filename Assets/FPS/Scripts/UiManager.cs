using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
 
    public class UiManager : SingletonBase<UiManager>
    {
        [SerializeField] private WeaponSelectionScreen _weaponSelection;

        public void CheckGunsLimit(WeaponType weaponType)
        {
            _weaponSelection.CheckMaxGunsChosen(weaponType);
        }
    }
   
}