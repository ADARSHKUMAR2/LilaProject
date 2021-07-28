using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WeaponType
{
    PRIMARY,
    SECONDARY
}

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon/NewWeapon")]
public class WeaponData : ScriptableObject
{
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public WeaponType weaponType;
    public GameObject weapon;
    public Image weaponImage;
}
