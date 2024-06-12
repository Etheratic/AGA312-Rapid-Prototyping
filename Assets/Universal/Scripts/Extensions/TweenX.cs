using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public static class TweenX
{
    public static void TweenNumbers(TMPro.TMP_Text _text, float _startValue, float _endValue, float _duration = 1f, Ease _ease = Ease.InOutSine, string _format = "F0")
    {
        DOTween.To(() => _startValue, x => _startValue = x, _endValue, _duration).SetEase(_ease).OnUpdate(() =>
        {
            _text.text = _startValue.ToString(_format);
        });
    }
}
