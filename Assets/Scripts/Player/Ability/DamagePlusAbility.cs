using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "DangeriousMissclick/DamagePlusAbility", order = 0)]
public class DamagePlusAbility : AbilitySO
{
  public float damage;

  public override void Activate(GameObject parent)
  {
    PlayerShoot playerShoot = parent.GetComponent<PlayerShoot>();
    GameObject bullet = playerShoot.bulletPrefab;

    bullet.GetComponent<Bullet>().bulletDamage += damage;
  }
}
