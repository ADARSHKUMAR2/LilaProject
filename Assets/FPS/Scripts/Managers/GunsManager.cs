using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunsManager : SingletonBase<GunsManager>
{
    [SerializeField] private GunSystem gunSystem;
    [SerializeField] private PlayerGunsView playerGunsView;

    public void UpdateHUD()
    {
        foreach (var gunsHud in playerGunsView.playerGuns)
        {
            gunsHud.GetComponent<Image>().color= Color.white;
        }
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        gunSystem.SetWeaponData(weaponData);
    }

    public void UpdateBulletsShot(int amount, WeaponData weaponData)
    {
        playerGunsView.UpdateAmmoForGun(amount,weaponData);
    }

    public int GetBulletsFired(WeaponData weaponData)
    {
        return playerGunsView.GetBulletAmount(weaponData);
    }
}
