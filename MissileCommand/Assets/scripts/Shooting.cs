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
    public static int ClipSize = 5;
    private int amunition = ClipSize;
    private int MaxAmmo = 1;
    private Vector3 mousePos;
    private Vector3 objectPos;
    // Update is called once per frame


    void Start()
    {
        amunition = MaxAmmo;
    }
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1")&& nextFire <= Time.time && ClipSize != 0 && amunition != 0)
        {
            
            
            nextFire = Time.time + fireRate;
           
            shoot();
            ClipSize --;
            
         
        }
        else if(Input.GetButtonDown("Fire1") && nextFire <= Time.time && ClipSize == 0 && amunition != 0)
        {
            StartCoroutine(ExampleCoroutine());
            
            
        }
    }

    IEnumerator ExampleCoroutine()
    {
       

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);
        ClipSize = 5;

    }

    void shoot()
    {
        
        GameObject playerMissile = Instantiate(playerMissilePrefab, firePoint.position, firePoint.rotation);
       
    }

    private void setMaxAmmo(int roundAmmo)
    {
        MaxAmmo = roundAmmo;
    }
    
    private int getAmunition()
    {
        return amunition;
    }
}
