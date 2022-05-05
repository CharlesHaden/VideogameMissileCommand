using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    private float screenMin_X;
    private float screenMax_X;
    [SerializeField] private float padding = 0.5f;
    private int missilesToSpawn = 10;
    [SerializeField] private float delay = 0.5f;
    private float ySpawnValue;
    // Start is called before the first frame update
    void Awake()
    {
        screenMax_X = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
        screenMin_X = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x;
        
        float randomspawn = Random.Range(screenMin_X, screenMax_X); 
        ySpawnValue = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0)).y;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void roundBegin()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while(missilesToSpawn > 0)
        {
            screenMax_X = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
            screenMin_X = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x;

            float randomspawn = Random.Range(screenMin_X, screenMax_X);
            

            Instantiate(missilePrefab, new Vector3(randomspawn, ySpawnValue * padding, 0), Quaternion.identity);
            missilesToSpawn--;
            yield return new WaitForSeconds(delay);
        }
    }

    public void SetMissilesToSpawn(int toSpawn)
    {
        missilesToSpawn = toSpawn;  
    }


}
