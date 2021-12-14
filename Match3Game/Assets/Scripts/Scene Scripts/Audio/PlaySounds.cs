using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isActive;
    private bool _wait;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Global.Destroyer.Equals("Wait") && !_isActive)
        {
            _isActive = true;

        }
        else if (Global.Destroyer.Equals("Destroying") && _isActive && !_wait)
        {
            _audioSource.Play();
            _isActive = false;
            _wait = true;
            StartCoroutine(PlaySoundEffect(1.5f));
        }
    }

    private IEnumerator PlaySoundEffect(float delay)
    {
        yield return new WaitForSeconds(delay);
        _wait = false;
    }

}
