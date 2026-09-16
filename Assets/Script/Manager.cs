using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI reloadText;
    public Combat combat;
    public Image image;
    public TextMeshProUGUI fireballCount;
    public Sprite full;
    public Sprite empty;
    public Movement movement;
    public TextMeshProUGUI healthCount;
    public Slime_Behavior slime_Behavior;
    public GameObject gameover;
    public GameObject win;
    public TextMeshProUGUI score;
    public float timesurvived = 0;
    public int count;
    public TextMeshProUGUI finaltime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timesurvived += Time.deltaTime;
        reloadText.text = combat.timer.ToString("F1");
        fireballCount.text = $"{combat.attackSlot.ToString()} X";
        healthCount.text = $"{movement.health.ToString()} X";
        score.text = $"Score : {timesurvived.ToString("F1")}";
        isWinning();
        if (count == 64)
        {
            GameOver();
        }
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void GameOver()
    {
        gameover.SetActive(true);
        slime_Behavior.isOver = true;
    }
    public void isWinning()
    {
        if (count == 0 && timesurvived>10)
        {
            win.SetActive(true);
            slime_Behavior.isOver = true;
            finaltime.text = $"CONGRATULATIONS /n Time : {timesurvived}";
            
        }
    }
    
}
