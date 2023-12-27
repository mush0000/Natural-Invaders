using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgmTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySE(SoundManager.SE_Type.Se35LevelUp);
    }
}
