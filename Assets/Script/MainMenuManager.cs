using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;
    public void nextScene()
    {
        image.enabled = true;
        text.enabled = false;
    }
    public void quit()
    {
        Application.Quit();
    }
    public void back()
    {
        image.enabled = false;
        text.enabled = true;
    }
    public void next()
    {
        SceneManager.LoadScene("MainScene");
    }
}
