using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    public Movement movement;
    private InputAction attackAction;
    public GameObject fireball;
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
        if (attackAction != null && attackAction.WasPressedThisFrame())
        {
            Debug.Log("Attack Pressed");
            movement.animator.SetTrigger("Attack");

            // Calculation 
            float angle = Mathf.Atan2(movement.aimDirection.y, movement.aimDirection.x);
            angle = angle * Mathf.Rad2Deg + 90;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Instantiate(fireball, transform.position, rotation);
        }
    }
}
