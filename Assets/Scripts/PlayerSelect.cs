using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public List<GameObject> playerColor;
    public GameObject player;
    public int playerColorCount = 0;

    void Start()
    {
        player = playerColor[1];
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            ChangePlayerColor();
        }
    }

    public void ChangePlayerColor()
    {
        player.SetActive(false);
        player = playerColor[playerColorCount++];
        if (playerColorCount == playerColor.Count)
        {
            playerColorCount = 0;
        }

        player.SetActive(true);
    }
}
