using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
  [SerializeField] float shrinkSpeed = 0.025f;
  void Update()
  {
    if (transform.localScale.x > 0.5f)
    {
      transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, 0) * Time.deltaTime;
    }
  }
}
