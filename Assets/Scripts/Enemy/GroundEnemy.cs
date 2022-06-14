using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
  [SerializeField] float enemySpeed = 5f;
  [SerializeField] float enemyDamage = 1f;

  Transform enemyTarget;
  Rigidbody2D enemyRb;

  void Awake()
  {
    enemyRb = GetComponent<Rigidbody2D>();
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    enemyTarget = player.transform;
  }
  void Start()
  {
    if (transform.position.x > enemyTarget.position.x)
    {
      Flip();
    }
  }

  void FixedUpdate()
  {
    MoveCharacter();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      other.GetComponent<Health>().TakeDamage(enemyDamage);
      Destroy(gameObject);
    }
  }

  void MoveCharacter()
  {
    enemyRb.velocity = new Vector2(enemySpeed * Time.fixedDeltaTime, enemyRb.velocity.y);
  }

  void Flip()
  {
    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    enemySpeed *= -1;
  }
}
