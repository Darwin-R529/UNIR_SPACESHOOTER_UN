using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject meteorSpawner;
    [SerializeField] private GameObject livesCanvas;

    private SpaceShooterActions inputActions;
    private bool gameStarted = false;
    private bool gameOver = false;
    private bool isPaused = false;


    private void Awake()
    {
        inputActions = new SpaceShooterActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.SpaceShip.Start.performed += ctx => StartGame(); // ← ACCIÓN DE INICIO
        inputActions.SpaceShip.Pause.performed += ctx => TogglePause(); // ← ACCIÓN DE PAUSA
        inputActions.SpaceShip.Anykey.performed += ctx =>
        {
            if (gameOver) RestartGame(); // ← REINICIO SI GAME OVER
        };
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        startText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        enemySpawner.SetActive(false);
        meteorSpawner.SetActive(true);
    }

    private void StartGame()
    {
        if (gameStarted) return;

        gameStarted = true;
        startText.gameObject.SetActive(false);
        livesCanvas.SetActive(true);
        enemySpawner.SetActive(true);
        meteorSpawner.SetActive(true);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        enemySpawner.SetActive(false);
        meteorSpawner.SetActive(false);
    }

    private void TogglePause()
    {
        if (!gameStarted || gameOver) return; // No pausar si no ha iniciado o ya terminó

        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Detiene todo
            Debug.Log("Juego en pausa");
            // Aquí puedes mostrar un texto de "PAUSE"
        }
        else
        {
            Time.timeScale = 1f; // Reanuda
            Debug.Log("Juego reanudado");
            // Oculta el texto de "PAUSE"
        }
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}