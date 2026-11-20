using System.Collections;
using UnityEngine;

public class SmoothSliderView : HealthBarView
{
    [SerializeField] private float _speed;

    private float _duration = 0.1f;

    private Coroutine _coroutine;

    protected override void OnChangeHealthBar()
    {
        StartCoroutine();
    }

    protected override void ChangeHealthBar(float startValue,float targetValue,float speedAnimation)
    {
        base.ChangeHealthBar(startValue,targetValue,speedAnimation);
        _healthBar.value = Mathf.Lerp(startValue,targetValue,speedAnimation);
    }

    private void StartCoroutine()
    {
        if(_coroutine != null )
        {
            StopCoroutine(_coroutine); 
        }

        _coroutine = StartCoroutine(ChangingHealthBar());
    }

    private IEnumerator ChangingHealthBar()
    {
        float startValue = _healthBar.value;
        float targetValue = _health.HealthLevel / _health.HealthLevelMax;
        float elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            float speedAnimation = elapsedTime / _duration;

            ChangeHealthBar(startValue,targetValue,speedAnimation);

            yield return null;
        }

        _coroutine = null;
    }
}