using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    private InputAction attackAction;
    public GameObject fireball;
    public int attackSlot = 3;
    public float timer = 0;
    private float targetTimer = 0.75f;
    public int maxSlot = 3;
    public AimDirection aim;
    public event System.Action<int> onattackSlotchanged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        attackAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // For trigger spawning fireball
        if (attackAction != null && attackAction.WasPressedThisFrame() && attackSlot != 0)
        {
            // Calculation 
            float angle = Mathf.Atan2(aim.aimDirection.y, aim.aimDirection.x);
            angle = angle * Mathf.Rad2Deg + 90;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Instantiate(fireball, transform.position, rotation);
            attackSlot -= 1;
            if (onattackSlotchanged != null)
            {
                onattackSlotchanged.Invoke(attackSlot);
            }
        }

        if (attackSlot < maxSlot)
        {
            if(timer < targetTimer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                attackSlot += 1;
                timer = 0;
                if (onattackSlotchanged != null)
                {
                    onattackSlotchanged.Invoke(attackSlot);
                }
            }
        }
        else
        {
            timer = 0;
        }

    }
}
