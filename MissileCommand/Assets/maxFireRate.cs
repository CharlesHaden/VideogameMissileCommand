using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maxFireRate : MonoBehaviour
{

    private float powerUpFireRate = 0f;
    private float normalFireRate = 0.5f;
    private float duration = 3f;
    private Shooting cannon;
    
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("vrooom");
        cannon = FindObjectOfType<Shooting>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "explosion")
        {


            
            Destroy(hit.gameObject);
            StartCoroutine(activatePowerUp());
            
            

        }
    }

    public IEnumerator activatePowerUp()
    {
        cannon.setFireRate(powerUpFireRate);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        cannon.setFireRate(normalFireRate);
        Destroy(gameObject);

    }
}
