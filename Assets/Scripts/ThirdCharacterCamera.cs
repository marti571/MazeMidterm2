using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCharacterCamera : MonoBehaviour {
	[SerializeField]
	private Transform target;
	[SerializeField]
	private Vector3 offsetPosition;
	[SerializeField]
	private Space offsetPositionspace = Space.Self;
	[SerializeField]
	private bool lookat = true;

	private void LateUpdate()
	{
		Refresh();
	}
	public void Refresh()
	{
		if(target == null)
		{
			//Debug.LogWarning("Missing target ref !", this);
			return;
		}
		if(offsetPositionspace == Space.Self)
		{
			transform.position = target.TransformPoint(offsetPosition);
		}
		else
		{
			transform.position = target.position + offsetPosition;
		}
		if (lookat)
		{
			transform.LookAt(target);
		}
		else
		{
			transform.rotation = target.rotation;
		}
	}
	// public GameObject player;
	// private Vector3 offset;
	// // Use this for initialization
	// void Start () {
	// 	offset = transform.position - player.transform.position;
	// }
	
	// // Update is called once per frame
	// void LateUpdate () {
	// 	transform.position = player.transform.position + offset;
	// 	transform.LookAt(player.transform);
	// 	//transform.rotation = target.rotation;
	// }
}
