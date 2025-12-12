using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootInterval = 2f;
    [SerializeField] private float shootTimer;

    [SerializeField] private float speedX = 2f;
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 2f;

    [SerializeField] private AudioClip shootClip;
    private AudioSource audioSource;


    Vector2 linearVelocity = Vector2.left;
    private float startY;
    private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startY = transform.position.y;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(linearVelocity * speed * Time.deltaTime);
        // if (transform.position.x < -7)
        // { linearVelocity = Vector3.right; }
        // if (transform.position.x > 7)
        // { Destroy(gameObject); }

        time += Time.deltaTime;

        // Movimiento horizontal hacia la izquierda
        float x = transform.position.x - speedX * Time.deltaTime;

        // Movimiento senoidal en Y
        float y = startY + Mathf.Sin(time * frequency) * amplitude;

        transform.position = new Vector3(x, y, transform.position.z);

        // Destruir al salir de pantalla por la izquierda
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }


        //Apartado para disparo de la nave enemiga
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
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        audioSource = GetComponent<AudioSource>();
    }
}
