using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMng : MonoBehaviour
{
    [SerializeField] int    levelTime;
    [SerializeField] int    maxTime;
    [SerializeField] int    penalty;

    private float           currentTime;
    private int             currentScore;

    public static GameMng   instance;

    protected List<string>  iventory;

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

         iventory = new List<string>();
    }


    void FixedUpdate()
    {
        currentTime -= Time.fixedDeltaTime;

        if (currentTime <= 0)
        {
            //GameOver
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void LoseTime()
    {
        currentTime -= penalty;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddIventory(string itemName)
    {
        if (iventory.IndexOf(itemName) == -1)
        {
            iventory.Add(itemName);
        } 
    }

    public bool HasItem(string itemName)
    {
        int index = iventory.IndexOf(itemName);

        return (index != -1);
    }

    public void RemoveFromIventory(string itemName)
    {
        int index = iventory.IndexOf(itemName);

        if (index != -1)
        {
            iventory.RemoveAt(index);
        }
    }
}
