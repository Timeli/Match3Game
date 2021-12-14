using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(AudioSource))]
public class AdjustVolume : MonoBehaviour
{
    [SerializeField] private TMP_Text _textVolume;
    [SerializeField] private GameObject _camera;

    private AudioSource _audioSource;
    private static int _volume = 5;

    private void Start()
    {
        _audioSource = _camera.GetComponent<AudioSource>();
        _textVolume.text = _volume.ToString();
    }

    public void TurnDownVolume()
    {
        if (_volume > 0)
            _volume--;

        _audioSource.volume = _volume / 10.0f;
        _textVolume.text = _volume.ToString();
    }

    public void TurnUpVolume()
    {
        if (_volume < 10)
            _volume++;

        _audioSource.volume = _volume / 10.0f;
        _textVolume.text = _volume.ToString();
    }
}
