using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int  damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}