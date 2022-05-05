using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject playerMissilePrefab;
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public static int ClipSize = 5;
    private Vector3 mousePos;
    private Vector3 objectPos;
    private GameController gameController;
    private int amunition=0;
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] private TextMeshProUGUI reloadingText;
    
    // Update is called once per frame


    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        amunition = gameController.GetPlayerMissilesLeft();
        
    }
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1")&& Time.time > nextFire && ClipSize != 0 && amunition >0)
        {
            
            
            nextFire =  Time.time + fireRate;
           
            shoot();
            ClipSize --;
            amunition --;
            gameController.SetPlayerMissilesLeft(amunition);
         
        }
        else if(Input.GetButtonDown("Fire1") && nextFire < Time.time && ClipSize == 0 && amunition > 0)
        {
            StartCoroutine(ExampleCoroutine());
            
            
        }
        
    }

    IEnumerator ExampleCoroutine()
    {

        reloadingText.gameObject.SetActive(true);
        yield return new WaitForSeconds(reloadTime);
        reloadingText.gameObject.SetActive(false);

        ClipSize = 5;

    }

    void shoot()
    {
        
        GameObject playerMissile = Instantiate(playerMissilePrefab, firePoint.position, firePoint.rotation);
       
    }

    public void setFireRate(float newRate)
    {
        fireRate = newRate;
    }
}
