using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("Race");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
