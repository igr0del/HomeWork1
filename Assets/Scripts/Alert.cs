using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _duration;

    private float _startVolume = 0;
    private float _targetStayVolume = 1;
    private float _workingTime = 0;
    private float _valumeScale;

    private void Start()
    {
        _alarmSound.volume = _startVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarmSound.Play();
        Debug.Log(_alarmSound.volume);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {        
        _workingTime += Time.deltaTime;
        _valumeScale = _workingTime / _duration;
        _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _targetStayVolume, _valumeScale);
        Debug.Log(_alarmSound.volume);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _workingTime = 0;

        while (_alarmSound.volume > 0)
        {
            _workingTime += Time.deltaTime;
            _valumeScale = _workingTime / _duration;
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _startVolume, _valumeScale);
            Debug.Log(_alarmSound.volume);
        }
        _alarmSound.Stop();
    }
}
