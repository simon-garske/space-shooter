using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	public GameObject shot;
    public GameObject explosion;
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
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        GameObject BossLife = GameObject.FindWithTag("BossLife");
        if (BossLife != null)
        {
            BossLifeText = BossLife.GetComponent<GUIText>();
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

        if (Schuss < 0.06)
        {
            Instantiate(shot, bossShotSpawn.position, bossShotSpawn.rotation);
        }
        if (Schuss < 0.008)
        {
            for (int i =0; i<9; i++)
            {
                Instantiate(shot, bossShotSpawn.position, bossShotSpawn.rotation);
            }
        }
        BossLifeUpdate();
        if (gameController.bossFight == false)
        {
            BossLifeText.text = "";
        }


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
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void BossLifeUpdate()
    {
        BossLifeText.text = "HP:" + bossLife;
    }
}
