using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState {

	public int noRows;
	public int noCols;
	public List<List<bool>> gameState;

	// Use this for initialization
	public GameState (int numberRows, int numberCols) {
		noRows = numberRows;
		noCols = numberCols;

		gameState = new List<List<bool>> ();

		for(int i = 0; i< noRows;i++)
		{
			List<bool> row = new List<bool>();

			for(int j = 0; j< noCols; j++)
			{
				row.Add(false);
			}
			gameState.Add(row);
		}
		Debug.Log ("GameState Instantiated");

	}

	public void AddClick(int row, int col)
	{
		gameState [row] [col] = true;
	}

}
