using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkCoin : MonoBehaviour
{
    public AudioSource AudioPlayer;
    private void OnTriggerEnter(Collider other)
    {
        AudioPlayer.Play();
    }
}
