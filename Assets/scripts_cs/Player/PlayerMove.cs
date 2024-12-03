using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick fixedJoystick;

    // Privates
    private float _playerSpeed; // Скорость игрока настраивается в JSON
    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";
    private Vector2 _inputMove = Vector2.zero;
    private Vector2 _deltaPosition;
    private Rigidbody2D _rb;
    // персонаж повЕрнут вправо
    private bool _moveRight = true;
    // interface
    public float inputMoveX() {
        return _inputMove.x;
    }
    public bool moveRight() {
        return _moveRight;
    }
    // start
    private void Start()
    {
        StartMaker();
    }
    private void StartMaker() {
        _playerSpeed = GameConstReader.gameConstants.player.playerSpeed;
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update
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
        FlipCheckH();
    }
    private void IdleState(){
        _deltaPosition = Vector2.zero;
    }
    // private void NewPosition() {
    //     // Не физичное движение. Кажется, мы расстанемся
    //     transform.position = new Vector2 (
    //         transform.position.x + _deltaPosition.x * Time.deltaTime ,
    //         transform.position.y + _deltaPosition.y * Time.deltaTime 
    //     );
    // }
    private void RbMovePosition(){
        // В обучалке движение с физикой. Решил попробовать его
        _rb.MovePosition(_rb.position + _deltaPosition * Time.fixedDeltaTime);
    }

    // Animation

    private void FlipCheckH(){
        if (_moveRight && _inputMove.x < 0) {
            FliperH();
        }
        if (!_moveRight && _inputMove.x > 0) {
            FliperH();
        }
    }

    private void FliperH(){
        _moveRight = !_moveRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
// Довольно просто пишется. Сам в шоке
// https://t.me/natureModelSpb
