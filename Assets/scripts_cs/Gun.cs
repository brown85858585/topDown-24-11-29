using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public PlayerMove playerMove;
    // private
    private float _offset = 0f;
    private Vector3 _difference;
    private bool faceRight = true;
    private bool moveRight = true;
    private void Update(){
        UpdateMaker();
    }
    private void UpdateMaker(){
        ScreenMouseVector3();
        FlipCheckH();
        FlipCheckV();
        float rotationZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + _offset);
    }
    private void ScreenMouseVector3(){
        Vector3 _cameraMousePisotion = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        _difference = _cameraMousePisotion - transform.position;
    }
    private void FlipCheckH(){
        if (!moveRight && playerMove.moveRight()){
            FliperH();
        }
        if (moveRight && !playerMove.moveRight()){
            FliperH();
        }
    }
    private void FlipCheckV(){
        if(faceRight && _difference.x < 0) {
            FliperV();
        }
        if(!faceRight && _difference.x > 0) {
            FliperV();
        }
    }
    private void FliperH(){
        moveRight = !moveRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    private void FliperV(){
        faceRight = !faceRight;
        Vector3 Scale = transform.localScale;
        Scale.y *= -1;
        transform.localScale = Scale;
    }
}
