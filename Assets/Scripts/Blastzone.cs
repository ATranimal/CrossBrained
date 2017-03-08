using UnityEngine;
using System.Collections;

public class Blastzone : MonoBehaviour {

    GameObject p11;
    GameObject p12;
    GameObject p21;
    GameObject p22;

    void Start()
    {
        p11 = GameObject.Find("Player11");
        p12 = GameObject.Find("Player12");
        p21 = GameObject.Find("Player21");
        p22 = GameObject.Find("Player22");
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player11")
        {
            p11.GetComponent<PlayerController>().triggered();
        }
        if (other.gameObject.name == "Player12")
        {
            p12.GetComponent<PlayerController>().triggered();
        }
        if (other.gameObject.name == "Player21")
        {
            p21.GetComponent<PlayerController>().triggered();
        }
        if (other.gameObject.name == "Player22")
        {
            p22.GetComponent<PlayerController>().triggered();
        }

    }
}
