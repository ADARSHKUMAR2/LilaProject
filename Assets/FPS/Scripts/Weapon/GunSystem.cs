using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public WeaponData weaponData;
    private int bulletsLeft, bulletsShot;
    private bool shooting, readyToShoot, reloading;
    
    // public Transform attackPoint;
    // public RaycastHit rayHit;
    
    private void Awake()
    {
        bulletsLeft = weaponData.magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        // text.SetText(bulletsLeft + " / " + magazineSize);
    }
    
    private void MyInput()
    {
        if (weaponData.weaponType == WeaponType.PRIMARY) 
            shooting = Input.GetKey(KeyCode.Mouse0);
        else 
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < weaponData.magazineSize && !reloading) 
            Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = weaponData.bulletsPerTap;
            Shoot();
        }
    }
    
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        // float x = Random.Range(-spread, spread);
        // float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        // Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        // if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        // {
        //     Debug.Log(rayHit.collider.name);
        //
        //     if (rayHit.collider.CompareTag("Enemy"))
        //         rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
        // }

        //ShakeCamera
        // camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        // Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        // Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", weaponData.timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
            Invoke(nameof(Shoot), weaponData.timeBetweenShots);
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
    }
}
