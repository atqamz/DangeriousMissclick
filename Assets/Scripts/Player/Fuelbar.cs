using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuelbar : MonoBehaviour
{
  Vector3 localScale;

  PlayerMovement player;

  SpriteRenderer fuelbarSprite;
  [SerializeField] Color32 fuelbarReadyColor = new Color32(255, 255, 255, 255);
  [SerializeField] Color32 fuelbarReloadColor = new Color32(255, 255, 255, 255);

  void Awake()
  {
    player = GetComponentInParent<PlayerMovement>();
    fuelbarSprite = GetComponent<SpriteRenderer>();
  }

  void Start()
  {
    localScale = transform.localScale;
  }

  void Update()
  {
    localScale.x = player.fuelAmount / 50f;
    transform.localScale = localScale;

    if (!player.GetIsRegen())
    {
      fuelbarSprite.color = fuelbarReadyColor;
    }
    else
    {
      fuelbarSprite.color = fuelbarReloadColor;
    }
  }
}
