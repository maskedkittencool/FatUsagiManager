using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMusic : MonoBehaviour
{
    public AudioSource SongPlayer;

    void OnTriggerEnter(Collider other)
    {
        SongPlayer.volume = 0.15f;
    }

}
