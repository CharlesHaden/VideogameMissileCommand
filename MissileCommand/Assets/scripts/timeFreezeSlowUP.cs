using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timeFreezeSlowUP : MonoBehaviour
{
    // Start is called before the first frame update

    private float duration = 6f;
    private float slowSpeed = 0.3f;
    private float normalSpeed = 0;
    private GameController gameController;
    
    void Start()
    {
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
        gameController.ShowBuff("SLOW TIME");
        yield return new WaitForSeconds(1f);
        gameController.hideBuff();
        normalSpeed = gameController.GetMissileSpeed();
        gameController.SetMissileSpeed(slowSpeed);
        yield return new WaitForSeconds(duration);
        gameController.SetMissileSpeed(normalSpeed);
        Destroy(gameObject);

    }
}
