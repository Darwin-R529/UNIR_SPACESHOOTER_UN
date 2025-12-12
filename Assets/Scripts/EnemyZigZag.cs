using UnityEngine;

public class EnemyZigZag : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 3f;
    public float amplitude = 2f;   // qué tan ancho el zig-zag
    public float frequency = 2f;   // qué tan rápido oscila

    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float minShootDelay = 1f;
    public float maxShootDelay = 3f;

    [Header("Vida")]
    public int health = 3;

    private float nextShootTime;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        // Cada enemigo arranca con un tiempo de disparo distinto
        nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
    }

    private void Update()
    {
        // Movimiento hacia abajo
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Zig-zag horizontal
        float xOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x + xOffset, transform.position.y, transform.position.z);

        // Disparo aleatorio
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //GetComponent<AudioSource>().PlayOneShot(shootClip);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}