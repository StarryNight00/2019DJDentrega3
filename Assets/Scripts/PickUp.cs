using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] int scoreToAdd = 0;

    private GameMng gameMng;

    private void Start()
    {
        gameMng = FindObjectOfType<GameMng>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            GameMng.instance.AddScore(scoreToAdd);
            NotifyPickUp(gameMng);

            Destroy(gameObject);
        }
    }

    protected virtual void NotifyPickUp(GameMng gameMng)
    {
        
    }
}
