using System.IO;
using UnityEngine;

[System.Serializable]
public class GameConstants {
    // Эта бешаня структура позволяет напрямую обращаться к объектам из JSON
    // вот так Debug.Log(GameConstReader.gameConstants.player.playerSpeed);
    public PlayerConstants player; //environment.bulletSpeed
    public EnvironmentConstants environment;
}

[System.Serializable]
public class PlayerConstants {
    public float playerSpeed;
    public int playerHealth;
}

[System.Serializable]
public class EnvironmentConstants {
    public float bulletSpeed;
}

public static class GameConstReader
{
    public static GameConstants gameConstants;

    static GameConstReader()
    {
        // Эта муть оказывается срабатывает как только ктото обратится к классу
        // И србаотает всего один раз. Замечу что выгляди просто
        LoadJson();
    }

    public static void LoadJson()
    {
        // Путь к JSON-файлу. Пишется так для разных операционок
        // По сути значит корень\JSON\gameConst.json
        string path = Path.Combine(Application.dataPath, "JSON", "gameConst.json");

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            // Прочел весь фал и записал в эту хрень доступную во всем проекте
            // Это считается за доступ малой кровью. Менять код придется только в JSON, здесь и целевом скрипте
            gameConstants = JsonUtility.FromJson<GameConstants>(json);
        }
        else
        {
            // Расчет на дебила. Дайте два. И почему я не проверяю каждый вообще  файл на наличие? Я здоров!
            Debug.LogError($"JSON file not found at path: {path}");
        }
    }
}
// Вы вот сечас сидите и думаете, что коменты для вас? Ошибка
// Коменты для меня, чтобы я вообще понял, как стандартная шляпа Unity пашет. Спасибо
// https://t.me/natureModelSpb