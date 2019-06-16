using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player[] players;

    Player              currentPlayer;
    int                 playerIndex;
    CameraControl       ctrl;

    void Start()
    {
        playerIndex = 0;

        CameraControl ctrl = FindObjectOfType<CameraControl>();
        ctrl.target = players[playerIndex].transform;

        currentPlayer = players[playerIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentPlayer is Emma && !currentPlayer.isOnGround) return;

            players[playerIndex].CanControl = false;
            Vector3 currentPos = players[playerIndex].transform.position;

            playerIndex = (playerIndex + 1) % players.Length;

            players[playerIndex].CanControl = true;
            players[playerIndex].transform.position = currentPos;
            currentPlayer = players[playerIndex];

            CameraControl ctrl = FindObjectOfType<CameraControl>();
            if (ctrl)
            {
                ctrl.target = players[playerIndex].transform;
            }
        }
    }
}
