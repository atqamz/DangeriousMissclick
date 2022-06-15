using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGame : MonoBehaviour
{
  GameObject GameOver;
  SceneController sceneController;
  Health player;
  [SerializeField] GameObject PopUpPrefab;
  [SerializeField] int popUpCount = 5;


  void Awake()
  {
    GameOver = transform.Find("GameOver").gameObject;
    sceneController = FindObjectOfType<SceneController>();
    player = FindObjectOfType<Health>();
  }

  void Update()
  {
    GameObject[] totalPopups = GameObject.FindGameObjectsWithTag("PopUp");
    if (totalPopups.Length == 0 && player.dead)
    {
      sceneController.LoadGameLose();
    }
  }

  public void ShowGameOverWindow()
  {
    GameOver.SetActive(true);

    for (int i = 0; i < popUpCount; i++)
    {
      GameObject PopUp = Instantiate(PopUpPrefab, new Vector3(Random.Range(transform.position.x - 200f, transform.position.x + 200f), Random.Range(transform.position.y - 100f, transform.position.y + 100f), transform.position.z), Quaternion.identity, GameOver.transform);
    }
  }
}
