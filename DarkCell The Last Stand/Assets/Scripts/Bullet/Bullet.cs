using UnityEngine;

public class Bullet : MonoBehaviour
{
    EnemyHealth health;

    private void Start()
    {
        health = FindObjectOfType<EnemyHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       gameObject.SetActive(false);

        if(collision.gameObject.CompareTag("Enemy"))
        {
            health.TakeDamage(10);
        }
    }
}