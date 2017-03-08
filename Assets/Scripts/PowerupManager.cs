using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour {

    private GameObject topLeft;
    private GameObject topRight;
    private GameObject bottomLeft;
    private GameObject bottomRight;

    public GameObject powerUp;
    ParticleSystem theParticles;

    public float powerupTimer = 1f;

    // Use this for initialization
    void Start () {
        topLeft = GameObject.Find("TopLeftPowerup");
        topRight = GameObject.Find("TopRightPowerup");
        bottomLeft = GameObject.Find("BottomLeftPowerup");
        bottomRight = GameObject.Find("BottomRightPowerup");
        theParticles = topLeft.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        powerupTimer -= Time.deltaTime;
    
        if (powerupTimer < 0)
        {
            powerupTimer = 5000000;
            float temp = Random.value;
            
            if (temp >= 0 && temp < 0.25)
            {
                Instantiate(powerUp, topLeft.transform.position, Quaternion.identity);
                theParticles = topLeft.GetComponent<ParticleSystem>();

            }
            if (temp >= 0.25 && temp < 0.5)
            {
                Instantiate(powerUp, topRight.transform.position, Quaternion.identity);
                theParticles = topRight.GetComponent<ParticleSystem>();
            }
            if (temp >= 0.5 && temp < 0.75)
            {
                Instantiate(powerUp, bottomLeft.transform.position, Quaternion.identity);
                theParticles = bottomLeft.GetComponent<ParticleSystem>();
            }
            if (temp >= 0.75 && temp <= 1)
            {
                Instantiate(powerUp, bottomRight.transform.position, Quaternion.identity);
                theParticles = bottomRight.GetComponent<ParticleSystem>();
            }

            theParticles.Play();
        }

	}

    public void pickedUp()
    {
        powerupTimer = 7f;
        theParticles.Stop();
    }
}
