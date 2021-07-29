using System;
using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunsView : MonoBehaviour
{
    private List<int> playerGunsId;
    public List<Button> playerGuns;
    private List<WeaponData> weapons;
    private void Start()
    {
        weapons = new List<WeaponData>();
        // playerGunsView = new List<Button>();
        ShowPlayerGuns();
    }

    private void ShowPlayerGuns()
    {
        playerGunsId = new List<int>();
        playerGunsId = UiManager.Instance.userGunsId;
        DisplayGuns();
    }

    private void DisplayGuns()
    {
        foreach (var weapon in WeaponsInfo.Instance.weaponDatas)
        {
            foreach (var weaponid in playerGunsId)
            {
                if (weapon.weaponId == weaponid)
                {
                    Debug.Log($"{weapon.name}");
                    weapons.Add(weapon);
                }
            }
        }

        ShowInHUD();
    }

    private void ShowInHUD()
    {
        Debug.Log($"{weapons.Count}");
        for (int i = 0; i < weapons.Count; i++)
        {
            playerGuns[i].interactable = true;
            playerGuns[i].GetComponent<GunView>().SetData(weapons[i]);
        }
        GunsManager.Instance.SetWeaponData(weapons[0]);
    }

    public void UpdateAmmoForGun(int amount, WeaponData weaponData)
    {
        var gun = GetActiveWeapon(weaponData);
        gun.UpdateAmmo(amount);
    }

    public int GetBulletAmount(WeaponData weaponData)
    {
        var gun = GetActiveWeapon(weaponData);
        return gun.ammo;
    }

    private GunView GetActiveWeapon(WeaponData weaponData)
    {
        GunView gun = null;
        foreach (var weapon in playerGuns)
        {
            var gunView = weapon.GetComponent<GunView>();
            if (gunView._weaponData.weaponId == weaponData.weaponId)
            {
                gun = gunView;
                return gun;
            }
        }
        return gun;
    }
}
