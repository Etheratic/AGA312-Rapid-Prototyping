using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class EffectsManager : GameBehaviour<EffectsManager>
{
    public Volume volume;

    private ChromaticAberration aberration;
    private Bloom bloom;
    private Vignette vignette;


    #region ChromaticAberration
    public void SetChromatic(float _value)
    {
        volume.profile.TryGet(out aberration);
        aberration.intensity.value = _value;
    }

    public void TweenChromaticInOut(float _Intensity, float _Duration)
    {
        volume.profile.TryGet(out aberration);
        DOTween.To(() => aberration.intensity.value, (x) => aberration.intensity.value = x, _Intensity, _Duration).OnComplete(() =>
        TweenChromatic(0, _Duration));
    }

    public void TweenChromatic(float _Intensity, float _Duration)
    {
        volume.profile.TryGet(out aberration);
        DOTween.To(() => aberration.intensity.value, (x) => aberration.intensity.value = x, _Intensity, _Duration);
    }

    #endregion

    #region bloom
    public void SetBloom(float _Intensity)
    {
        volume.profile.TryGet(out bloom);
        bloom.intensity.value = _Intensity;

    }

    public void TweenBloomInOut(float _Intensity, float _Duration)
    {
        volume.profile.TryGet(out bloom);
        DOTween.To(() => bloom.intensity.value, (x) => bloom.intensity.value = x, _Intensity, _Duration).OnComplete(() =>
        TweenBloom(0, _Duration));
    }

    public void TweenBloom(float _Intensity, float _Duration)
    {
        volume.profile.TryGet(out bloom);
        DOTween.To(() => bloom.intensity.value, (x) => bloom.intensity.value = x, _Intensity, _Duration);
    }
    #endregion

    #region vignette
    public void SetVignette(float _Intensity)
    {
        volume.profile.TryGet(out vignette);
        vignette.intensity.value = _Intensity;

    }

    public void TweenVignetteInOut(float _Intensity, float _Duration)
    {
        volume.profile.TryGet(out vignette);
        DOTween.To(() => vignette.intensity.value, (x) => vignette.intensity.value = x, _Intensity, _Duration).OnComplete(() =>
        TweenVignette(0, _Duration));
    }

    public void TweenVignette(float _Intensity, float _Duration)
    {
        volume.profile.TryGet(out vignette);
        DOTween.To(() => vignette.intensity.value, (x) => vignette.intensity.value = x, _Intensity, _Duration);
    }
    #endregion
}



