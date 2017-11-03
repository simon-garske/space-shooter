using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public Boundary boundary;
    public int speed;
    public int direction;

	// Use this for initialization
	void Start ()
    {
        direction = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
            GetComponent<Rigidbody>().velocity = transform.right * speed;
    }
    private void OnTriggerExit(Collider other )
    {
        speed *= -1;
    }
}
