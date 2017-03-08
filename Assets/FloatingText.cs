using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour {

    float counter = 0;
    float temp = 0;
	// Update is called once per frame
	void Update () {
        counter = Time.realtimeSinceStartup;

        temp = Mathf.Cos(counter * 2.2f) * 20;
        this.transform.position = new Vector3(this.transform.position.x, 137 + temp, this.transform.position.z);
    }
}
