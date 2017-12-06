using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	public GameObject shot;
    private GameController gameController;
    public Boundary boundary;
	public Transform bossShotSpawn;
    public int speed;
    public int bossLife;
    public int direction;
	private float Schuss;
    public GUIText BossLifeText;


    // Use this for initialization
    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        bossLife = 30;
	}

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;

        if (bossLife == 0)
        {
            Destroy(gameObject);
            gameController.AddScore(250);
            gameController.bossFight = false;
            gameController.waveCounter++;
        }

        Schuss = Random.value;

        if (Schuss < 0.03)
        {
            Instantiate(shot, bossShotSpawn.position, bossShotSpawn.rotation);
        }
        BossLifeText.text = "HP:" + bossLife ;
    }
    
    private void OnTriggerExit(Collider other )
	{
		if (other.tag == "BossBoundary") 
		{
			speed *= -1;
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot")
        {
            bossLife--;
        }
    }
}
