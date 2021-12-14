using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEffects : Animates
{
    [SerializeField] private Score _score;
    [SerializeField] private GameObject _winPannel;

    private int _currentScore;
    private int _lvlScore;

    private bool _isActive;

    private void Start()
    {
        _lvlScore = _score.GetScoreForLevel;
    }


    public bool GetPannelActive { get => _isActive; }

    private void Update()
    {
        _currentScore = _score.GetCurrentScore;

        if (_currentScore >= _lvlScore && !_isActive)
        {
            StartCoroutine(MoveWinPannel());
            _isActive = true;
        }
    }

    private IEnumerator MoveWinPannel()
    {
        yield return new WaitForSeconds(1f);
        ActivateWinPannel(_winPannel);
        StarActivate(_winPannel);
    }
}
