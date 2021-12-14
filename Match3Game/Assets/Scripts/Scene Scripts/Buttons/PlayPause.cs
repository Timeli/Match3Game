using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class PlayPause : Animates
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _panel;
    [SerializeField] private WinEffects _winEffects;

    [SerializeField] private Sprite _playSprite;
    [SerializeField] private Sprite _pauseSprite;

    private bool _isPause;

    private void Start()
    {
        Global.PausePlay = "Play";
    }

    public void OnButtonClick()
    {
        if (!_winEffects.GetPannelActive)
        {
            _isPause = _isPause == false ? true : false;

            SetCondition();
            ChangeSprites();
            MovePanel();
        }
    }

    private void SetCondition()
    {
        if (_isPause)
            Global.PausePlay = "Pause";
        else
            Global.PausePlay = "Play";
        
            
    }

    private void MovePanel()
    {
        if (_isPause)
            MoveUpPanel(_panel);
        else
            MoveDownPanel(_panel);
    }


    private void ChangeSprites()
    {
        if (_isPause)
            _button.GetComponent<Image>().sprite = _pauseSprite;
        else
            _button.GetComponent<Image>().sprite = _playSprite;
    }

}
