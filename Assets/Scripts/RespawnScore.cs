using UnityEngine;
using System.Collections;

public class RespawnScore : MonoBehaviour {

    PlayerController p11;
    PlayerController p12;
    PlayerController p21;
    PlayerController p22;

    UIManager manager;

    void Start()
    {
        p11 = GameObject.Find("Player11").GetComponent<PlayerController>();
        p12 = GameObject.Find("Player12").GetComponent<PlayerController>();
        p21 = GameObject.Find("Player21").GetComponent<PlayerController>();
        p22 = GameObject.Find("Player22").GetComponent<PlayerController>();

        manager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }
    void Update()
    {
        if (p11.respawnMe == true && manager.P1Life > 0)
        {
            respawn(p11);
            manager.P1Life -= 1;
        }
        if (p12.respawnMe == true && manager.P1Life > 0)
        {
            respawn(p12);
            manager.P1Life -= 1;
        }
        if (p21.respawnMe == true && manager.P2Life > 0)
        {
            respawn(p21);
            manager.P2Life -= 1;
        }
        if (p22.respawnMe == true && manager.P2Life > 0)
        {
            respawn(p22);
            manager.P2Life -= 1;
        }

        if (manager.P1Life == 0 && p11.respawnMe == true && p12.respawnMe == true)
        {
            manager.pauseEnabled = false;
            manager.respawnText.SetActive(true);
            if (Input.GetButtonDown("P1Start") || Input.GetButtonDown("P2Start"))
            {
                respawn(p11);
                respawn(p12);
                respawn(p21);
                respawn(p22);
                manager.P1Life = 5;
                manager.P2Life = 5;
                manager.respawnText.SetActive(false);
                manager.pauseEnabled = true;
            }
        }

        else if (manager.P2Life == 0 && p21.respawnMe == true && p22.respawnMe == true)
        {
            manager.pauseEnabled = false;
            manager.respawnText.SetActive(true);
            if (Input.GetButtonDown("P1Start") || Input.GetButtonDown("P2Start"))
            {
                respawn(p11);
                respawn(p12);
                respawn(p21);
                respawn(p22);
                manager.P1Life = 5;
                manager.P2Life = 5;
                manager.respawnText.SetActive(false);
                manager.pauseEnabled = true;
            }
        }
    }

    void respawn(PlayerController player)
    {
        player.rb.useGravity = true;
        player.rb.constraints = RigidbodyConstraints.FreezePositionY;
        player.transform.position = player.startLocation;
        player.respawnMe = false;
    }
}
