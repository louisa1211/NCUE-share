using System.IO;
using UnityEngine;
using System;


public class ApiKeyManager : MonoBehaviour
{
    private string apiKey;

    private void Start()
    {
        // 设置JSON文件的完整路径
        string jsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".openai", "auth.json");

        // 检查JSON文件是否存在
        if (File.Exists(jsonFilePath))
        {
            // 读取JSON文件内容
            string jsonContent = File.ReadAllText(jsonFilePath);

            // 解析JSON数据
            try
            {
                var json = JsonUtility.FromJson<AuthData>(jsonContent);

                // 获取API密钥
                apiKey = json.api_key;
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error parsing JSON: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("Auth JSON file not found at: " + jsonFilePath);
        }
    }

    // 在需要使用API密钥的地方使用 apiKey 变量
    private void UseApiKey()
    {
        if (!string.IsNullOrEmpty(apiKey))
        {
            // 在这里使用 apiKey 进行API请求
        }
        else
        {
            Debug.LogError("API key is empty or not available.");
        }
    }

    // 定义一个类来反序列化JSON数据
    [System.Serializable]
    private class AuthData
    {
        public string api_key;
    }
}

