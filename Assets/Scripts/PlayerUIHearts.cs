using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHearts : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        int lives = playerHealth.CurrentLives;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
                // hearts[i].enabled = true;  // corazón visible
                hearts[i].gameObject.SetActive(true);  // corazón visible
            else
                hearts[i].gameObject.SetActive(false);  // corazón visible
                                                        // hearts[i].enabled = false; // corazón apagado
        }
    }

}
