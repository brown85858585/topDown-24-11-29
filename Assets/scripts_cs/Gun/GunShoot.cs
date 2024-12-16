using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletScript;
    public Transform shotPoint;
    public SliderSetter ReloadSliderValue;
    // private
    private float _tilReloadTime;
    private float _reloadTime = 0.5f; // Записать в JSON !
    // start
    private void Start() {
        _tilReloadTime = _reloadTime;
    }
    // Update
    void Update() {
        UpdateMaker();
    }
    private void UpdateMaker() {
        SetSliderValue();
        ReloadTimer();
    }
    private void SetSliderValue() {
        float f_timePrecent = _tilReloadTime/_reloadTime;
        if (f_timePrecent < 1) {
            ReloadSliderValue.SetValue(f_timePrecent);
        } else {
            ReloadSliderValue.SetValue(1);
        }
    }
    private void ReloadTimer() {
        if (_tilReloadTime > _reloadTime) {
            BulletInstantiate();
        } else {
            _tilReloadTime += Time.deltaTime;
        }
    }
    private void BulletInstantiate() {
        if (Input.GetButton("Fire1")) { // LMB, Ctrl, JoyButton0
            Instantiate(bulletScript, shotPoint.position, shotPoint.rotation * Quaternion.Euler(0, 0, -90));
            _tilReloadTime = 0f;
        }
    }
}
