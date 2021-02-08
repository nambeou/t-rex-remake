using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] GameObject startingText;
    [SerializeField] int periodDurationInSeconds = 20;
    [SerializeField] float initialGameSpeed = 0.1f;
    float gameSpeed = 0;
    [SerializeField] bool started = false;
    float point = 0;
    // Start is called before the first frame update
    void Start()
    {
        startingText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (started) {
            point += gameSpeed;
            UpdateGameSpeed();
        } else {
            StartGame();
        }

    }

    private void UpdateGameSpeed() {
        float runningTime = Time.timeSinceLevelLoad;
        int gameSpeedMultiplierFactor = Mathf.RoundToInt(runningTime/periodDurationInSeconds);
        gameSpeed = initialGameSpeed + 0.1f*gameSpeedMultiplierFactor;
    }

    public float GetGameSpeed () {
        return gameSpeed;
    }
    public int GetPoint () {
        return Mathf.RoundToInt(point);
    }

    public void StartGame() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            started = true;
            gameSpeed = initialGameSpeed;
            startingText.SetActive(false);
            FindObjectOfType<Player>().Run();
        }
    }

    public bool GameHasStarted() {
        return started;
    }

}
