using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick fixedJoystick;

    // Privates
    private float _playerSpeed; // Скорочть игрока настраивается в JSON
    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";
    private Vector2 _inputMove;
    private Vector2 deltaPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        StartMaker();
    }
    private void StartMaker(){
        _playerSpeed = GameConstReader.gameConstants.player.playerSpeed;
        rb = GetComponent<Rigidbody2D>();
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
        deltaPosition = new Vector2(
            _playerSpeed * _inputMove.x,
            _playerSpeed * _inputMove.y
        );
        HorizonFlipper();
    }
    private void HorizonFlipper(){
        if (_inputMove.x > 0){
            transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
        }
    }
    private void IdleState(){
        deltaPosition = Vector2.zero;
    }
    private void NewPosition() {
        // Не физичное движение
        transform.position = new Vector2 (
            transform.position.x + deltaPosition.x * Time.deltaTime ,
            transform.position.y + deltaPosition.y * Time.deltaTime 
        );
    }
    private void RbMovePosition(){
        // В обучалке движение с физикой. Решил попробовать его
        rb.MovePosition(rb.position + deltaPosition * Time.fixedDeltaTime);
    }
}
// Довольно просто пишется. Сам в шоке
// https://t.me/natureModelSpb
