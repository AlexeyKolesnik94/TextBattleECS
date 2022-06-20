using System;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class SliderHp : MonoBehaviour
    {
        public float Value
        {
            set => _slider.value = value;
        } 

    private Slider _slider;

        private void Awake()
        {
            _slider = GetComponentInChildren<Slider>();
        }
    }
}
