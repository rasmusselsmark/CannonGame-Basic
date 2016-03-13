﻿using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	public GameObject CannonBarrel;
	public GameObject CannonBallPrefab;

	private float _firePower = 10f;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.UpArrow))
		{
			RotateBarrel (1);
		}
		else if (Input.GetKey (KeyCode.DownArrow))
		{
			RotateBarrel (-1);
		}
		else if (Input.GetKeyUp (KeyCode.Space))
		{
			FireCannon (_firePower);
		}
	}

	void RotateBarrel (int degrees)
	{
		CannonBarrel.transform.Rotate (new Vector3 (0, 0, degrees));
	}

	private void FireCannon (float power)
	{
		Vector2 position =
			CannonBarrel.transform.position + CannonBarrel.transform.right * 0.8f;

		GameObject cannonBall = Instantiate (
			                              CannonBallPrefab,
			                              position,
			                              CannonBarrel.transform.rotation) as GameObject;

		cannonBall.GetComponent<Rigidbody2D> ().AddForce (
			CannonBarrel.transform.right * power,
			ForceMode2D.Impulse);
		Destroy (cannonBall.gameObject, 30);
	}
}