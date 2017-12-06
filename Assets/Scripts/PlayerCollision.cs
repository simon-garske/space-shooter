using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public int shield;
    public GameController gameController;
    public GUIText shieldText;
    public bool gameOver;


	void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameController != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

    }

    void Update ()
    {
		shieldText.text = "";
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossShot")
        {
            shield--;

            if (shield == 0)
            {
                gameController.GameOver();
                Destroy(gameObject);
            }
        }
    }
}
