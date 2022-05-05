using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowPlauerMissile : MonoBehaviour
{
    private missile playerMissile;
    private GameController gameController;
    private float duration = 3f;
    private float speed = 2f;
    private float oldSpeed = 0;
    void Start()
    {
        // Debug.Log("vrooom");
        playerMissile = FindObjectOfType<missile>();
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
        gameController.ShowNerf("BULLET SLOWED");
        yield return new WaitForSeconds(1f);
        gameController.hideNerf();
        oldSpeed = gameController.getPlayerMissileSpeed();
        gameController.setPlayerMissileSpeed(speed);
        yield return new WaitForSeconds(duration);
        gameController.setPlayerMissileSpeed(oldSpeed);
        Destroy(gameObject);

    }
}

