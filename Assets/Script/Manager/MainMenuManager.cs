using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject nextSceneObject;
    public void nextScene()
    {
        mainMenu.SetActive(false);
        nextSceneObject.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void back()
    {
        mainMenu.SetActive(true);
        nextSceneObject.SetActive(false);
    }
    public void next()
    {
        SceneManager.LoadScene("MainScene");
    }
}
