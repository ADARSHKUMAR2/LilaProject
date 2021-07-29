using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunView : MonoBehaviour
{
    [SerializeField] private Image _gunImage;
    [SerializeField] private Text _gunName;
    [SerializeField] private Text _gunAmmo;
    [SerializeField] private Button _weaponSelectButton;
    public WeaponData _weaponData { private set; get; }
    public int ammo { private set; get; }
    public void SetData(WeaponData weaponData)
    {
        _weaponData = weaponData;
        _gunImage = weaponData.weaponImage;
        _gunName.text = weaponData.name;
        UpdateAmmo(_weaponData.magazineSize);
    }

    public void UpdateAmmo(int shotBullets)
    {
        _gunAmmo.text = $"{shotBullets}/{_weaponData.magazineSize}";
        ammo = shotBullets;
    }
    private void OnEnable()
    {
        AddListener();
    }

    private void AddListener()
    {
        _weaponSelectButton.onClick.AddListener(SwitchWeapon);
    }

    private void SwitchWeapon()
    {
        GunsManager.Instance.UpdateHUD();
        GetComponent<Image>().color = Color.black;
        GunsManager.Instance.SetWeaponData(_weaponData);
    }

    private void OnDisable()
    {
        RemoveListener();
    }

    private void RemoveListener()
    {
        _weaponSelectButton.onClick.RemoveListener(SwitchWeapon);
    }
}
