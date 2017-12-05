using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUiHandler : MonoBehaviour {
	public Text CoinsText;
	public Image LifeBarImage;
	public GameObject gameOverUI;
	// Use this for initialization
	void Start () {
		
	}
	public void SetLifeValue(int MaxLife,int CurrentAmount){
		LifeBarImage.fillAmount = (float)CurrentAmount / (float)MaxLife;
		if (LifeBarImage.fillAmount <= 0) {
			gameOver ();
		}
	}
	public void SetCoinsValue(int Coins){
		CoinsText.text = Coins.ToString ();
	}
	public void gameOver(){
		gameOverUI.SetActive (true);
		Time.timeScale = 0;
	}
	public void PlayAgain (){
		Scene loadedLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (loadedLevel.buildIndex);
		Time.timeScale = 1;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
