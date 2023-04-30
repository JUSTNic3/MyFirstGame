using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource playAudio;
    private void OnTriggerEnter(Collider other)
    {
        playAudio.Play();
    }
}
