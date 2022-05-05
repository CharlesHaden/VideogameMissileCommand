using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private int score = 0;
    private int round = 1;
    private int maxPlayerMissiles = 30;
    private int playerMissilesLeft = 30;
    private int maxEnemyMissilesThisRound = 10;
    private int enemyMissilesLeft = 0;
    private float enemyMissileSpeedMultiplier = 1.5f;
    private float enemyMissileSpeed = 1f;
    private enemyRocketSpawner missileSpawner;
    private BuffNerfSpawner buffNerfSpawner;
    private int leftOverMissileBonus = 0;
    private int leftOverBuildingsBonus = 0;
    private int totalBonus = 0;
    private bool roundOver = false;
    private int buffsNerfs = 4;
    [SerializeField]private float playerMissileSpeed = 1f;
    buildings[] city;
    [SerializeField] private int leftOverMissilePoints = 5;
    [SerializeField] private int leftOverBuildingsPoints = 15;
    [SerializeField] private GameObject endOfRoundPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private TextMeshProUGUI playerMissileText;
    [SerializeField] private TextMeshProUGUI missileBonusText;
    [SerializeField] private TextMeshProUGUI buildingBonusText;
    [SerializeField] private TextMeshProUGUI totalBonusText;
    [SerializeField] private TextMeshProUGUI endOfRoundCountText;
    [SerializeField] private TextMeshProUGUI buffText;
    [SerializeField] private TextMeshProUGUI nerfText;
    [SerializeField] private GameObject blindPanel;


    // Start is called before the first frame update
    void Start()
    {
        
        missileSpawner = FindObjectOfType<enemyRocketSpawner>();
        buffNerfSpawner = FindObjectOfType<BuffNerfSpawner>(); 
        UpdateScore();
        UpdateRound();
        UpdateMissilesLeft();
        RoundStart();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        city = GameObject.FindObjectsOfType<buildings>();
        if (enemyMissilesLeft <= 0 && !roundOver)
        {
            roundOver = true;
            StartCoroutine(roundEnd());
        }
        if(city.Length == 0)
        {
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            SceneManager.LoadScene("Menu");
        }
    }
    public void RoundStart()
    {
        UpdateScore();
        missileSpawner.SetMissilesToSpawn(maxEnemyMissilesThisRound);
        enemyMissilesLeft = maxEnemyMissilesThisRound;
        buffNerfSpawner.setBuffNerfsTospawn(buffsNerfs);
        missileSpawner.roundBegin();
        buffNerfSpawner.roundBeginBuffNerf();
        
    }

    public int GetPlayerMissilesLeft()
    {
         return playerMissilesLeft;
    }

    public void SetPlayerMissilesLeft(int missiles)
    {
        playerMissilesLeft = missiles;
        UpdateMissilesLeft();
    }

    public void addScore(int point)
    {
        score = score + point;
        UpdateScore();
    }
    
    public void removeEnemyMissile()
    {
        enemyMissilesLeft-- ;
    }

    public IEnumerator roundEnd()
    {
        yield return new WaitForSeconds(0.5f);
        endOfRoundPanel.SetActive(true);
        city = GameObject.FindObjectsOfType<buildings>();
        leftOverMissileBonus = playerMissilesLeft * leftOverMissilePoints;
        leftOverBuildingsBonus = city.Length * leftOverBuildingsPoints;
        totalBonus = leftOverBuildingsBonus + leftOverMissileBonus;

        missileBonusText.text = "Ammo Left Bonus: " + leftOverMissileBonus;
        buildingBonusText.text = "Buildings Survived Bonus: " + leftOverBuildingsBonus;
        totalBonusText.text = "Total: " + totalBonus;
        score += totalBonus;

        endOfRoundCountText.text = "5";
        yield return new WaitForSeconds(1f);
        endOfRoundCountText.text = "4";
        yield return new WaitForSeconds(1f);
        endOfRoundCountText.text = "3";
        yield return new WaitForSeconds(1f);
        endOfRoundCountText.text = "2";
        yield return new WaitForSeconds(1f);
        endOfRoundCountText.text = "1";
        yield return new WaitForSeconds(1f);
        RoundStart();

        // update for round
        this.GetComponent<gameEventManager>().roundAchieved();
        round++;
        if (round > 1)
        {

        }
        playerMissilesLeft = maxPlayerMissiles;
        IncreaseMissileSpeed(enemyMissileSpeed);
        UpdateRound();
        UpdateMissilesLeft();
        endOfRoundPanel.SetActive(false);
        roundOver = false;
    }




    public void UpdateRound()
    {
        roundText.text = "Round: " + round;
    }
    public void UpdateMissilesLeft()
    {
        playerMissileText.text = "Ammo: " + playerMissilesLeft;
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public float IncreaseMissileSpeed(float speed)
    {
        enemyMissileSpeed = speed * enemyMissileSpeedMultiplier;
        return enemyMissileSpeed;
    }
    public float GetMissileSpeed()
    {
        return enemyMissileSpeed;
    }
    public void SetMissileSpeed(float speed)
    {
        enemyMissileSpeed = speed;
    }

    public void ShowBuff(string buffType)
    {
        buffText.text = buffType;
        buffText.gameObject.SetActive(true);
    }
    public void hideBuff()
    {
        
        buffText.gameObject.SetActive(false);
    }
    public bool GetRoundOver()
    {
        return roundOver;
    }
    
    public float getPlayerMissileSpeed()
    {
        return playerMissileSpeed;
    }
    public void setPlayerMissileSpeed(float speed)
    {
        playerMissileSpeed = speed;
    }
    public void ShowNerf(string nerfType)
    {
        nerfText.text = nerfType;
        nerfText.gameObject.SetActive(true);
    }
    public void hideNerf()
    {

        nerfText.gameObject.SetActive(false);
    }
    public void ShowBlind()
    {
        blindPanel.SetActive(true);
    }
    public void hideBlind()
    {

        blindPanel.SetActive(false);
    }


}
