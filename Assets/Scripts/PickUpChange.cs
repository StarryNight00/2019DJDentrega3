using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpChange : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite newSprite;

    [SerializeField] protected string itemName;
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
            if (GameMng.instance.HasItem(itemName)) return;
            GameMng.instance.AddScore(scoreToAdd);
            NotifyPickUp(gameMng);

            spriteRenderer.sprite = newSprite;
        }
    }

    protected virtual void NotifyPickUp(GameMng gameMng)
    {

    }
}
