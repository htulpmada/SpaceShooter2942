using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText resartText;
    public GUIText gameOverText;
    private bool gameOver;
    private bool resart;
    private int score;

    private void Start()
    {
        gameOver = false;
        resart = false;
        resartText.text = "";
        gameOverText.text = "";
        score = 0;
        updateScore();
        StartCoroutine (SpawnWaves());
    }
    private void Update()
    {
        if (resart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                resartText.text = "Press 'R' for Restart";
                resart = true;
                break;
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

    public void GameOver()
    {
        gameOverText.text = "Game Over!!!";
        gameOver = true;
    }
}
