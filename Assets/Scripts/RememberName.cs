using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberName : MonoBehaviour
{
    public static RememberName Instance;
    public static string highestName, userName;
    public static int highestScore;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
