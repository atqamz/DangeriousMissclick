using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{
  [SerializeField] float _Speed = 5f;
  Transform _Target;
  Rigidbody2D _Rigidbody;
  Vector2 _Direction;

  void Awake()
  {
    _Rigidbody = GetComponent<Rigidbody2D>();
    GameObject player = GameObject.Find("Antivirus");
    _Target = player.transform;
  }

  void Start()
  {
    if (transform.position.x > _Target.position.x)
    {
      Flip();
    }
  }

  void Update()
  {
    Vector3 latestDir = _Target.position - transform.position;
    float angle = Mathf.Atan2(latestDir.y, latestDir.x) * Mathf.Rad2Deg;
    _Rigidbody.rotation = angle;
    latestDir.Normalize();

    _Direction = latestDir;
  }

  void FixedUpdate()
  {
    MoveCharacter();
  }

  void MoveCharacter()
  {
    _Rigidbody.MovePosition((Vector2)transform.position + (_Direction * _Speed * Time.fixedDeltaTime));
  }

  void Flip()
  {
    transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
  }
}
