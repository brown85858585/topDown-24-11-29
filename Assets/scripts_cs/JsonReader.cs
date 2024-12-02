using System.IO;
using UnityEngine;

public static class JsonReader
{
    // private static GameConstants gameConstants;

    static JsonReader()
    {
        LoadJson();
    }

    public static void LoadJson()
    {
        // Путь к JSON-файлу
        string path = Path.Combine(Application.dataPath, "JSON", "gameConst.json");

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            Debug.Log(File.ReadAllText(path));

            // gameConstants = JsonUtility.FromJson<GameConstants>(json);
        }
        else
        {
            Debug.LogError($"JSON file not found at path: {path}");
        }
    }

    // public static float GetPlayerSpeed()
    // {
    //     if (gameConstants != null && gameConstants.player != null)
    //     {
    //         return gameConstants.player.playerSpeed;
    //     }
    //     Debug.LogError("Failed to retrieve Player Speed from JSON.");
    //     return 0f;
    // }

    // Здесь можно добавить методы для получения других параметров
}
// Ты вот сечас сидиш и думаешь, что коменты для тебя? Хрен
// Коменты для меня, чтобы я вообще понял, как стандартная шляпа Unity пашет. Спасибо
// https://t.me/natureModelSpb