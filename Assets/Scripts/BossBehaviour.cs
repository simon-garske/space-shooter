using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	public GameObject shot;
    public Boundary boundary;
	public Transform bossShotSpawn;
    public int speed;
    public int direction;
	private float Schuss;

	// Use this for initialization
	void Start ()
    {
        direction = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
		Schuss = Random.value;

		if (Schuss < 0.1) 
		{
			Instantiate(shot, bossShotSpawn.position, bossShotSpawn.rotation);
		}
    }
    private void OnTriggerExit(Collider other )
	{
		if (other.tag == "BossBoundary") 
		{
			speed *= -1;
		}
	}
}
