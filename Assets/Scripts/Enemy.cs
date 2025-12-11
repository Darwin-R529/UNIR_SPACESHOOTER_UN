using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootInterval = 2f;
    [SerializeField] private float shootTimer;
 
    [SerializeField] float speed = 1f;

    Vector2 linearVelocity = Vector2.left;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);
        if (transform.position.x < -7)
        { linearVelocity = Vector3.right; }
        if (transform.position.x > 7)
        { Destroy(gameObject); }

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
    }
}
