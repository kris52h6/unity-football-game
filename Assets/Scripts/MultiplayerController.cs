using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerController : MonoBehaviour
{
    public Player playerOne;

    public Player playerTwo;
    
    // Start is called before the first frame update
    void Start()
    {
        EnablePlayer(playerOne);
        DisablePlayer(playerTwo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerToggle();
        }
    }

    void PlayerToggle()
    {
        if (playerOne.enabled)
        {
            DisablePlayer(playerOne);
            EnablePlayer(playerTwo);
        }
        else
        {
            DisablePlayer(playerTwo);
            EnablePlayer(playerOne);
        }
    }

    void EnablePlayer(Player player)
    {
        player.enabled = true;
        player.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    void DisablePlayer(Player player)
    {
        player.enabled = false;
        player.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
