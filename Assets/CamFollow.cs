using UnityEngine;
using System.Collections;

public class CamFollow: MonoBehaviour {

	public static GameObject camgame;
	public GameObject POVObject;
	public float distance = -8f;
	public float height = 3;
	public float fieldOfView = 10f;

	// Use this for initialization
	void Start () {
		camgame = this.gameObject;
		Vector3 pos = camgame.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (
			POVObject.transform.position.x,
			POVObject.transform.position.y + height,
			POVObject.transform.position.z + distance
			);
		camgame.transform.position = pos;
		Hero.s.edgeLeftX = pos.x - fieldOfView;
		Hero.s.edgeRightX = pos.x + fieldOfView;
	}
}
