using UnityEngine;
using System.Collections;

public class POVBehaivour : MonoBehaviour {

	public float borderX = 7f;
	public GameObject focus;
	public GameObject limit;
	public bool onMotion;
	public static POVBehaivour s;
	// Use this for initialization
	void Start () {
		s = this;
		onMotion = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.gameObject.transform.position;
		if(onMotion){
			if(focus.transform.position.x > pos.x + borderX)
				pos.x = focus.transform.position.x - borderX;

			else if(focus.transform.position.x < pos.x - borderX)
				pos.x = focus.transform.position.x + borderX;

			//this.gameObject.transform.position = pos;
			this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position,pos,.1f);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.layer == 10){
			limit = col.gameObject;
			onMotion = false;
			Vector3 pos = this.gameObject.transform.position;
			Hero.s.setEdges();
		}
	}

	public void eliminateLimit(){
		Destroy(limit);
		onMotion = true;
	}
}
