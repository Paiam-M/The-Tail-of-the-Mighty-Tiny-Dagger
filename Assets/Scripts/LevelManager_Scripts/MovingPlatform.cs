using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Vector2   currentPoint;
    public Vector2[] pointArray;
    public int index;
    public float speed;

    public GameObject PauseUI;
    public GameObject InventoryUI;

	// Use this for initialization
	void Start () {
        speed = 0.05f;
        index = 0;
        currentPoint = pointArray[index];
	}
	
	// Update is called once per frame
	void Update () {
        // This is the only way that I know of to stop the platform from moving 
        // when the player pauses the game (update the two lines of code below later)
        if(!PauseUI.activeSelf && !InventoryUI.activeSelf)
            transform.position = Vector2.MoveTowards(transform.position, currentPoint, speed);

        if (transform.position.x == currentPoint.x && transform.position.y == currentPoint.y)
        {
            index++;
            if (index == pointArray.Length)
                index = 0;
            currentPoint = pointArray[index];
        }

	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.transform.position = new Vector2( (transform.position.x + collision.transform.position.x)/2 , (transform.position.y / 3.08f ));

        //collision.transform.position = new Vector2(transform.position.x, (transform.position.y / 6) );
    }
}
