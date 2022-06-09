using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float _Speed = 5f;
  [SerializeField] Camera _Camera;
  PlayerInput _Input;
  Vector2 _Movement;
  Vector2 _MousePosition;

  Rigidbody2D _Rigidbody;
  CapsuleCollider2D _BodyCollider;
  BoxCollider2D _FootCollider;

  private void Awake()
  {
    _Input = new PlayerInput();
    _Rigidbody = GetComponent<Rigidbody2D>();
  }

  private void OnEnable()
  {
    _Input.Enable();

    _Input.Gameplay.Movement.performed += OnMovement;
    _Input.Gameplay.Movement.canceled += OnMovement;

    _Input.Gameplay.MousePosition.performed += OnMousePosition;
  }

  private void OnDisable()
  {
    _Input.Disable();
  }

  private void OnMovement(InputAction.CallbackContext context)
  {
    _Movement = context.ReadValue<Vector2>();
  }

  private void OnMousePosition(InputAction.CallbackContext context)
  {
    _MousePosition = _Camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
  }

  private void FixedUpdate()
  {
    _Rigidbody.velocity = new Vector2(_Movement.x, 0) * _Speed;

    GameObject rotatePoint = transform.Find("RotatePoint").gameObject;
    Vector2 direction = _MousePosition - (Vector2)rotatePoint.transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    rotatePoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    GameObject gunImage = rotatePoint.transform.Find("Gun").gameObject;
    if (rotatePoint.transform.rotation.z > 0.7 || rotatePoint.transform.rotation.z < -0.7)
    {

      gunImage.transform.localScale = new Vector3(1, -1, 1);
    }
    else
    {
      gunImage.transform.localScale = new Vector3(1, 1, 1);
    }
  }
}
