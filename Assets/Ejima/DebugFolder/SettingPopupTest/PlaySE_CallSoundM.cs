using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE_CallSoundM : MonoBehaviour
{
    public void PlaySEBtn()
    {
        SoundManager.instance.PlaySE(SoundManager.SE_Type.KANAGAWAKENKEISHOTOTSU);
    }
}
