using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletScript;
    public Transform shotPoint;
    private float _shootTime = 0f;
    private float _reloadTime = 0.5f; // Записать в JSON !
    void Update() {
        UpdateMaker();
    }
    private void UpdateMaker() {
        ReloadTimer();
    }
    private void ReloadTimer() {
        if (_shootTime > _reloadTime) {
            BulletInstantiate();
            _shootTime = 0f;
        } else {
            _shootTime += Time.deltaTime;
        }
    }
    private void BulletInstantiate() {
        if (Input.GetButton("Fire1")) { // LMB, Ctrl, JoyButton0
            Instantiate(bulletScript, shotPoint.position, shotPoint.rotation * Quaternion.Euler(0, 0, -90));
        }
    }
}
