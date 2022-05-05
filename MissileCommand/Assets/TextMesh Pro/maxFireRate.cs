using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class maxFireRate : MonoBehaviour
{

    private float powerUpFireRate = 0f;
    private float normalFireRate = 0.5f;
    private float duration = 3f;
    private Shooting cannon;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("vrooom");
        cannon = FindObjectOfType<Shooting>();
        gameController = GameObject.FindObjectOfType<GameController>();

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

    private IEnumerator activatePowerUp()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        gameController.ShowBuff("MAX FIRE RATE");
        yield return new WaitForSeconds(1f);
        gameController.hideBuff();
        cannon.setFireRate(powerUpFireRate);
        yield return new WaitForSeconds(duration);
        cannon.setFireRate(normalFireRate);
        Destroy(gameObject);

    }
}
