using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform firePoint;          // vacío en la punta del arma
    public GameObject bulletPrefab;      // arrastra aquí tu Bullet
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
    void Shoot()
    {
        //playerAnimator.SetTrigger("Shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
