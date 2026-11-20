using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBarView : MonoBehaviour
{
    [SerializeField] protected Slider _healthBar;
    [SerializeField] protected Health _health;
   

    private void OnEnable()
    {
        _health.HealthChanged += OnChangeHealthBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnChangeHealthBar;
    }

    protected virtual void OnChangeHealthBar()
    {
    }

    protected virtual void ChangeHealthBar(float startValue,float targetValue,float speedAnimations)
    {
        _healthBar.value = _health.HealthLevel / _health.HealthLevelMax;
    }
}
