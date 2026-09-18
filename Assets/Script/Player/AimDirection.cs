using UnityEngine;
using UnityEngine.InputSystem;

public class AimDirection : MonoBehaviour
{
    public Vector2 aimDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 global_mouse = Mouse.current.position.ReadValue();
        Vector2 local_mouse = Camera.main.ScreenToWorldPoint(global_mouse);
        aimDirection = (local_mouse - (Vector2)transform.position).normalized;
    }
}
