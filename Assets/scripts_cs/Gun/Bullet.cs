using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Указать твердый слой. Кажется, лучше решить в тегах. Так как слой может быть лишь один
    public LayerMask whatIsSolid;
    // private
    private int _damageToEnemy = 2;
    private float _bulletSpeed;
    private float _bulletLifeTime = 2.0f;
    private float _distance;
    private Rigidbody2D _rb;
    private Vector2 _direction; // Направление движения пули
    private Vector3 _oldPosition;
    // start
    private void Start() {
        StartMaker();
    }
    private void StartMaker() {
        _bulletSpeed = GameConstReader.gameConstants.environment.bulletSpeed;
        _bulletLifeTime = GameConstReader.gameConstants.environment.bulletLifeTime;
        _rb = GetComponent<Rigidbody2D>();
        SetBulletVelocity();
        Destroy(gameObject, _bulletLifeTime);
    }
    private void SetBulletVelocity() {
        // Устанавливаем скорость для Rigidbody2D
        _direction = transform.up;
        _rb.velocity = _direction * _bulletSpeed;
        _oldPosition = transform.position;
    }
    private void Update() {
        UpdateMaker();
    }
    private void UpdateMaker() {
        Vector3 _distanceHendler = _oldPosition - transform.position;
        _distance = _distanceHendler.magnitude;
        CheckHitBetweenPositions ();
        _oldPosition = transform.position;
    }
    private void CheckHitBetweenPositions () {
        RaycastHit2D _hitInfo = Physics2D.Raycast(_oldPosition, transform.position, _distance, whatIsSolid);
        if (_hitInfo.collider != null) {
            if (_hitInfo.collider.CompareTag("Enemy") 
            && _hitInfo.collider.GetComponent<EnemyHealthCounter>() != null) {
                _hitInfo.collider.GetComponent<EnemyHealthCounter>().TakeDamage(_damageToEnemy);
            }
            Destroy(gameObject);
        }

    }
}
