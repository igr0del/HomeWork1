using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _activeCoroutine;
    private float _valumeScale = 0.5f;
    private float _targetValue;

    public void PlaySound()
    {
        _targetValue = 1f;
        _audioSource.Play();
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        _targetValue = 0f;
        StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private void Start()
    {
        _audioSource.volume = 0;
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetValue, _valumeScale * Time.deltaTime);
            yield return null;
        }
    }
}
