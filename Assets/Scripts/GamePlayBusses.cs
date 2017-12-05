using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayBusses : MonoBehaviour {
	public static GamePlayBusses instance;
	public GridGenerator playingGrid;
	public playerMovment playerObject;
	public GameObject[] EnimiesPrefab;
	public GameUiHandler UiInGame;
	public GamePlay gamePlay;
	public XMLLoader xmlLoader;
	private int collectedCoins;
	private float healthAmount;

	public float HealthAmount {
		get {
			return healthAmount;
		}
		set {
			healthAmount = value;
			UiInGame.SetLifeValue (Health, HealthAmount);
		}
	}

	public float health;

	public float Health {
		get {
			return health;
		}
		set {
			health = value;
			HealthAmount = value;
		}
	}

	public int CollectedCoins {
		get {
			return collectedCoins;
		}
		set {
			collectedCoins = value;
			UiInGame.SetCoinsValue (collectedCoins);
		}
	}
	public void GenerateGrid(){
		playingGrid.DrawUpdateGrid ();
	}
	public void GridGeneratedSuccess(){
		gamePlay.GeneratePlayer (xmlLoader.PlayerPosition);
		Health = xmlLoader.PlayerHealth;
		for (int i = 0; i < xmlLoader.turrets.Count; i++) {
			gamePlay.GenerateEnemy (xmlLoader.turrets [i].Position);
		}
		gamePlay.StartGenerateCoins ();
	}
	void Awake(){
		HealthAmount = Health;
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}
	}
	public GameObject getCellByNumber(CellDetails cellCoordinates){
		return playingGrid.GetCellByCoordinate (cellCoordinates);
	}
	public bounds getPlayAreaBounds(){
		return playingGrid.PlayGroundBounds;
	}
}
