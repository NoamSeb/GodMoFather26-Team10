using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void PlayBtn()
    {
        SceneManager.LoadScene("Hub");
    }
    /*public void ToggleOptions()
    {
        SceneManager.LoadScene("Options");
        xxx.setActive(xxx.activeSelf);
    }
    public void ToggleCredits()
    {
        SceneManager.LoadScene("Options");
    }*/
    public void QuitBtn()
    {
        Application.Quit();
    }
}
