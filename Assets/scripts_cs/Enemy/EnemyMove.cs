using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    // Временно все враги бегут на ГГ. До появления нормальной системы реакций
    public GameObject tempPlayer;
    // private
    private Rigidbody2D _rb;
    private Vector2 _targetPosition = new Vector2(0, 0);
    private Vector2 _nextRBStep;
    private float _enemySpeed = 5f; // Потом подгрузим в JSON.
    // interface
    // public void SetTargetPosition(Vector2 targetPosition) {
    //     _targetPosition = targetPosition;
    // }

    // start
    private void Start() {
        StartMaker();
    }
    private void StartMaker(){
        _enemySpeed = GameConstReader.gameConstants.enemy.enemySpeed;
        transform.position = new Vector3(8, -3, 0);
        _targetPosition = new Vector2(0, 0);
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        UpdateMaker();
    }
    private void UpdateMaker() {
        MoveOnPlayer();
        float _step = _enemySpeed * Time.deltaTime;
        _nextRBStep = Vector2.MoveTowards((Vector2)transform.position, _targetPosition, _step);
    }
    private void MoveOnPlayer() {
        if (tempPlayer != null) {
            Vector3 _playerPosition = tempPlayer.GetComponent<PlayerMove>().transform.position; // временно на игрока
            _targetPosition = (Vector2)_playerPosition;
        }
    }
    private void FixedUpdate() {
        RbMovePosition();
    }
    private void RbMovePosition() {
        _rb.MovePosition( _nextRBStep);
    }
}
