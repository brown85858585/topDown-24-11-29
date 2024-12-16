using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthCounter : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    // private
    private int _health;
    private int _maxHealth;
    private void Start()
    {
        StartMaker();
    }
    private void StartMaker(){
        // Когда добавятся юниты, будем тащить суда значения проверяя владельца по тегу
        _health = GameConstReader.gameConstants.player.playerHealth;
        _maxHealth = _health;
        healthText.text = _health.ToString();
    }
    public void TakeDamage(int _damage){
        if (_damage > 0){
            _health -= _damage;
            healthText.text = _health.ToString();
        }
        if (_health <= 0) {
            LooseLife ();
        }
        // Debug.Log("_health " + _health);
    }
    private void LooseLife () {
        // Перезапуск игры
        Debug.Log("gameOver");
    }
}
// https://t.me/natureModelSpb
