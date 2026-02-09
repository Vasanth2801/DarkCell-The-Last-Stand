using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Fire point References")]
    [SerializeField] private Transform firePoint;

    [Header("Bullet Settings")]
    [SerializeField] private float bulletSpeed = 15f;

    [Header("References")]
    [SerializeField] private ObjectPooler pooler;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = pooler.SpawnFromPools("Bullet",firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up *  bulletSpeed,ForceMode2D.Impulse);
    }
}
