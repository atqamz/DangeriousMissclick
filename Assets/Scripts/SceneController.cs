using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  [SerializeField] float sceneLoadDelay = 1.5f;
  //   ScoreKeeper scoreKeeper;

  //   void Awake()
  //   {
  //     scoreKeeper = FindObjectOfType<ScoreKeeper>();
  //   }

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
    // scoreKeeper.ResetScore();
    Load("Level" + level);
  }

  public void LoadMainMenu()
  {
    Load("MainMenu");
  }

  public void LoadGameOver()
  {
    StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
