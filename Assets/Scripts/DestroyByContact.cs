using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	private PlayerController playerController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController =  gameControllerObject.GetComponent <GameController>();
		}
		if (gameControllerObject == null) 
		{
			Debug.Log ("Cannot find 'Game Controller' script");
		}

		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null)
		{
			playerController =  playerControllerObject.GetComponent <PlayerController>();
		}
		if (playerController == null) 
		{
			Debug.Log ("Cannot find 'Player Controller' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy")) 
		{
			return;	
		}
		if (explosion != null) 
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.CompareTag ("Player")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			playerController.lives--;
			gameController.DisplayLives (playerController.lives);

			if (playerController.lives == 0) {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.AddScore (scoreValue);
				Destroy (other.gameObject);
				Destroy (gameObject);
				gameController.GameOver ();
			}
		} 
		else if (other.tag != "Player")
		{
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
