using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthCounter : MonoBehaviour
{
    private int _health;
    private void Start()
    {
        StartMaker();
    }
    private void StartMaker(){
        // Когда добавятся юниты, будем тащить суда значения проверяя владельца по тегу
        _health = GameConstReader.gameConstants.player.playerHealth;
    }
    public void TakeDamage(int _damage){
        if (_damage > 0){
            _health -= _damage;
        }
    }
}
