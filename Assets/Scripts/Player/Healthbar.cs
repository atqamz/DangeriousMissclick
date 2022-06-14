using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
  [SerializeField] Health playerHealth;
  [SerializeField] Image totalHealthbarImage;
  [SerializeField] Image currentHealthbarImage;

  void Start()
  {
    totalHealthbarImage.fillAmount = playerHealth.currentHealth / 5f;
  }

  void Update()
  {
    currentHealthbarImage.fillAmount = playerHealth.currentHealth / 5f;
  }
}
