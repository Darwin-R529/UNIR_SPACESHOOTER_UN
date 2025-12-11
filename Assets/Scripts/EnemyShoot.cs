using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 5f;   // velocidad del proyectil
    [SerializeField] private Vector2 direction = Vector2.down; // dirección por defecto (hacia abajo)

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Opcional: destruir el proyectil al salir de la pantalla
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
