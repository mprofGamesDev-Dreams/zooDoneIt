using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour
{
	private Vector2 MousePos;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log (MousePos);
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			print (hit.collider.name);
		}
	}
}
