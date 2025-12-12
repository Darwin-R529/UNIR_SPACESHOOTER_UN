using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float rotationSpeed = 50f; // grados por segundo
    [SerializeField] private float moveSpeed = 2f;      // velocidad de desplazamiento
    private Vector2 moveDirection;

    private void Start()
    {
        // Rotación aleatoria
        rotationSpeed = Random.Range(-100f, 100f);

        // Dirección: siempre hacia -x, con variación en Y
        float randomY = Random.Range(-0.5f, 0.5f);
        moveDirection = new Vector2(-1f, randomY).normalized;

        // Velocidad aleatoria para variedad
        moveSpeed = Random.Range(1.5f, 3.5f);
    }

    private void Update()
    {
        // Rotación continua
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Movimiento hacia la izquierda con variación vertical
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    public void DestroyMeteor()
    {
        Destroy(gameObject);
        // Aquí puedes instanciar una explosión visual si lo deseas
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            Destroy(collision.gameObject);
            // Instancia la explosión en la posición del meteoro
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

}