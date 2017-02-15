using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("Level load requested for: " + name);
		Application.LoadLevel(name);
	}

	public void QuitRequest(string name){
		Debug.Log("I want to quit");
		Application.Quit();
	}

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void LastBrickHit()
    {
        if (Brick.amountOfBricks <= 0) { LoadNextLevel(); }
    }
}
