using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {

	//board position
	public float startX;
	public float startY;

	//tiles
	public Transform tiles;

	public Camera mainCamera;

	public static int BOARD_SIZE = 5;


	// Use this for initialization
	void Start () {
		createBoardOffLine ();			
	}

	// Update is called once per frame
	void Update () {

	}

	void createBoardOffLine(){

		float tileX = tiles.GetComponent<SpriteRenderer> ().bounds.size.x;
		float tileY = tiles.GetComponent<SpriteRenderer> ().bounds.size.y;
		float yCor	= mainCamera.ScreenToWorldPoint (new Vector3 (0, startY, 0f)).y;

		for (int i = 0; i < BOARD_SIZE; i++) {
			float xCor = mainCamera.ScreenToWorldPoint (new Vector3 (startX, 0, 0f)).x;
			for (int j = 0; j < BOARD_SIZE; j++) {
				Vector3 tilesPos = new Vector3 (xCor, yCor, 0f);
				Instantiate (tiles, tilesPos, Quaternion.identity);
				xCor += tileX;
			}
			yCor -= tileY;
		}
	}
}
