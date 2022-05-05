using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI usernameText;
    [SerializeField] private Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        usernameText.text = "User: " + PlayerPrefs.GetString("Username");
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        usernameText.text = "User: " + PlayerPrefs.GetString("Username");
    }

    public void playGame()
    {
        
        StartCoroutine(wait("game"));
    }

    public void optionsMenuLoad()
    {
       
        StartCoroutine(wait("optionsScene"));
        
        
    }
    public void quitButton()
    {
        Application.Quit();
        
    }

    private IEnumerator wait(string name)
    {
        transition.SetBool("sceneEnd", true);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(name);
    }
}
