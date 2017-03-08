using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public string horizontal;
    public string vertical;
    public string button1;
    public string button2;
    public string lockButton;
    public string shape;
    public string player;

    //Dead for internal use, respawnMe used in RespawnScore
    private bool dead = false;
    public bool respawnMe = false;
    public Rigidbody rb;
    public Vector3 startLocation;

    public PowerupManager pmanager;
    StandardKnockback skb;

    private float speed;
    private float actionDelay = 0f;
    float respawnDelay = 2.0f;

    private AudioSource wooshSound;
    private ParticleSystem wooshParts;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        skb = GetComponent<StandardKnockback>();
        wooshSound = GetComponent<AudioSource>();
        wooshParts = GetComponent<ParticleSystem>();

        startLocation = this.transform.position;
        speed = 20;
    }

    void FixedUpdate()
    {
        //Presetting the values for these variables
        float moveHorizontal = Input.GetAxis(horizontal);
        float moveVertical = Input.GetAxis(vertical);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Lock Code (A little messy because I didn't preplan this feature rip)
        if (Input.GetButton(lockButton) && shape == "Cube")
        {
            if (player == "1")
            {
                moveHorizontal = Input.GetAxis("P11Horizontal");
                moveVertical = Input.GetAxis("P11Vertical");
                if (moveHorizontal < 0.8 && moveHorizontal > -0.8)
                    moveHorizontal = 0f;
                if (moveVertical < 0.8 && moveVertical > -0.8)
                    moveVertical = 0f;
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            }
            else if (player == "2")
            {
                moveHorizontal = Input.GetAxis("P21Horizontal");
                moveVertical = Input.GetAxis("P21Vertical");
                if (moveHorizontal < 0.8 && moveHorizontal > -0.8)
                    moveHorizontal = 0f;
                if (moveVertical < 0.8 && moveVertical > -0.8)
                    moveVertical = 0f;
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            }

            rb.AddForce(movement * speed);
        }


        //Regular Movement Code
        else
        {
            if (moveHorizontal < 0.8 && moveHorizontal > -0.8)
                moveHorizontal = 0f;
            if (moveVertical < 0.8 && moveVertical > -0.8)
                moveVertical = 0f;

            rb.AddForce(movement * speed);
        }

        //Dash code
        actionDelay -= Time.deltaTime;
        if (Input.GetAxis(button1) > 0.5 && actionDelay < 0)
        {
            wooshSound.Play();
            wooshParts.Play();
            rb.AddForce(movement * 800);
            actionDelay = 2.0f;
        }
    }

    void Update()
    {
        if (dead)
        {
            respawnDelay -= Time.deltaTime;
            if (respawnDelay < 0)
            {
                dead = false;
                respawnMe = true;
                respawnDelay = 2.0f;
                skb.dead = false;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PowerUp(Clone)")
        {
            pmanager.pickedUp();
            Destroy(other.gameObject);
            bonusKnockback();
        }
    }

    void bonusKnockback()
    {

        skb.timer = 7f;
        skb.poweredUp = true;
    }

    public void triggered()
    {
        skb.dead = true;
        this.rb.useGravity = true;
        this.rb.constraints = RigidbodyConstraints.None;
        dead = true;
    }
    
}
