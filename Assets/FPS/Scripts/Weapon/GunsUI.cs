using System;
using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;
using UnityEngine.UI;

public class GunsUI : MonoBehaviour
{
    [SerializeField] private Image _gunImage;
    [SerializeField] private Text _weaponName;
    [SerializeField] private Toggle _gunSelectedToggle;
    private WeaponData _weaponData;
    
    public void SetWeaponDetails(WeaponData weaponData)
    {
        _weaponData = weaponData;
        UpdateGunUI();
    }

    private void UpdateGunUI()
    {
        _gunImage = _weaponData.weaponImage;
        _weaponName.text = _weaponData.name;
    }
    
    private void Start()
    {
        _gunImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        _gunSelectedToggle.onValueChanged.AddListener(delegate
        {
            OnToggleChanged(_gunSelectedToggle);
        });
    }

    private void OnToggleChanged(Toggle toggle)
    {
        UiManager.Instance.CheckGunsLimit(_weaponData.weaponType);
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void RemoveListeners()
    {
        
        _gunSelectedToggle.onValueChanged.RemoveListener(delegate
        {
            OnToggleChanged(_gunSelectedToggle);
        });
    }

}
