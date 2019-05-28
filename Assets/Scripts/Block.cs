﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

	[SerializeField] AudioClip breakSound;
	[SerializeField] int maxHits;
	[SerializeField] Sprite[] hitSprites;


	[SerializeField] int timesHit; // serialized for debug purposes

	//cached reference
	Level level;

	private void Start(){
		CountBreakableBlocks();
	}

	private void CountBreakableBlocks(){

		level = FindObjectOfType<Level>();
		if(tag == "Breakable"){
			level.CountBlocks();
		}
	}
    
    private void OnCollisionEnter2D(Collision2D collision){
    	if(tag == "Breakable"){
    		HandleHit();
    	}
    }

    private void HandleHit(){
    	timesHit++;
		if(timesHit >= maxHits){
			DestroyBlock();
		}else{
			ShowNextHitSprite();
		}
    }

    private void ShowNextHitSprite(){
    	int spriteIndex = timesHit-1;
    	GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock(){
    	FindObjectOfType<GameStatus>().AddToScore();

    	AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    	Destroy(gameObject);
    	level.BlockDestroyed();
    }
}
