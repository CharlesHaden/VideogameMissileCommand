using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    private float screenMin_X;
    private float screenMax_X;
    [SerializeField] private float padding = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        screenMax_X = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
        screenMin_X = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x;
        
        float randomspawn = Random.Range(screenMin_X, screenMax_X); 
        float ySpawnvalue = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0)).y;

        Instantiate(missilePrefab, new Vector3(randomspawn, ySpawnvalue*padding, 0), Quaternion.identity);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
