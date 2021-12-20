using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class UIHandler : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string name, user;
        public int score;
    }

    private void Start()
    {
        LoadHighestScoreData();
    }

    private void LoadHighestScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            RememberName.highestName = data.name;
            RememberName.highestScore = data.score;
            RememberName.userName = data.user;

        } else
        {
            RememberName.highestName = String.Empty;
            RememberName.highestScore = 0;
            RememberName.userName = String.Empty;
        }
        GameObject.Find("BestScoreText").GetComponent<TextMeshProUGUI>().text = "Best Score: " + RememberName.highestName + ": " + RememberName.highestScore;
        GameObject.Find("TextBox").GetComponent<TextMeshProUGUI>().text = RememberName.userName;
    }

    public void StartNew()
    {
        RememberName.userName = GameObject.Find("TextBox").GetComponent<TextMeshProUGUI>().text;
        if (RememberName.userName != String.Empty)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
