using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM_CallSoundM : MonoBehaviour
{
    public SoundManager.BGM_Type selectBGM;
    public void PlayBGMBtn()
    {
        SoundManager.instance.PlayBGM(selectBGM);
    }
}
