using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicShuffle : MonoBehaviour
{
    // Don't claim this script as your own!
    private int lastIndex = -1;
    [Header("SCRIPT MADE BY MASKEDKITTEN!")]
    [Header("Time between songs")]
    public float MinSeconds = 30;
    public float MaxSeconds = 120;
    [Header("Audio player")]
    public AudioSource SongPlayer;
    public AudioClip[] Songs;
    [Header("Show whats playing")]
    public bool ShowWhatsPlaying = true;
    public TextMeshPro TextToShowSong;
    private bool MusicOn = true;

    public void MusicConfig(bool state)
    {
        MusicOn = state;
        Debug.Log("MusicConfig is " +  state);
    }

    public AudioClip GetRandomClip()
    {
        if (Songs.Length == 0) return null;
        if (Songs.Length == 1) return Songs[0];

        int newIndex;
        do
        {
            int max = (Songs.Length);
            newIndex = Random.Range(0, max);
        } while (newIndex == lastIndex);

        lastIndex = newIndex;
        return Songs[newIndex];
    }

    void Start()
    {
        StartCoroutine(StartMusic());
    }

    IEnumerator StartMusic()
    {
        while (true)
        {
                AudioClip song = GetRandomClip();
                GetRandomClip();
                PlayMusic();
                float cooldown = Random.Range(MinSeconds, MaxSeconds);
                yield return new WaitForSeconds(song.length);
                yield return new WaitForSeconds(cooldown);
        }

    }
    void PlayMusic()
    {
            AudioClip song = GetRandomClip();
            SongPlayer.PlayOneShot(song);
            if (ShowWhatsPlaying)
            {
                TextToShowSong.text = song.name;
            }
    }
}
