using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI reloadText;
    public Combat combat;
    public Image image;
    public Image image2;
    public Image image3;
    public Sprite full;
    public Sprite empty;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reloadText.text = combat.timer.ToString("F1");

        if (combat.attackSlot == 3)
        {
            image.sprite= full;
            image2.sprite = full;
            image3.sprite = full;
        }
        else if (combat.attackSlot == 2)
        {
            image.sprite = full;
            image2.sprite = full;
            image3.sprite = empty;
        }
        else if (combat.attackSlot == 1)
        {
            image.sprite = full;
            image2.sprite = empty;
            image3.sprite = empty;
        }
        else
        {
            image.sprite = empty;
            image2.sprite = empty;
            image3.sprite = empty;
        }
    }
}
