using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGMCallSoundM : MonoBehaviour
{
    public SoundManager.BGM_Type selectBGM;
    public void PlayBGMBtn()
    {
        SoundManager.instance.PlayBGM(selectBGM);
    }
}
