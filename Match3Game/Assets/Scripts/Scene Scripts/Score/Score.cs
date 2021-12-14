using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private DeleteBlock _deleteBlocks;
    
    [SerializeField] private TMP_Text _scoreNumber;
    [SerializeField] private TMP_Text _multipleScore;
    [SerializeField] private TMP_Text _plusScore;

    private int _score;
    private int _addToScore;
    private float _standartScore = 100;
    private float _multiple = 1;

    private bool _isActive;

    private int[] pointForLevels = { 10000, 15000 };

    public int GetCurrentScore { get => _score; }

    private void Update()
    {
        if (Global.Destroyer.Equals("Wait") && !_isActive)
        {
            _isActive = true;
        }
        else if (Global.Destroyer.Equals("Destroying") && _isActive)
        {
            SetScore(_deleteBlocks.GetLenthBlocks());
            
            StartCoroutine(ShowMultipleScore(1.5f));
            StartCoroutine(ShowPlusScore(2f));

            _isActive = false;
        }
    }


    //TODO: Add Current Level from Gamemanager
    public int GetScoreForLevel { get => pointForLevels[0]; }

    private IEnumerator ShowPlusScore(float delay)
    {
        _plusScore.text = $"+{_addToScore}";
        yield return new WaitForSeconds(delay);
        _plusScore.text = "";
    }

    private IEnumerator ShowMultipleScore(float delay)
    {
        _multipleScore.text = $"x{_multiple}";
        yield return new WaitForSeconds(delay);
        _multipleScore.text = "";
    }

    private float CalculateBonusScore(int lenth)
    {
        int len = lenth;

        if (len == 3)
            _multiple = 1;
        else if (len == 4)
            _multiple = 1.5f;
        else if (len >= 5)
            _multiple = 2;

        return _multiple;
    }

    private void SetScore(int lenth)
    {
        _addToScore = lenth * (int)(_standartScore * CalculateBonusScore(lenth));
        _score += _addToScore;
        _scoreNumber.text = _score.ToString();
    }
}
