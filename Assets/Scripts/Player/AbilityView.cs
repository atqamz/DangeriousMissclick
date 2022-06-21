using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
  AbilityHolder abilityHolder;
  [SerializeField] Image DamagePlusImage;
  [SerializeField] Image BulletPlusImage;
  [SerializeField] Image FreezeImage;

  void Awake()
  {
    abilityHolder = FindObjectOfType<AbilityHolder>();
  }
  void Update()
  {
    if (abilityHolder.enabled)
      DamagePlusImage.color = new Color(DamagePlusImage.color.r, DamagePlusImage.color.g, DamagePlusImage.color.b, 1);
  }
}
