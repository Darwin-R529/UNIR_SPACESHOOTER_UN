using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int extraLives = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.AddLife(extraLives);
            }

            // Destruir el corazón después de recogerlo
            Destroy(gameObject);
        }
    }
}

