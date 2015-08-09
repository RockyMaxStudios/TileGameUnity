using UnityEngine;
using System.Collections;

public class GenerateGridAP : MonoBehaviour {

	private int noRows = 10;
	private int noCols = 10;
	private int screenWidth;
	private int screenHeight;

	// Use this for initialization
	void Start () {

		var sceneCamera = GameObject.Find ("Main Camera");
		screenWidth = sceneCamera.GetComponent<Camera> ().pixelWidth;
		screenHeight = sceneCamera.GetComponent<Camera> ().pixelHeight;

		float squareSize = 40;

		for (int i = 0; i< noRows; i++) {
			for (int j = 0; j< noCols; j++) {
				GameObject square = new GameObject ("square-" + i + "-" + j, typeof(Plane));
				square.transform.parent = GameObject.Find ("GamePanel").transform;
				square.AddComponent<CanvasRenderer> ();
				square.AddComponent<UnityEngine.UI.Image> ();

				square.transform.localScale = new Vector3 ((float)(squareSize/100f), (float)(squareSize/100f), 1f);
				square.transform.localPosition = new Vector3 ((squareSize + 5) * i - ((noRows/2f) * (squareSize + 5)) + (squareSize/2f), (squareSize + 5) * j - ((noCols/2f) * (squareSize + 5)) + (squareSize/2f), 0f);

				//square.transform.rotation =  new Quaternion(1.5f, 1f, 1f, 0f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
