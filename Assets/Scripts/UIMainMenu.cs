using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
  GameObject levelSelectWindow;
  SceneController sceneController;

  void Awake()
  {
    levelSelectWindow = transform.Find("LevelSelectWindow").gameObject;
    sceneController = FindObjectOfType<SceneController>();
  }

  public void ShowLevelSelectWindow()
  {
    levelSelectWindow.SetActive(true);

    bool[] levelUnlocked = sceneController.GetComponent<SceneController>().levelUnlocked;
    for (int i = 1; i <= levelUnlocked.Length; i++)
    {
      GameObject levelButton = levelSelectWindow.transform.Find("Level" + i).gameObject;
      levelButton.GetComponent<Button>().interactable = levelUnlocked[i - 1];
    }
  }
  public void HideLevelSelectWindow()
  {
    levelSelectWindow.SetActive(false);
  }
}
