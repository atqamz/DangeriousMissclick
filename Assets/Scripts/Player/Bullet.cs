using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] float bulletSpeed = 5f;
  [SerializeField] float bulletLifetime = 5f;

  IEnumerator DestroyBulletAfterTime()
  {
    yield return new WaitForSeconds(bulletLifetime);
    Destroy(gameObject);
  }

  void Start()
  {
    StartCoroutine(DestroyBulletAfterTime());
  }

  void Update()
  {
    transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      Destroy(other.gameObject);
      Destroy(gameObject);
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.tag == "Firewall")
    {
      Destroy(gameObject);
    }
  }
}
