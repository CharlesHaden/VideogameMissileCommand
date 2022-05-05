using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BottomlessClip : MonoBehaviour
{

    private int infiniteClip = 1000000;
    private float duration = 6f;
    private int previousClip = 0;
    private Shooting cannon;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
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
        gameController.ShowBuff("BOTTOMLESS CLIP");
        yield return new WaitForSeconds(1f);
        gameController.hideBuff();
        previousClip = cannon.GetClip();
        cannon.SetClip(infiniteClip);
        yield return new WaitForSeconds(duration);
        cannon.SetClip(previousClip);
        Destroy(gameObject);

    }
}
