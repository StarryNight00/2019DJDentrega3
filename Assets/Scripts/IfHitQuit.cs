using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfHitQuit : MonoBehaviour
{
    [SerializeField] string item;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();

        if (player != null)
        {
            if (GameMng.instance.HasItem(item))
            {
                Application.Quit();
            }
        }
    }
}
