using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted;
    private Rigidbody2D rigi2D;
    private AudioSource audio;

    private void Awake()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        //print(paddleToBallVector);
        hasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) { this.transform.position = paddle.transform.position + paddleToBallVector; }

        if (Input.GetMouseButtonDown(0))
        {
            //print("Mouse clicked, launch ball");
            this.rigi2D.velocity = new Vector2(2f, 10f);
            hasStarted = true;
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        
        if (hasStarted) {
            audio.Play();
            this.rigi2D.velocity += tweak;
        }
    }
}
