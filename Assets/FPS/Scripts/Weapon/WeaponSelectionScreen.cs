using System;
using System.Collections;
using System.Collections.Generic;
using Adarsh.Poolsystem;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionScreen : MonoBehaviour
{
    [SerializeField] private Transform _gridParent;
    [SerializeField] private WeaponData[] _allWeapons;
    [SerializeField] private GunsUI _gunsImagePrefab;
    private ISimplePooler gunsPool;
    [SerializeField] private int maxPrimaryGuns=2;
    [SerializeField] private int maxSecondaryGuns=1;
    public int primaryGunsCount {private set; get; }
    public int secondaryGunsCount {private set; get; }
    private List<GunsUI> allGuns;
    [SerializeField] private Text _primaryGunsText;
    [SerializeField] private Text _secondaryGunsText;
    
    private void Start()
    {
        primaryGunsCount = secondaryGunsCount = 0;
        allGuns= new List<GunsUI>();
        gunsPool = new SimplePooler(_gunsImagePrefab.gameObject, 5, _gridParent);
        DisplayWeapons();
    }

    private void DisplayWeapons()
    {
        foreach (var weapon in _allWeapons)
        {
            var gun = gunsPool.GetObject<GunsUI>(false);
            gun.SetWeaponDetails(weapon);
            gun.gameObject.SetActive(true);
            allGuns.Add(gun);
        }
    }

    public bool CanSelectWeapon()
    {
        if (primaryGunsCount > maxPrimaryGuns)
            return false;
        else
            return true;
    }
    
    public void UpdateWeaponCount(WeaponType weaponType,bool isSelected)
    {
        if (weaponType == WeaponType.PRIMARY)
        {
            if (isSelected)
                primaryGunsCount++;
            else
                primaryGunsCount--;
            
            _primaryGunsText.text = $"Primary Guns - {primaryGunsCount}/{maxPrimaryGuns}";
        }
        
        // UpdateCount(WeaponType.PRIMARY,primaryGunsCount,maxPrimaryGuns,isSelected);
    }

    private void UpdateCount(WeaponType weaponType, int gunCount, int maxLimit, bool isSelected)
    {
        
    }
}
