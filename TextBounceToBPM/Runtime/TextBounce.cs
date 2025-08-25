using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBounce : MonoBehaviour
{
    [Header("Made by MaskedKitten! Give credits! :D")]
    [Space]
    [Header("Is this a UI Text or 3D Text?")]
    [Space]
    public bool UI;
    public TextMeshProUGUI UIText;
    public TextMeshPro MeshText;
    [Header("BPM is the BPM of the song")]
    public float BPM = 120f;
    [Header("How much the text changes size")]
    public float ScaleAmount = 0.2f;
    [Header("Return Speed is ONLY for Pulse")]
    public float ReturnSpeed = 10f;
    [Space]
    private float OriginalSize;
    private float BeatInterval;
    private float Timer;

    void Start()
    {
        if (UI)
        {
            OriginalSize = UIText.fontSize;
        }
        else
        {
            OriginalSize = MeshText.fontSize;
        }
        BeatInterval = 60f / BPM;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (UI)
        {
            if (Timer >= BeatInterval)
            {
                UIText.fontSize = OriginalSize * (1f + ScaleAmount);
                Timer = 0f;
            }
            else
            {
                UIText.fontSize = Mathf.Lerp(UIText.fontSize, OriginalSize, Time.deltaTime * ReturnSpeed);
            }
        }

        else
        {
            if (Timer >= BeatInterval)
            {
                MeshText.fontSize = OriginalSize * (1f + ScaleAmount);
                Timer = 0f;
            }
            else
            {
                MeshText.fontSize = Mathf.Lerp(MeshText.fontSize, OriginalSize, Time.deltaTime * ReturnSpeed);
            }
        }
    }
}
