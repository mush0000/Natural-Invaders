using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDontDestroyOnLoad : MonoBehaviour
{
    public static SettingDontDestroyOnLoad instance;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        CheckInstance();
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
