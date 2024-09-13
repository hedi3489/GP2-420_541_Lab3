using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float chargeSpeed = 10f;
    private float chargeTime = 0f;
    private float maxChargeTime = 5f;
    public float baseBulletSpeed = 10.0f;
    
    void Update()
    {
        // Uncharged shot
        /*if (Input.GetButtonUp("Fire1"))
        {
            // Spawn bullet when Fire1 is released
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }*/

        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0f;
        }

        if (Input.GetButton("Fire1") && chargeTime < maxChargeTime)
        {
            chargeTime += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            
            //chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();
            bulletComp.bulletSpeed = chargeTime * baseBulletSpeed;

        }
    }
}
