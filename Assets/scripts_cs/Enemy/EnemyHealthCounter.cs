using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealthCounter : MonoBehaviour
{
    public TextMeshProUGUI _healthText;
    private int _health;
    private void Start()
    {
        StartMaker();
    }
    private void StartMaker(){
        // Когда добавятся юниты, будем тащить суда значения проверяя владельца по тегу
        _health = GameConstReader.gameConstants.enemy.enemyHealth;
        _healthText.text = _health.ToString();
    }
    public void TakeDamage(int _damage){
        if (_damage > 0) {
            _health -= _damage;
            _healthText.text = _health.ToString();
        }
        if (_health <= 0) {
            LooseLife ();
        }
    }
    private void LooseLife () {
        Destroy(gameObject);
    }
}
