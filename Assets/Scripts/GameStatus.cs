using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

	[Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
	[SerializeField] int pointsPerBlockDestroyed = 50;

	[SerializeField] int currentScore = 0;
	[SerializeField] TextMeshProUGUI scoreText;

	private void Awake(){ 
		// Singleton Pattern, a way to have our score count from one level to another, instead of destroying it and starting form zero
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length; // gets the count of the objecct
		if(gameStatusCount > 1){
			Destroy(gameObject);
		}else{
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start(){
		scoreText.text = currentScore.ToString();
	}

    // Update is called once per frame
    void Update()
    {
    	Time.timeScale = gameSpeed;
    	
        
    }

    public void AddToScore(){
    	currentScore+= pointsPerBlockDestroyed;
    	scoreText.text = currentScore.ToString();
    }

    public void ResetGame(){
    	Destroy(gameObject);
    }
}
