using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public static Hero s;
	public static GameObject character;
	public GameObject POV;
	public GameObject floor;
	public float runSpeed = 8f;
	public float jumpSpeed = 1.5f;
	public float jumpHeight = 5f;
	public float edgesZ = 2f;
	public bool _____________________;
	public bool onFight;
	public bool onWalk;
	public bool landing;
	public float initialPosZ;
	public bool jumping;
	public float edgeLeftX;
	public float edgeRightX;

	// Use this for initialization
	void Start () {
		s = this;
		character = this.gameObject;
		Vector3 pos = transform.position;
		jumping = false;
		landing = false;
		onWalk = true;
		initialPosZ = pos.z;
	}
	
	// Update is called once per frame
	void Update () {
		float axisX = Input.GetAxis("Horizontal");
		Vector3 pos = transform.position; 
		//if()
		if((pos.x>edgeLeftX || axisX > 0 )&& (pos.x<edgeRightX || axisX < 0))	
			pos.x += axisX * runSpeed * Time.deltaTime;
		float axisY = Input.GetAxis("Vertical");
		float actualZ = pos.z;
		if((actualZ > initialPosZ - edgesZ && axisY<0) || (actualZ < initialPosZ + edgesZ && axisY>0))
			pos.z += axisY * runSpeed * 2 * Time.deltaTime;
		transform.position = pos;

		if (Input.GetButtonDown("Jump")&&jumping==false&&landing==false)
		{
			RaycastHit hit;
			if(Physics.Raycast (transform.position, Vector3.down,out hit,1f)){
				jumping = true;
				runSpeed=.5f;
			}
		}
		if(jumping){
			if(pos.y<jumpHeight){
				print ("hi");
				pos.y += jumpSpeed * Time.deltaTime;
				transform.position = pos;
			}
			else{
				landing = true;
				jumping = false;
			}
		}

		if(landing)
		{
			RaycastHit hit;
			if(Physics.Raycast (transform.position, Vector3.down,out hit,1f))
			{
				landing = false;
				runSpeed=8f;
			}
			else
			{
				print ("hi");
				pos.y -= jumpSpeed / 2 * Time.deltaTime;
				transform.position = pos;
			}
		}
		if(Input.GetButtonDown("Fire1"))
		{
			resetEdges();
		}
	}

	public void startJumping(){

//	
	}

	public void setEdges(){
		onWalk = false;
	}

	public void resetEdges()
	{
		onWalk = true;
		POVBehaivour.s.eliminateLimit();
	}
}
