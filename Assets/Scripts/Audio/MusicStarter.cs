using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource.Play();
    }
}
