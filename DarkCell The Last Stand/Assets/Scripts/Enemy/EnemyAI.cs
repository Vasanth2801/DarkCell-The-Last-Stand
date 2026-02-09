using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 180f;

    [Header("Enemy Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);

        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Attacking the Player");
        }
    }
}