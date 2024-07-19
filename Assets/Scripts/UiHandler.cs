using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    public InputField inputNameField;
    public Text showBest;
    // Start is called before the first frame update
    void Start()
    {
        showBest.text = "Best Score:" + DataManager.Instance.GetName() + ":" + DataManager.Instance.GetBestScore();
        Debug.Log(showBest.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        if (inputNameField != null)
        {
            DataManager.Instance.SetName(inputNameField.text);
            Debug.Log(inputNameField.text);
        }
        
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
