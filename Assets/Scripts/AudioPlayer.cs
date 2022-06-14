using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  void PlayClip(AudioClip clip, float volume)
  {
    if (clip != null)
    {
      Vector3 pos = Camera.main.transform.position;
      AudioSource.PlayClipAtPoint(clip, pos, volume);
    }
  }

  [Header("Shooting")]
  [SerializeField] AudioClip shooting;
  [SerializeField][Range(0f, 1f)] float shootingVolume = 0.5f;

  public void PlayShootingClip()
  {
    PlayClip(shooting, shootingVolume);
  }

  [Header("Hitting")]
  [SerializeField] AudioClip hitting;
  [SerializeField][Range(0f, 1f)] float hittingVolume = 0.5f;

  public void PlayHittingClip()
  {
    PlayClip(hitting, hittingVolume);
  }

  [Header("Dying")]
  [SerializeField] AudioClip dying;
  [SerializeField][Range(0f, 1f)] float dyingVolume = 0.5f;

  public void PlayDyingClip()
  {
    PlayClip(dying, dyingVolume);
  }
}
