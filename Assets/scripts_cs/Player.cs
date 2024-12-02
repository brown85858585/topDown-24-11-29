using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _playerSpeed; // Скорочть игрока настраивается в JSON
    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";
    // private float _inputHorizontal;
    // private float _inputVertical;
    private Vector2 _inputMove;
    private Vector2 deltaPosition;

    private void Start()
    {
        _playerSpeed = GameConstReader.gameConstants.player.playerSpeed;
    }

    private void Update(){
        InputTaker();
        MoveNormalize();
        CheckInput();
        MoveState();
        NewPosition();
    }
    private void InputTaker(){
        // GetAxisRaw выдает дискретно -1, 0, 1
        _inputMove = new Vector2(
            Input.GetAxisRaw(_horizontal),
            Input.GetAxisRaw(_vertical)
        );
        // _inputHorizontal = Input.GetAxisRaw(_horizontal);
        // _inputVertical = Input.GetAxisRaw(_vertical);
    }
    private void MoveNormalize(){
        _inputMove.Normalize();
    }
    private void CheckInput(){
        if (_inputMove != new Vector2(0, 0)){
            MoveState();
        } else {
            IdleState();
        }
    }
    private void MoveState(){
        deltaPosition = new Vector2(
            _playerSpeed * Time.deltaTime * _inputMove.x,
            _playerSpeed * Time.deltaTime * _inputMove.y
        );
    }
    private void IdleState(){
        deltaPosition = Vector2.zero;
    }
    private void NewPosition() {
        transform.position = new Vector2 (
            transform.position.x + deltaPosition.x,
            transform.position.y + deltaPosition.y
        );
    }
}
