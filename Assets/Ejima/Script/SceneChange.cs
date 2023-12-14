using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeButtonMoveAfter()
    {
        SceneManager.LoadScene("SoundTestSceneAfter");
    }

    public void ChangeButtonMoveOrigin()
    {
        SceneManager.LoadScene("SoundTestScene");
    }
}
