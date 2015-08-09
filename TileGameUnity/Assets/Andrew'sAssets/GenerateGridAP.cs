using UnityEngine;
using System.Collections;

public class GenerateGridAP : MonoBehaviour {

	private int noRows = 5;
	private int noCols = 5;

	// Use this for initialization
	void Start () {

		for (int i = 0; i< noRows; i++) {
			for (int j = 0; j< noCols; j++) {
				GameObject square = new GameObject ("square-" + i + "-" + j, typeof(Plane));
				square.transform.parent = GameObject.Find ("GamePanel").transform;
				square.AddComponent<CanvasRenderer> ();
				square.AddComponent<UnityEngine.UI.Image> ();
	
				square.transform.localScale = new Vector3 (0.8f, 0.8f, 1f);
				square.transform.localPosition = new Vector3 (85 * i - 200, 85 * j - 200, 0f);
			//square.transform.rotation =  new Quaternion(1.5f, 1f, 1f, 0f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
