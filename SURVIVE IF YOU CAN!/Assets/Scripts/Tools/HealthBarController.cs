using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarController : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private Text _text;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void UpdateSliderValue(int hp)
    {
        _slider.value = hp;
        _text.text = hp.ToString();
    }
    /*public void ResetHpBar()
    {
        _slider.value = 100;
        _text.text = "100";
    }*/
}
