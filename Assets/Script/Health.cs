using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int MaxHealth = 10;
    public int currentHealth;
    public event System.Action<int> onHealthChanged;
    public event System.Action onDeath;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }
    public void Takedamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (onHealthChanged != null)
        {
            onHealthChanged.Invoke(currentHealth);
        }
        if (currentHealth <= 0)
        {
            if(onDeath != null)
            {
                onDeath.Invoke();
            }
            Destroy(gameObject);
        }
    }

}
