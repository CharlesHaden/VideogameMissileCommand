using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileScript : MonoBehaviour
{
    public GameObject hitEffect;
    [SerializeField] private float speed = 1f;
    private GameObject[] city;
    private Vector3 target;
    private GameController gameController;
    [SerializeField] private int points = 1;
    



    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        speed = gameController.GetMissileSpeed();
        city = GameObject.FindGameObjectsWithTag("City");
        target = city[Random.Range(0, city.Length)].transform.position;
        
    }

    private void Update()
    {
        
        Vector2 directionOfTarget = new Vector2(
            target.x - transform.position.x,
            target.y - transform.position.y
            );
        transform.up = directionOfTarget;
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            destroyMissile();
            
        }

        
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
     
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.tag == "City")
        {
            
            
            destroyMissile();
            Destroy(hit.gameObject);
            

        }
        else if(hit.tag == "explosion")
        {
            
            destroyMissile();
            gameController.addScore(points);
            
        }
    }

    private void destroyMissile()
    {
        
        GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(explosion, 0.50f);
        Destroy(gameObject);
        gameController.removeEnemyMissile();
       
 
        
        
    }

   

}
