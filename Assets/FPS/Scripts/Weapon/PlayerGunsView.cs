using System;
using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

public class PlayerGunsView : MonoBehaviour
{
    private List<int> playerGunsId;
    private void Start()
    {
        ShowPlayerGuns();
    }

    private void ShowPlayerGuns()
    {
        playerGunsId = new List<int>();
        playerGunsId = UiManager.Instance.userGunsId;
        Debug.Log($"Guns count - {playerGunsId.Count} ");
        CheckGunNames();
    }

    private void CheckGunNames()
    {
        foreach (var weapon in WeaponsInfo.Instance.weaponDatas)
        {
            foreach (var weaponid in playerGunsId)
            {
                if(weapon.weaponId == weaponid)
                    Debug.Log($"{weapon.name}");
            }
        }
    }
}
