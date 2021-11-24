using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float delayTime = 3f;
    [SerializeField] GameObject playerProjectile;
    [SerializeField] GameObject chargeAttack;

    private int nextScene;
    PlayerController playerController;
    UnitCollisionPlayer utcp;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        utcp = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitCollisionPlayer>();
        saveProgress();
        CalculateNextScene();
        //Debug.Log(nextScene);
    }

    private void CalculateNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;
    }

    // Update is called once per frame
    void Update()
    {
        DelayLoadGameOver();
    }

    private void DelayLoadGameOver()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            StartCoroutine(DelayProcess(delayTime));

        }
    }

    private static void LoadGameOver()
    {
        Debug.Log("gameover");

        SceneManager.LoadScene("GameOver");
    }


    IEnumerator DelayProcess(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        LoadGameOver();
    }

    public void LoadNextStage()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("DamagePower", utcp.GetFirePower());
        PlayerPrefs.SetFloat("FireRate", playerController.GetFireRate());
        PlayerPrefs.SetFloat("MaxSheild", utcp.GetMaxSheild());
        PlayerPrefs.SetInt("ChargePower", utcp.GetChargePower());
        PlayerPrefs.SetFloat("CriticRate", utcp.GetCritic());
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }
    public void saveProgress()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedLevel", currentScene);
        Debug.Log("game has been saved");
    }
}