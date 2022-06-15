using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] float startingHealth;
  public float currentHealth { get; private set; }
  public bool dead;

  UIGame GameOver;

  AudioPlayer audioPlayer;

  void Awake()
  {
    currentHealth = startingHealth;
    GameOver = FindObjectOfType<UIGame>();
    audioPlayer = FindObjectOfType<AudioPlayer>();
  }

  public void TakeDamage(float damage)
  {
    currentHealth = Mathf.Clamp(currentHealth - damage, 0f, startingHealth);

    if (currentHealth <= 0)
    {
      if (!dead)
      {
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;
        audioPlayer.PlayDyingClip();
        Destroy(gameObject);
        GameOver.ShowGameOverWindow();
      }
    }
  }
}
