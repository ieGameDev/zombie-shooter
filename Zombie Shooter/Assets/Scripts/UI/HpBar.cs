﻿using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image _imageCurrent;

        public void SetValue(float current, float max) => 
            _imageCurrent.fillAmount = current / max;
    }
}
