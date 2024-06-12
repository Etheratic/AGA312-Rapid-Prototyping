using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class FadeX
{
    /// <summary>
    /// Fades a Canvas group
    /// </summary>
    /// <param name="_cvg">the canvas group</param>
    /// <param name="_toValue">the value to fade to</param>
    /// <param name="_duration">how long the fade lasts</param>
    public static void FadeCanvas(CanvasGroup _cvg, float _toValue, float _duration)
    {
        _cvg.DOFade(_toValue, _duration);
    }
}
