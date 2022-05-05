using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Acheivements : MonoBehaviour
{
    private float displayTime = 3f;
    [SerializeField] private TextMeshProUGUI acheivementText;
    private int missileFiredCount = 0;
    private bool missileAch = false;
    private int roundCount = 1;
    private bool roundAch = false;
    private int buildingCount = 0;
    private bool buildingAch = false;
    
    void Start()
    {



    }

    private void firedMissileAchiev()
    {
        missileFiredCount++;
        
        if(!missileAch && missileFiredCount == 5)
        {
            
            missileAch = true;
            PlayerPrefs.SetInt("MissileJunkie", 1);
            acheivementText.text = "MISSILE JUNKIE";
            StartCoroutine(DisplayAchievement());

        }
        
    }
    private void buildingDestroyedAchiev()
    {
        buildingCount++;
       
        if (!buildingAch && buildingCount == 3)
        {
            buildingAch = true;
            PlayerPrefs.SetInt("buildingsDestroyed", 1);
            acheivementText.text = "Kaboom";
            StartCoroutine(DisplayAchievement());
        }

    }

    private void roundAchiev()
    {
        roundCount++;
        
        if(!roundAch && roundCount == 2)
        {
            roundAch = true;
            PlayerPrefs.SetInt("ImTooYoung", 1);
            acheivementText.text = "I'm Too Young to Die";
            StartCoroutine(DisplayAchievement());
        }
    }

    void OnEnable()
    {
        
        missileFiredCount = PlayerPrefs.GetInt("countMissile");
        if(PlayerPrefs.GetInt("MissileJunkie") == 1) { missileAch = true;}
        gameEventManager.OnMissileFired += firedMissileAchiev;
        if (PlayerPrefs.GetInt("ImTooYoung") == 1) { roundAch = true; }
        gameEventManager.OnRoundAchieved += roundAchiev;
        if (PlayerPrefs.GetInt("buildingDestroyed") == 1) { buildingAch = true; }
        gameEventManager.OnBuildingDestroyed += buildingDestroyedAchiev;
    }

    void OnDisable()
    {
       PlayerPrefs.SetInt("countMissile", missileFiredCount);
    }

    public IEnumerator DisplayAchievement() {
        acheivementText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        acheivementText.gameObject.SetActive(false);
    }
}

