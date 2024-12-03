using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
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
        _health -= _damage;
    }
}
