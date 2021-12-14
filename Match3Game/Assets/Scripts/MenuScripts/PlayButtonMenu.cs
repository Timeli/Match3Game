using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayButtonMenu : MonoBehaviour
{
    [SerializeField] private Button _playButtonMenu;

    public void PlayMenuButton()
    {
        SceneManager.LoadScene(1);
    }
}
