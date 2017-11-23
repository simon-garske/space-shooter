using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public Boundary boundary;
    public int speed;
    public int bossLife;

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
    }

     void OnTriggerEnter(Collider other)
    {
        speed *= -1;
    }
 
}
