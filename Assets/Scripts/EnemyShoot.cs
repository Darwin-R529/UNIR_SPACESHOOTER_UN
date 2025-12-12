using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private float speed = 5f;   // velocidad del proyectil
    [SerializeField] private Vector2 direction = Vector2.down;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
