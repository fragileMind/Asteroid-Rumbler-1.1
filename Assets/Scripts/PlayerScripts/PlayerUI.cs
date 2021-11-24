using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerUI : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    [Header("GamePlayUI")]
    [SerializeField] Image healthBar;
    [SerializeField] Image sheildBar;
    [SerializeField] float uiLerp = 3f;
    [SerializeField] TextMeshProUGUI enemyCounter;
    [SerializeField] float totalEnemy=48;
    [SerializeField] GameObject nextLevelUI;
    [Header("PuaseMenu")]
    [SerializeField] GameObject puaseMenuUI;
    bool gamePuased;

    float health, maxHealth = 100;
    float sheild, maxSheild = 100;
    UnitCollisionPlayer utcp;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.UI.Enable();
        playerInputActions.UI.PuaseGame.performed += PuaseUI;
    }

    void Start()
    {
        gamePuased = false;
        utcp = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitCollisionPlayer>();
    }

    private void UIConfigeration()
    {
        health = utcp.GetHealth();
        sheild = utcp.GetSheild();
    }

    // Update is called once per frame
    void Update()
    {
        UIConfigeration();
        HealthBarFiller();
        SheildBarFiller();
        ColorChanger();
        EnemyCounter();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, uiLerp * Time.deltaTime);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
    }


    void SheildBarFiller()
    {
        sheildBar.fillAmount = Mathf.Lerp(sheildBar.fillAmount, sheild / maxSheild, uiLerp * Time.deltaTime);
    }

    public void AddToEnemyCounter()
    {
        totalEnemy -= 1;
    }
    void EnemyCounter()
    {
        enemyCounter.text = "x" + totalEnemy;
    }

    void PuaseUI(InputAction.CallbackContext context)
    {
        if (!gamePuased)
        {
            Puase();
        }
        else
        {
            Resume();
        }

    }

    public  void Resume()
    {
        puaseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePuased = false;
    }

    private  void Puase()
    {
        puaseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePuased = true;
    }

    public void NextLevelUI()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentIndex == 3)
        {
            DelayLoadNextStage();
        }
        else
        {
            nextLevelUI.SetActive(true);
            Time.timeScale = 0f;
        }

    }
    void DelayLoadNextStage()
    {
        StartCoroutine(DelayLoadingProcess(2f));
    }

    IEnumerator DelayLoadingProcess(float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        FindObjectOfType<GameManager>().LoadNextStage();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}