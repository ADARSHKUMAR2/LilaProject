using System;
using System.Collections;
using System.Collections.Generic;
using Adarsh.Poolsystem;
using FPS;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionScreen : MonoBehaviour
{
    [SerializeField] private Transform _gridParent;
    // [SerializeField] private WeaponData[] _allWeapons;
    [SerializeField] private GunsUI _gunsImagePrefab;
    private ISimplePooler gunsPool;
    [SerializeField] private int maxPrimaryGuns=2;
    [SerializeField] private int maxSecondaryGuns=1;
    public int primaryGunsCount {private set; get; }
    public int secondaryGunsCount {private set; get; }
    private List<GunsUI> allGuns;
    private List<int> selectedGunsId;
    [SerializeField] private Text _primaryGunsText;
    [SerializeField] private Text _secondaryGunsText;
    [SerializeField] private Button _nextButton;

    private void OnEnable()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        _nextButton.onClick.AddListener(OpenFPSScene);
    }

    private void OpenFPSScene()
    {
        PassSelectedWeapons();
        if (selectedGunsId.Count > 0)
        {
            UiManager.Instance.OpenScene(1);   
        }
        else
        {
            Debug.Log($"Select at-least 1 weapon");
        }
    }

    private void PassSelectedWeapons()
    {
        selectedGunsId = new List<int>();
        foreach (var guns in allGuns)
        {
            if(guns.GetComponentInChildren<Toggle>().isOn)
                selectedGunsId.Add(guns.weaponId);
        }
        UiManager.Instance.SavePlayerGunsInfo(selectedGunsId);
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void RemoveListeners()
    {
        _nextButton.onClick.RemoveListener(OpenFPSScene);
    }

    private void Start()
    {
        primaryGunsCount = secondaryGunsCount = 0;
        allGuns= new List<GunsUI>();
        gunsPool = new SimplePooler(_gunsImagePrefab.gameObject, 5, _gridParent);
        DisplayWeapons();
    }

    private void DisplayWeapons()
    {
        foreach (var weapon in WeaponsInfo.Instance.weaponDatas)
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
