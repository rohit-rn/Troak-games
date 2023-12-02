﻿/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject timerObject;
    public static GameManager instance;

    public float slowDownFactor = 10f;
    public float slowMotionTime = 1f;
    public bool gameOver = false;
    public bool freezeTiles = false;
    public bool gameEnded = false;

    public int _score = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    private void Start()
    {
        gameOver = true;
        freezeTiles = true;
        PlayerPrefs.GetInt("TopScore", 0);
        gameEnded = false;
        UIManager.instance.ArriveIntoGame();
    }

    public void StartGame()
    {
        gameOver = false;
        _score = 0;
    }

    public void IncrementScore(int increment)
    {
        _score += increment;
        UIManager.instance.UpdateScoreText(this._score);
    }

    public void EndGame()
    {
        gameOver = true;
        Destroy(timerObject);
        UIManager.instance.ScoreFadeOut();
        StartCoroutine(SlowDownAndStop());
    }

    private IEnumerator SlowDownAndStop()
    {
        Time.timeScale = 1 / slowDownFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownFactor;

        yield return new WaitForSeconds(slowMotionTime / slowDownFactor);

        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
        freezeTiles = true;
        gameEnded = true;

        UIManager.instance.SetFinalScoreBoard(_score, PlayerPrefs.GetInt("TopScore", 0));
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
