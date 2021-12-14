
using UnityEngine;

public class MoveStrip : MonoBehaviour
{
    [SerializeField] private Score _score;

    private Vector2 _initialPos;
    private Vector2 _finishPos;

    private float _segment = 3.7f;
    private float _step;
    private float _scoreForLvl;
    private int _tmpScore;

    private void Start()
    {
        _finishPos = new Vector2(transform.position.x + _segment + 0.3f, transform.position.y);

        _initialPos = transform.position;
        _scoreForLvl = _score.GetScoreForLevel;
        _step = _segment / Mathf.FloorToInt(_scoreForLvl / 300);
    }

    private void Update()
    {
        MoveInnerStrip();
    }

    private void MoveInnerStrip()
    {
        int curentScore = _score.GetCurrentScore;
        
        if (curentScore < _scoreForLvl)
        {
            int tmp = curentScore / 300;
            transform.position = new Vector2(_initialPos.x + tmp * _step, _initialPos.y);
            
            _tmpScore = curentScore;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _finishPos, 0.01f);
        }
    }
}
