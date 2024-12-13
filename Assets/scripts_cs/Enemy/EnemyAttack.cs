using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int _damageToPlayer = 1;
    private float _nextFire = 0f;
    private float _reloadTime = 1f;
    private void OnCollisionStay2D(Collision2D collision) {
        OnCollisionStay2DMaker(collision);
    }
    private void OnCollisionStay2DMaker(Collision2D collision) {
        RealoadAttack(collision);
    }
    private void RealoadAttack(Collision2D collision) {
        if (Time.time > _nextFire) {
            _nextFire = Time.time + _reloadTime;
            CheckPlayerDamage(collision);
        }
    }
    private void CheckPlayerDamage(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerHealthCounter>().TakeDamage(_damageToPlayer);
        }
    }
}
