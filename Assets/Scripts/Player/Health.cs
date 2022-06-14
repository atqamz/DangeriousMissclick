using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] float startingHealth;
  public float currentHealth { get; private set; }
  bool dead;

  void Awake()
  {
    currentHealth = startingHealth;
  }

  public void TakeDamage(float damage)
  {
    currentHealth = Mathf.Clamp(currentHealth - damage, 0f, startingHealth);

    if (currentHealth > 0)
    {

    }
    else
    {
      if (!dead)
      {
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;
        Destroy(gameObject);
      }
    }
  }
}
