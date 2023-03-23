using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
	public ScoreCounter scoreCounter;
	public Text scoreGT;


	// Use this for initialization
	void Start()
	{
		GameObject scoreGO = GameObject.Find( "ScoreCounter" );
		scoreCounter = scoreGO.GetComponent<ScoreCounter>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 mousePos2D = Input.mousePosition;  
		mousePos2D.z = -Camera.main.transform.position.z; 
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter( Collision coll ) {

		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.CompareTag("Apple") ) { 
			Destroy( collidedWith );
			scoreCounter.score += 100;
			HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score ); 
		}

	}
}