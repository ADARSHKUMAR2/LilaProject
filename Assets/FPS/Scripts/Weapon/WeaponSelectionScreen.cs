using System;
using System.Collections;
using System.Collections.Generic;
using Adarsh.Poolsystem;
using UnityEngine;

public class WeaponSelectionScreen : MonoBehaviour
{
    [SerializeField] private Transform _gridParent;
    [SerializeField] private WeaponData[] _allWeapons;
    [SerializeField] private GunsUI _gunsImagePrefab;
    private ISimplePooler gunsPool;
    private int maxPrimaryGuns=2 , maxSecondaryGuns=1;
    private int primaryGunsCount, secondaryGunsCount;
    private List<GunsUI> allGuns;
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

    public void CheckMaxGunsChosen(WeaponType weaponType)
    {
        if (weaponType == WeaponType.PRIMARY)
        {
            if (primaryGunsCount <= maxPrimaryGuns)
                primaryGunsCount++;
            else
            {
                Debug.Log($"Max primary limit reached");
            }
        }
        else
        {
            if (secondaryGunsCount <= maxSecondaryGuns)
                secondaryGunsCount++;
            else
            {
                Debug.Log($"Max secondary limit reached");
            }
        }
    }
}
