using UnityEngine;
using System.Collections;

public class LoadScene2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Loads the Game Scene Specifically for my game
    public void LoadAScene()
    {
        Application.LoadLevel("StephenGameScene");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
