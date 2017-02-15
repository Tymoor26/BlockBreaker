using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int amountOfBricks = 0;
    public AudioClip crack;
    public GameObject smoke; 

    private int times_hit;
    private LevelManager levelManager;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        times_hit = 0;
        isBreakable = (this.tag == "Breakable");
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (isBreakable) { amountOfBricks++; }
        //print("amount on screen " + amountOfBricks);
    }

    // Update is called once per frame
    void Update () {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
        if (isBreakable) { HandleHits(); }
    }

    void HandleHits()
    {
        times_hit++;
        int max_hits = hitSprites.Length + 1;
        if (times_hit >= max_hits)
        {
            amountOfBricks--;
            //print("amount left " + amountOfBricks);
            levelManager.LastBrickHit();
            GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
        else  { LoadSprites(); }


    }
    void LoadSprites()
    {
        int spriteIndex = times_hit - 1;
        if (hitSprites[spriteIndex])  { this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; }
        else { Debug.LogError("Brick sprite missing" ); }
    }
}
