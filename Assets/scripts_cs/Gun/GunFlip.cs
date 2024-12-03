using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlip : MonoBehaviour
{
    public PlayerMove playerMove;
    // private
    private GunRotation gunRotation;
    private bool faceRight = true;
    private bool moveRight = true;
    // start
    private void Start() {
        StartMaker();
    }
    private void StartMaker() {
        gunRotation = GetComponent<GunRotation>();
    }
    // Update
    private void Update(){
        UpdateMaker();
    }
    private void UpdateMaker(){
        FlipCheckH();
        FlipCheckV();
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
        if(faceRight && gunRotation.differenceX() < 0) {
            FliperV();
        }
        if(!faceRight && gunRotation.differenceX() > 0) {
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
// https://t.me/natureModelSpb
