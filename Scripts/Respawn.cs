using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] public GameObject timerGO;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;

    private CountDownTimer cdt;

    public int respawnAmount = 0;

    private bool levelComplete = false;

    public string name = "Aidan";

    void Start()
    {
        cdt = timerGO.GetComponent<CountDownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -spawnValue)
        {
            RespawnPoint();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            CompleteLevel();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            cdt.currentTime -= 100;
        }

    }

    void RespawnPoint()
    {
        transform.position = spawnPoint.position;
        respawnAmount++;

        if (respawnAmount == 3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void CompleteLevel()
    {
        if (levelComplete)
        {
            return;
        }

        //save the score
        int currentScore = (int)cdt.currentTime;

        int[] HighScores = new int[5];
        string[] HSNames = new string[5];
        for (int i = 0; i < 5; i++)
        {
            HighScores[i] = PlayerPrefs.GetInt("HS" + (i + 1));
            HSNames[i] = PlayerPrefs.GetString("HSN" + (i+1));
        }
        if (currentScore > HighScores[4])
        {
            PlayerPrefs.SetInt("HS5", currentScore);
            PlayerPrefs.SetString("HSN5", name);
        }

        for (int j = 3; j >= 0; j--)
        {
            if (currentScore > HighScores[j])
            {
                PlayerPrefs.SetInt("HS" + (j + 2), HighScores[j]);
                PlayerPrefs.SetInt("HS" + (j + 1), currentScore);

                PlayerPrefs.SetString("HSN" + (j+2), HSNames[j]);
                PlayerPrefs.SetString("HSN" + (j+1), name);
            }

        }
        levelComplete = true;
        //load Leaderboard
        SceneManager.LoadScene("LeaderBoard");
    }
}
