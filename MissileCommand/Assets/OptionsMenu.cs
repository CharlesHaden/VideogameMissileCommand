using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI usernameText;
    [SerializeField] TMP_InputField usernameInputText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        usernameText.text = "User: "+ PlayerPrefs.GetString("Username");
    }
    public void saveUsername()
    {
        PlayerPrefs.SetString("Username", usernameInputText.text);

    }
}

