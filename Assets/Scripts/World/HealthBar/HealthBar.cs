using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    [SerializeField] private float _speed;

    private void Update()
    {
        ChangeHealthBar(_health.HealthLevel, _speed);
    }

    private void ChangeHealthBar(float health,float speed)
    {
        _slider.value = Mathf.MoveTowards(_slider.value,health,speed * Time.deltaTime);
    }
}
