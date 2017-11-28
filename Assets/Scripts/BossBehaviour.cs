using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	public GameObject shot;
    public Boundary boundary;
	public Transform bossShotSpawn;
    public int speed;
    public int bossLife;
    public int direction;
	private float Schuss;

	// Use this for initialization
	void Start ()
    {
        bossLife = 30;
	}

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;

        if (bossLife == 0)
        {
            Destroy(gameObject);
        }

        Schuss = Random.value;

        if (Schuss < 0.01)
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
