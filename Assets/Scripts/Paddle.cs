using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] float screenWithInUnits = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

    	Vector2 paddlePos = new Vector2(Input.mousePosition.x/Screen.width*screenWithInUnits,0.25f);
    	transform.position = paddlePos;
        
    }
}
