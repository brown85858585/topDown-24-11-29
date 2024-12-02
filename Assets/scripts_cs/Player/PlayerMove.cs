using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick fixedJoystick;

    // Privates
    private float _playerSpeed; // Скорость игрока настраивается в JSON
    private int _playerHealth;
    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";
    private Vector2 _inputMove;
    private Vector2 _deltaPosition;
    private Rigidbody2D _rb;

    private void Start()
    {
        StartMaker();
    }
    private void StartMaker(){
        _playerSpeed = GameConstReader.gameConstants.player.playerSpeed;
        _playerHealth = GameConstReader.gameConstants.player.playerHealth;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        InputTaker();
        CheckInput();
        // NewPosition();
    }
    private void FixedUpdate(){
        RbMovePosition();
    }
    private void InputTaker(){
        // GetAxisRaw выдает дискретно -1, 0, 1
        _inputMove = new Vector2(
            Input.GetAxisRaw(_horizontal),
            Input.GetAxisRaw(_vertical)
        );
        // Если схватил за джойстик, то он перезапишет значения
        if ((fixedJoystick.Vertical != 0) || fixedJoystick.Horizontal != 0){
        _inputMove = new Vector2(
            fixedJoystick.Horizontal,
            fixedJoystick.Vertical
        );
        }
        _inputMove.Normalize();
    }
    private void CheckInput(){
        if (_inputMove != Vector2.zero){
            MoveState();
        } else {
            IdleState();
        }
    }
    private void MoveState(){
        _deltaPosition = new Vector2(
            _playerSpeed * _inputMove.x,
            _playerSpeed * _inputMove.y
        );
        HorizonFlipper();
    }
    private void IdleState(){
        _deltaPosition = Vector2.zero;
    }
    private void NewPosition() {
        // Не физичное движение
        transform.position = new Vector2 (
            transform.position.x + _deltaPosition.x * Time.deltaTime ,
            transform.position.y + _deltaPosition.y * Time.deltaTime 
        );
    }
    private void RbMovePosition(){
        // В обучалке движение с физикой. Решил попробовать его
        _rb.MovePosition(_rb.position + _deltaPosition * Time.fixedDeltaTime);
    }

    // Animation

    private void HorizonFlipper(){
        if (_inputMove.x > 0){
            transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
        }
    }

    // Health

    public void PlayerTakeDamage(int _damage){
        _playerHealth -= _damage;
    }
}
// Довольно просто пишется. Сам в шоке
// https://t.me/natureModelSpb
