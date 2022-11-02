using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float _delta = 5;
    public GameObject bulletPrefab;
    public Transform firePoint;
 
    void FixedUpdate()
    {
         if (_delta > 0)
        {
            _delta -= Time.fixedDeltaTime;
            if (_delta <= 0)
            {
                Shoot();  
                _delta = 5;
            }
        } 
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
