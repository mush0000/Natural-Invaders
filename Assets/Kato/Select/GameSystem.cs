using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
  public void StartGame()
  {
    Debug.Log("c");
    SceneManager.LoadScene("SelectStageScene");
  }

  public void BuckGame()
  {
    Debug.Log("c");
    SceneManager.LoadScene("TitleScene");
  }

  public void SatoGame()
  {
    Debug.Log("c");
    SceneManager.LoadScene("PreBattle");
  }
  public void FujiedaGame()
  {
    Debug.Log("c");
    SceneManager.LoadScene("farm");
  }

}
