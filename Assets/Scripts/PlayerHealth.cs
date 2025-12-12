using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentLives = 3;
    [SerializeField] private AudioClip lifeLostClip;
    private GameManager gameManager;

    public int CurrentLives => currentLives;
    private AudioSource audioSource;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();

    }

    public void TakeDamage(int amount = 1)
    {
        currentLives -= amount;

        audioSource.PlayOneShot(lifeLostClip);

        if (currentLives <= 0)
        {
            currentLives = 0;
            gameManager.GameOver();   // Notifica al GameManager
            Destroy(gameObject);      // Destruye al Player
        }
    }
}