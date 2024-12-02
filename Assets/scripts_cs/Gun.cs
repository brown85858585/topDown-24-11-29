using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float gunLocalScale = 0.8f; // временная переменнаая. Пока не появится Sprite
    // private
    private float _offset = 0f;
    private Vector3 _difference;
    void Update(){
        UpdateMaker();
    }
    private void UpdateMaker(){
        ScreenMouseVector3();
        HorizonFlipper();
        float rotationZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + _offset);
        
        // Debug.Log("Camera.main.ScreenToWorldPoint " + cameraMousePisotion);
        // Debug.Log("difference " + _difference);
        // Debug.Log("Mathf.Atan2(difference.y, difference.x) " + Mathf.Atan2(difference.y, difference.x));
        // Debug.Log("rotationZ " + rotationZ);
        // Debug.Log("Quaternion.Euler(0f, 0f, rotationZ + offset) " + Quaternion.Euler(0f, 0f, rotationZ + offset));
    }
    private void ScreenMouseVector3(){
        Vector3 _cameraMousePisotion = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        _difference = _cameraMousePisotion - transform.position;
    }
    private void HorizonFlipper(){
        if (_difference.x > 0){
            transform.localScale = new Vector3 (transform.localScale.x, gunLocalScale, transform.localScale.z);
        } else {
            transform.localScale = new Vector3 (transform.localScale.x, -gunLocalScale, transform.localScale.z);
        }
    }

}
