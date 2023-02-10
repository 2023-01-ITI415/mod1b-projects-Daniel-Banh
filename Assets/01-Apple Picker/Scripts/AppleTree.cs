using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

	public GameObject applePrefab;
	public float speed = 1f;
	public float leftAndRightEdge = 20f;
	public float chanceToChangeDirections = 0.2f;
	public float secondsBetweenAppleDrops = 1.5f;


	// Use this for initialization
	void Start()
	{
		Invoke("DropApple", 2f);

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		if (pos.x < -leftAndRightEdge)
		{
			speed = Mathf.Abs(speed);
		}
		else if (pos.x > leftAndRightEdge)
		{
			speed = -Mathf.Abs(speed);
		}

	}

	void FixedUpdate()
	{
		if (Random.value < chanceToChangeDirections)
		{
			speed *= -1;
		}
	}

	void DropApple()
	{
		GameObject apple = Instantiate<GameObject>(applePrefab);
		apple.transform.position = transform.position;
		Invoke("DropApple", secondsBetweenAppleDrops);
	}
}