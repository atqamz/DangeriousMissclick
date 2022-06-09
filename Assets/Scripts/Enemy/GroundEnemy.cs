using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
  [SerializeField] float _Speed = 5f;
  [SerializeField] Transform _Target;
  Rigidbody2D _Rigidbody;

  void Awake()
  {
    _Rigidbody = GetComponent<Rigidbody2D>();
  }
  void Start()
  {
    if (transform.position.x > _Target.position.x)
    {
      Flip();
    }
  }

  void FixedUpdate()
  {
    MoveCharacter();
  }

  void MoveCharacter()
  {
    _Rigidbody.velocity = new Vector2(_Speed * Time.fixedDeltaTime, _Rigidbody.velocity.y);
  }

  void Flip()
  {
    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    _Speed *= -1;
  }
}
