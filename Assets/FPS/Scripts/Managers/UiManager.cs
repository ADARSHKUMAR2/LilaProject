using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS
{
 
    public class UiManager : SingletonBase<UiManager>
    {
        [SerializeField] private WeaponSelectionScreen _weaponSelection;
        
        public List<int> userGunsId { private set; get; } //can use static also here

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void UpdateGunsCount(WeaponType weaponType,bool isSelected)
        {
            _weaponSelection.UpdateWeaponCount(weaponType,isSelected);
        }

        public bool CanChooseWeapon()
        {
            return _weaponSelection.CanSelectWeapon();
        }

        public void OpenScene(int index)
        {
            SceneManager.LoadScene(index);
            // SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            // SceneManager.UnloadSceneAsync(0);
        }

        public void SavePlayerGunsInfo(List<int> guns)
        {
            userGunsId = guns;
        }
    }
   
}