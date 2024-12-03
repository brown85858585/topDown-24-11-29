using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private float _offset = 0f;
    private Vector3 _difference = Vector3.zero;

    // interface
    public float differenceX(){
        return _difference.x;
    }

    // Update
    private void Update(){
        UpdateMaker();
    }
    private void UpdateMaker(){
        ScreenMouseVector3();
        float rotationZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + _offset);
    }
    private void ScreenMouseVector3(){
        Vector3 _cameraMousePisotion = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        _difference = _cameraMousePisotion - transform.position;
    }
}
// https://t.me/natureModelSpb
