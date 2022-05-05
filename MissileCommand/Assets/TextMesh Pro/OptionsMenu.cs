using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] TMP_InputField usernameInputText;
    [SerializeField] private Animator transition;
    void Start()
    {
        usernameText.text = "User: " + PlayerPrefs.GetString("Username");
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        usernameText.text = "User: "+ PlayerPrefs.GetString("Username");
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
    public void saveUsername()
    {
        PlayerPrefs.SetString("Username", usernameInputText.text);

    }

    public void backButton()
    {
        StartCoroutine(wait("Menu"));
        
    }

    private IEnumerator wait(string name)
    {
        transition.SetBool("sceneEnd", true);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(name);
    }
}

