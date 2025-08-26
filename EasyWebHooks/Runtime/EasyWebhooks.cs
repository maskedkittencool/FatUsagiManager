using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyWebhooks
{
    public static class EasyWebhooks
    {
        public static void SendWebhook(string url, string message)
        {
            WebhookData data = new WebhookData { content = message };
            string jsonData = JsonUtility.ToJson(data);
            CoroutineRunner.Instance.StartCoroutine(PostRequest(url, jsonData));
        }

        private static IEnumerator PostRequest(string url, string jsonData)
        {
            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Error sending webhook: {request.error}");
                }
                else
                {
                    Debug.Log("Webhook sent successfully!");
                }
            }
        }

        [System.Serializable]
        private class WebhookData
        {
            public string content;
        }

        private class CoroutineRunner : MonoBehaviour
        {
            private static CoroutineRunner _instance;
            public static CoroutineRunner Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject("CoroutineRunner");
                        _instance = obj.AddComponent<CoroutineRunner>();
                        Object.DontDestroyOnLoad(obj);
                    }
                    return _instance;
                }
            }
        }
    }
}