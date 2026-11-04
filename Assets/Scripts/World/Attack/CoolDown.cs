using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;

    private WaitForSeconds _wait;

    public bool IsReady { get; private set; } = true;


    private void Awake()
    {
       _wait = new WaitForSeconds(_duration);
    }

    public void StartCooldown()
    {
        if (IsReady)
            StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        IsReady = false;

        yield return _wait;

        IsReady = true;
    }
}
