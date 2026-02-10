using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Playerhealth health;

    private void Start()
    {
        health = FindObjectOfType<Playerhealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);

        if(collision.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(10);
        }
    }
}