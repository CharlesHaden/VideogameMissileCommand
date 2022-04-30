using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject playerMissilePrefab;
    public GameObject targetPrefab;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public static int MaxAmmo = 5;
    private int amunition = MaxAmmo;
    private Vector3 mousePos;
    private Vector3 objectPos;
    // Update is called once per frame

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1")&& nextFire <= Time.time && amunition != 0)
        {
            
            
            nextFire = Time.time + fireRate;
           
            shoot();
            amunition --;
            
         
        }
        else if(Input.GetButtonDown("Fire1") && nextFire <= Time.time && amunition == 0)
        {
            StartCoroutine(ExampleCoroutine());
            
            
        }
    }

    IEnumerator ExampleCoroutine()
    {
       

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);
        amunition = MaxAmmo;

    }

    void shoot()
    {
        
        GameObject playerMissile = Instantiate(playerMissilePrefab, firePoint.position, firePoint.rotation);
       
    }
}
