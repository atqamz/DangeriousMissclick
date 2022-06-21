using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "DangeriousMissclick/AbilitySO", order = 0)]
public class AbilitySO : ScriptableObject
{
  public new string name;
  public float cooldownTime;
  public float activeTime;

  public virtual void Activate(GameObject parent)
  {
  }

  public virtual void BeginCooldown(GameObject parent)
  {
  }
}
