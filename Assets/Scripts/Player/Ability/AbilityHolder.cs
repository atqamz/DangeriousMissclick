using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
  public AbilitySO ability;
  float cooldownTime;
  float activeTime;

  enum abilityState
  {
    ready,
    active,
    cooldown
  }

  abilityState state = abilityState.ready;

  void Update()
  {
    switch (state)
    {
      case abilityState.ready:
        ability.Activate(gameObject);
        state = abilityState.active;
        activeTime = ability.activeTime;
        break;

      case abilityState.active:
        if (activeTime > 0)
        {
          activeTime -= Time.deltaTime;
        }
        else
        {
          state = abilityState.cooldown;
          cooldownTime = ability.cooldownTime;
        }
        break;

      case abilityState.cooldown:
        if (cooldownTime > 0)
        {
          cooldownTime -= Time.deltaTime;
        }
        else
        {
          state = abilityState.ready;
        }
        break;

      default:
        break;
    }
  }
}
