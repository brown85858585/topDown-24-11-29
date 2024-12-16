using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetter : MonoBehaviour
{
    private Slider c_mySlider;
    void Start() {
        StartMaker();
    }
    private void StartMaker() {
        c_mySlider = GetComponent<Slider>();
    }
    // interface
    public void SetValue(float f_health) {
        c_mySlider.value = f_health;
        // Debug.Log("f_health !!! "+f_health);
        // print("f_health "+f_health);
    }
    public void SetMinMax(float f_min, float f_max) {
        c_mySlider.minValue = f_min;
        c_mySlider.maxValue = f_max;
    }
}
