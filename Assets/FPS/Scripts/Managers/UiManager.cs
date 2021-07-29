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
        [SerializeField] private AlertPopup  _alertPopup;
        
        public List<int> userGunsId { private set; get; } //can use static also here

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void UpdateGunsCount(WeaponType weaponType,bool isSelected)
        {
            _weaponSelection.UpdateWeaponCount(weaponType,isSelected);
        }

        public bool CanChooseWeapon(WeaponType weaponType)
        {
            return _weaponSelection.CanSelectWeapon(weaponType);
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

        public void SetAlert(string heading,string body,Action OnClose= null)
        {
            _alertPopup.gameObject.SetActive(true);
            _alertPopup.SetDetails(heading,body);
        }
    }
   
}