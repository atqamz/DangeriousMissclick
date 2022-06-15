using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{
  [SerializeField] float enemySpeed = 5f;
  [SerializeField] float enemyDamage = 1f;
  [SerializeField] float enemyHealth = 15f;
  Transform enemyTarget;
  Rigidbody2D enemyRb;
  Vector2 enemyDir;

  AudioPlayer audioPlayer;

  void Awake()
  {
    enemyRb = GetComponent<Rigidbody2D>();
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    enemyTarget = player.transform;
    audioPlayer = FindObjectOfType<AudioPlayer>();
  }

  void Start()
  {
    if (transform.position.x > enemyTarget.position.x)
    {
      Flip();
    }
  }

  void Update()
  {
    Vector3 latestDir = enemyTarget.position - transform.position;
    float angle = Mathf.Atan2(latestDir.y, latestDir.x) * Mathf.Rad2Deg;
    enemyRb.rotation = angle;
    latestDir.Normalize();

    enemyDir = latestDir;
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
    else if (other.CompareTag("Bullet"))
    {
      enemyHealth -= other.GetComponent<Bullet>().bulletDamage;
      audioPlayer.PlayHittingClip();
      if (enemyHealth <= 0)
      {
        Destroy(gameObject);
      }
    }
  }

  void MoveCharacter()
  {
    enemyRb.MovePosition((Vector2)transform.position + (enemyDir * enemySpeed * Time.fixedDeltaTime));
  }

  void Flip()
  {
    transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
  }
}
