using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunSystem : MonoBehaviour
{
    public WeaponData weaponData;
    private int bulletsLeft, bulletsShot;
    private bool shooting, readyToShoot, reloading;
    
    // public Transform attackPoint;
    public RaycastHit rayHit;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private Transform gunHolder;
    [SerializeField] private LayerMask IgnoreLayer;
    private void Awake()
    {
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
        bulletsLeft = weaponData.magazineSize;
        readyToShoot = true;
        SwitchGuns();
    }

    private void SwitchGuns()  
    {
        for (int i = 0; i < gunHolder.childCount; i++)
            gunHolder.GetChild(i).gameObject.SetActive(false);
        
        var gun = gunHolder.Find(weaponData.weapon.name);
        if (gun)
            gun.gameObject.SetActive(true);
        
        //Get the ammo amount previously fired
        bulletsLeft = GunsManager.Instance.GetBulletsFired(weaponData);
    }
    
    private void Update()
    {
        MyInput();

        // text.SetText(bulletsLeft + " / " + magazineSize);
    }
    
    private void MyInput()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < weaponData.magazineSize && !reloading) 
            Reload();

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (weaponData.weaponType == WeaponType.PRIMARY) 
            shooting = Input.GetKey(KeyCode.Mouse0);
        else 
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = weaponData.bulletsPerTap;
            Shoot();
        }
    }
    
    private void Shoot()
    {
        Debug.Log($"Shooting");
        readyToShoot = false;

        //Spread
        // float x = Random.Range(-spread, spread);
        // float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        // Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, weaponData.range,
        ~IgnoreLayer))
        {
            Debug.Log(rayHit.collider.name);
        
            // if (rayHit.collider.CompareTag("Enemy"))
            //     rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
        }

        //ShakeCamera
        // camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        // Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        // Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        GunsManager.Instance.UpdateBulletsShot(bulletsLeft,weaponData);
        Invoke("ResetShot", weaponData.timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", weaponData.timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", weaponData.reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = weaponData.magazineSize;
        reloading = false;
        GunsManager.Instance.UpdateBulletsShot(bulletsLeft,weaponData);
    }
}
