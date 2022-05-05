using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffNerfSpawner : MonoBehaviour
{
    private float screenMin_X;
    private float screenMax_X;
    private int buffNerfsToSpawn = 5;
    [SerializeField] private float padding = 0.5f;
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private timeFreezeSlowUP timeSlowBuff;
    [SerializeField] private BottomlessClip bottomlessClipBuff;
    [SerializeField] private maxFireRate maxFireRateBuff;
    [SerializeField] private slowPlauerMissile slowPlayerNerf;
    [SerializeField] private blindPlayer blindPlayerNerf;
    private float ySpawnValue;
    void Awake()
    {
        screenMax_X = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
        screenMin_X = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x;

        float randomspawn = Random.Range(screenMin_X, screenMax_X);
        ySpawnValue = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void roundBeginBuffNerf()
    {
        StartCoroutine(EnemySpawn());
    }
    public void setBuffNerfsTospawn(int toSpawn)
    {
        buffNerfsToSpawn = toSpawn;
    }
    IEnumerator EnemySpawn()
    {
        while (buffNerfsToSpawn > 0)
        {
            screenMax_X = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
            screenMin_X = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x;
            float spawnBuffNerf = Random.Range(0, 5);
            float randomspawn = Random.Range(screenMin_X, screenMax_X);
            switch (spawnBuffNerf)
            {
                case 0:
                    Instantiate(timeSlowBuff, new Vector3(randomspawn, ySpawnValue * padding, 0), Quaternion.identity);
                    buffNerfsToSpawn--;
                    break;
                case 1:
                    Instantiate(bottomlessClipBuff, new Vector3(randomspawn, ySpawnValue * padding, 0), Quaternion.identity);
                    buffNerfsToSpawn--;
                    break;
                case 2:
                    Instantiate(maxFireRateBuff, new Vector3(randomspawn, ySpawnValue * padding, 0), Quaternion.identity);
                    buffNerfsToSpawn--;
                    break;
                case 3:
                    Instantiate(slowPlayerNerf, new Vector3(randomspawn, ySpawnValue * padding, 0), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(blindPlayerNerf, new Vector3(randomspawn, ySpawnValue * padding, 0), Quaternion.identity);
                    break;
            }
            
            yield return new WaitForSeconds(delay);
        }
    }

   
}
