using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE_CallSoundM : MonoBehaviour
{
    public SoundManager.BGM_Type type;
    public void PlayBGMBtn()
    {
        SoundManager.instance.PlayBGM(type);
    }
}
