using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMng : MonoBehaviour
{
    [SerializeField] int    levelTime;
    [SerializeField] int    maxTime;
    [SerializeField] int    penalty;

    private float           currentTime;

    public static GameMng   instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        levelTime = levelTime * 3600;

        maxTime = levelTime / 60;
        maxTime = maxTime + 1;

        currentTime = maxTime;
    }


    void FixedUpdate()
    {
        currentTime -= Time.fixedDeltaTime;

        if (currentTime <= 0)
        {
            //GameOver
            Debug.Log("Game Over");
        }

        Debug.Log(currentTime);
    }

    public void LoseTime()
    {
        currentTime -= penalty;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
