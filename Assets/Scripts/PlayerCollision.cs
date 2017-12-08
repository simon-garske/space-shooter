using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public int shield;
    private int shieldRegeneration;
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
        shieldRegeneration = 100;
    }

    void Update ()
    {
        UpdateShield();
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

    private void UpdateShield()
    {
        if (gameController.shieldScore >= shieldRegeneration)
        {
            shield++;
            gameController.shieldScore = 0;
            shieldRegeneration += 20;
        }
        shieldText.text = "Schildstärke bei " + shield + "0%";
    }

}
