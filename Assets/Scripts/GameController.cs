using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject[] pickUps;
    public GameObject restartButton;
    public Vector3 spawnValues;
    public GUIText scoreText;
    public GUIText levelText;
    public GUIText gameOverText;
    public int hazardCount;
    public float spawnWait;
    public float pickUpWait;
    public float startWait;
    public float waveWait;

    private int score;
    private int level;
    private int pickUpCount;
    private bool gameOver;
    private bool resart;
   
    private void Start()
    {
        gameOver = false;
        resart = false;
        restartButton.SetActive(false);
        gameOverText.text = "";
        level = 0;
        score = 0;
        updateLevel();
        updateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnPickUps());
    }

    //  adding powerUps
    IEnumerator SpawnPickUps()
    {
        yield return new WaitForSeconds(startWait * 2);
        while (true)
        {
            for (int i = 0; i < pickUpCount; i++)
            {
                GameObject pickUp = pickUps[Random.Range(0, pickUps.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(pickUp, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(pickUpWait);
            }
            yield return new WaitForSeconds(pickUpWait);
            if (gameOver)
            {
                break;
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {   // test for level progression to bad guy ratio
            for (int i = 0; i < hazardCount + level * 3; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOver)
            {
                yield return new WaitForSeconds(waveWait);
                restartButton.SetActive(true);
                resart = true;
                break;
            }
            else
            {
                level++;
                yield return new WaitForSeconds(waveWait/2);
                levelWarning();
                yield return new WaitForSeconds(waveWait/2);
                gameOverText.text = "";
                updateLevel();
            }
        }
    }


    public void addScore(int newScoreValue)
    {
        score += newScoreValue;
        updateScore();
    }
    void updateScore()
    {
        scoreText.text = "Score: " + score;
    }
    void updateLevel()
    {
        levelText.text = "Lv:\n" + level;
    }
    void levelWarning()
    {
        gameOverText.text = "Next Wave\n approches!!!\n" + "enemies: " + (hazardCount + level * 3);
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!!!";
        gameOver = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
