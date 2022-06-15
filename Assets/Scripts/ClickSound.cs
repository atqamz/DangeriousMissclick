using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
  AudioPlayer audioPlayer;

  void Awake()
  {
    audioPlayer = FindObjectOfType<AudioPlayer>();
  }

  public void PlayClickSound()
  {
    audioPlayer.PlayClickClip();
  }
}
