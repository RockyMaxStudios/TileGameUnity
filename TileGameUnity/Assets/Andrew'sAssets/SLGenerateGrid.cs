using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SLGenerateGrid : MonoBehaviour
{
	public Transform sceneCamera;
	public Transform planePrefab;
	private Camera cameraComponent;
	public int numberOfHorizontalRectangles = 5;
	public int numberOfVerticalRectangles = 5;
	public float spacingBetweenRectangles = 0.05f;
	private float screenWidthInWorldUnits;
	private float screenHeightInWorldUnits;
	[HideInInspector] public List<Transform> planes = new List<Transform>();
	
	void Start()
	{
		cameraComponent = sceneCamera.GetComponent<Camera>();
		
		screenHeightInWorldUnits = cameraComponent.orthographicSize * 2;
		screenWidthInWorldUnits = screenHeightInWorldUnits * cameraComponent.aspect;

		float squareSize = 47;



		for (int i = 0; i < numberOfHorizontalRectangles; i++)
			for (int j = 0; j < numberOfVerticalRectangles; j++)
		{
			Transform plane = GameObject.Instantiate(planePrefab);
			plane.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
			
			plane.rotation = Quaternion.Euler(-90, 0, 0);
			plane.transform.parent = GameObject.Find ("GamePanel").transform;
			float horizontalSpacing = cameraComponent.pixelWidth / numberOfHorizontalRectangles;
			float verticalSpacing = cameraComponent.pixelHeight / numberOfVerticalRectangles;
			/*plane.position = cameraComponent.ScreenToWorldPoint(new Vector3(horizontalSpacing * 0.5f + horizontalSpacing * i, 
			                                                                verticalSpacing * 0.5f + verticalSpacing * j, 
			                                                                1));
			
			plane.localScale = new Vector3(1 * cameraComponent.aspect / numberOfHorizontalRectangles - spacingBetweenRectangles/2,
			                               1, 
			                               1f / numberOfVerticalRectangles - spacingBetweenRectangles/2);
			*/
			plane.transform.localScale = new Vector3 ((float)(squareSize/100f), (float)(squareSize/100f), 1f);
			plane.transform.localPosition = new Vector3 ((squareSize + 5) * i - ((numberOfHorizontalRectangles/2f) * (squareSize + 5)) + (squareSize/2f), (squareSize + 5) * j - ((numberOfVerticalRectangles/2f) * (squareSize + 5)) + (squareSize/2f), 0f);
			

			planes.Add(plane);
		}
	}
}
