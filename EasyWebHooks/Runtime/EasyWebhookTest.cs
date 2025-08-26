using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyWebhooks;

public class EasyWebhookTest : MonoBehaviour
{

    [SerializeField] public string Message = "Hello, World!";
    [SerializeField] private string WebhookURL = "Your Webhook URL Here";

    void Start()
    {
        EasyWebhooks.EasyWebhooks.SendWebhook(WebhookURL, Message);
    }
}
