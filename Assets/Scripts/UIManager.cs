using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//This class controls all the UI elements, including pause and score
public class UIManager : MonoBehaviour {

    public Text P1Text;
    public Text P2Text;

    public int P1Life;
    public int P2Life;

    private GameObject[] pauseObjects;
    private GameObject[] startObjects;
    private GameObject[] antiStartObjects;
    public GameObject respawnText;

    private bool gameStarted;
    public bool pauseEnabled = true;
    

    // Use this for initialization
    void Start () {
        Time.timeScale = 0;

        P1Text = GameObject.Find("Player 1 Life").GetComponent<Text>();
        P2Text = GameObject.Find("Player 2 Life").GetComponent<Text>();

        P1Life = 5;
        P2Life = 5;

        respawnText = GameObject.Find("Respawn");
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        startObjects = GameObject.FindGameObjectsWithTag("StartMenu");
        antiStartObjects = GameObject.FindGameObjectsWithTag("AntiStartMenu");

        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in antiStartObjects)
        {
            g.SetActive(false);
        }
        gameStarted = false;
        respawnText.SetActive(false);
    }
	
    void Update()
    {
        P1Text.text = P1Life.ToString();
        P2Text.text = P2Life.ToString();

        //Pausing
        if( ( Input.GetButtonDown("P1Start") || Input.GetButtonDown("P2Start") ) && gameStarted ==  true && pauseEnabled)
        {
            print(Time.timeScale);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                foreach (GameObject g in pauseObjects)
                {
                    g.SetActive(true);
                }
            }

            else if (Time.timeScale == 0)
            {

                Time.timeScale = 1;
                foreach (GameObject g in pauseObjects)
                {
                    g.SetActive(false);
                }
            }
        }

        //Starting
        if ((Input.GetButtonDown("P1Start") || Input.GetButtonDown("P2Start")) && gameStarted == false)
        {
            Time.timeScale = 1;
            foreach (GameObject g in startObjects)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in antiStartObjects)
            {
                g.SetActive(true);
            }
            gameStarted = true;
        }


    }

}
