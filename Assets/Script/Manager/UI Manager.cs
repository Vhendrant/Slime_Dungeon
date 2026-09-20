using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI reloadText;
    public Combat combat;
    public Health health;
    public TextMeshProUGUI fireballCount;
    public TextMeshProUGUI healthCount;
    public GameObject gameover;
    public GameObject win;
    public TextMeshProUGUI score;
    public float timesurvived = 0;
    public int count;
    public TextMeshProUGUI finaltime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Subscribing
        health.onHealthChanged += OnhealthChanged;
        health.onDeath += GameOver;
        combat.onattackSlotchanged += onAttackslotchanged;
        Slime_Behavior.slimecountchange += slimeCountfunction;

        // Instantiate UI value
        OnhealthChanged(health.currentHealth);
        onAttackslotchanged(combat.attackSlot);
    }

    // Update is called once per frame
    void Update()
    {
        timesurvived += Time.deltaTime;
        reloadText.text = combat.timer.ToString("F1");
        score.text = $"Score : {timesurvived.ToString("F1")}";
        isWinning();
    }

    public void onAttackslotchanged(int currentattackslot)
    {
        fireballCount.text = $"{currentattackslot.ToString()} X";
    }

    public void OnhealthChanged(int currentHealth)
    {
        healthCount.text = $"{currentHealth.ToString()} X";
    }

    public void OnDestroy()
    {
        // Unsubscribe
        combat.onattackSlotchanged -= onAttackslotchanged;
        health.onHealthChanged -= OnhealthChanged;
        health.onDeath -= GameOver;
        Slime_Behavior.slimecountchange -= slimeCountfunction;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GameOver()
    {
        gameover.SetActive(true);
    }

    public void isWinning()
    {
        if (count == 0 && timesurvived>10)
        {
            win.SetActive(true);
            finaltime.text = $"CONGRATULATIONS /n Time : {timesurvived}";
            
        }
    }

    public void slimeCountfunction(bool state)
    {
        if (state == true)
        {
            count += 1;
            if (count == 64)
            {
                GameOver();
            }
        }
        else if (state == false)
        {
            count -= 1;
        }
    }
    
}
