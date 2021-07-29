using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsInfo : SingletonBase<WeaponsInfo>
{
    public WeaponData[] weaponDatas;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
