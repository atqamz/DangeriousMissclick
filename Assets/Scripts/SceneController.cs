using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  [SerializeField] float sceneLoadDelay = 1.5f;
  public bool[] levelUnlocked = { true, false, false };

  void Load(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }

  IEnumerator WaitAndLoad(string sceneName, float delay)
  {
    yield return new WaitForSeconds(delay);
    Load(sceneName);
  }

  public void LoadLevel(int level)
  {
    if (levelUnlocked[level - 1])
    {
      Load("Level" + level);
    }
  }

  public void LoadMainMenu()
  {
    Load("MainMenu");
  }

  public void LoadGameWin()
  {
    StartCoroutine(WaitAndLoad("GameWin", sceneLoadDelay));
  }

  public void LoadGameLose()
  {
    StartCoroutine(WaitAndLoad("GameLose", sceneLoadDelay));
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
