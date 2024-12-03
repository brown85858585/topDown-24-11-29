using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed; 
    private float _bulletLifeTime = 2.0f;
    private Rigidbody2D _rb;
    private Vector2 _direction; // Направление движения пули
    // start
    private void Start()
    {
        StartMaker();
    }
    private void StartMaker() {
        _bulletSpeed = GameConstReader.gameConstants.environment.bulletSpeed;
        _rb = GetComponent<Rigidbody2D>();
        SetBulletVelocity();
        Destroy(gameObject, _bulletLifeTime);
    }
    private void SetBulletVelocity() {
        // Устанавливаем скорость для Rigidbody2D
        _direction = transform.up;
        _rb.velocity = _direction * _bulletSpeed;
    }
}
