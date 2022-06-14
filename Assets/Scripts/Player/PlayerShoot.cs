using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
  [SerializeField] GameObject bulletPrefab;
  [SerializeField] Transform bulletDir;

  Camera mainCam;

  Vector2 playerMousePos;

  bool canShoot = true;
  [SerializeField] float playerFireRate = 0.3f;

  void Awake()
  {
    mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
  }

  void FixedUpdate()
  {
    PlayerAim();
  }

  public void Aim(InputAction.CallbackContext ctx)
  {
    playerMousePos = mainCam.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
  }

  public void Shoot(InputAction.CallbackContext ctx)
  {
    if (ctx.performed)
    {
      if (!canShoot) return;

      GameObject instance = Instantiate(bulletPrefab, bulletDir.position, bulletDir.rotation, transform.parent);
      instance.SetActive(true);

      StartCoroutine(CanShoot());
    }
  }

  void PlayerAim()
  {
    GameObject rotatePoint = transform.Find("RotatePoint").gameObject;
    GameObject gunImage = rotatePoint.transform.Find("Gun").gameObject;

    Vector2 direction = playerMousePos - (Vector2)rotatePoint.transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    rotatePoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    if (rotatePoint.transform.rotation.z > 0.7 || rotatePoint.transform.rotation.z < -0.7)
    {
      gunImage.transform.localScale = new Vector3(1, -1, 1);
    }
    else
    {
      gunImage.transform.localScale = new Vector3(1, 1, 1);
    }
  }

  IEnumerator CanShoot()
  {
    canShoot = false;
    yield return new WaitForSeconds(playerFireRate);
    canShoot = true;
  }
}
