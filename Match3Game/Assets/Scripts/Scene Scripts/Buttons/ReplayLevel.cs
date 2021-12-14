using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayLevel : MonoBehaviour
{
    public void ReplayTheSameLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
