using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellDetails
{
	public int RowIndex;
	public int ColumnIndex;
}

[System.Serializable]
public class TowerDefense
{
	public GamePlay RowIndex;
	public int ColumnIndex;
}

public class GamePlay : MonoBehaviour {
	public GameObject CoinsObject;
	// Use this for initialization
	void Start () {
//		StartCoroutine(GeneratePlayer ());
//		InvokeRepeating ("GenerateEnemy", 0, 3f);
//		InvokeRepeating ("RandomCoin", 0, 2f);
 	}
	public void GeneratePlayer(CellDetails playerPosition){
		GamePlayBusses.instance.playerObject.transform.position = GamePlayBusses.instance.getCellByNumber (playerPosition).transform.position;
		GamePlayBusses.instance.playerObject.transform.position += Vector3.up * Time.deltaTime * 30;
		GamePlayBusses.instance.playerObject.StartPlay ();
	}
	public void StartGenerateCoins(){
		InvokeRepeating ("RandomCoin", 0, 1f);
	}
	public void GenerateEnemy (CellDetails Position){
		GameObject getRandomEnemy = GamePlayBusses.instance.EnimiesPrefab [Random.Range (0, GamePlayBusses.instance.EnimiesPrefab.Length)];
		Instantiate (getRandomEnemy);
//		int randomRow =  //Random.Range (0, GamePlayBusses.instance.playingGrid.numberOfRows);
//		int randomCol = //Random.Range (0, GamePlayBusses.instance.playingGrid.numberOfColumns);
//		CellDetails cellToAdd = new CellDetails ();
//		cellToAdd.RowIndex = randomRow;
//		cellToAdd.ColumnIndex = randomCol;
		getRandomEnemy.transform.position = GamePlayBusses.instance.getCellByNumber (Position).transform.position;

	}
	public void RandomCoin(){
		Vector3 newVec = new Vector3(Random.Range (GamePlayBusses.instance.getPlayAreaBounds().MinX, GamePlayBusses.instance.getPlayAreaBounds().MaxX),
			5,
			Random.Range(GamePlayBusses.instance.getPlayAreaBounds().MinY, GamePlayBusses.instance.getPlayAreaBounds().MaxY));
		GameObject Coin = Instantiate (CoinsObject);
		Coin.transform.position = newVec;

	}
	// Update is called once per frame
	void FixedUpdate () {

	}
}
