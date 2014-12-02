using UnityEngine;
using System.Collections;

public class Tilt : MonoBehaviour {
	public int tiltSpeed = 32;
	public int limitUpLeft = 20;
	public int limitDownRight = 340;
	public float RX;
	public float RZ;
	// Use this for initialization
	void Start () {
		//transform.Rotate (Vector3.
	}
	
	// Update is called once per frame
	void Update () {
		RX = transform.localEulerAngles.x;
		RZ = transform.localEulerAngles.z;

		//if (transform.localEulerAngles.y != 0){
		transform.eulerAngles=new Vector3(transform.eulerAngles.x,0,transform.eulerAngles.z);
		//}
		//transform.rotation = Quaternion.identity;
//limiter
		if (RX > limitUpLeft && RX < limitDownRight){
			if (RX > limitUpLeft){
				transform.eulerAngles=new Vector3(limitUpLeft,0,transform.eulerAngles.z);
			}
			if (RX < limitDownRight){
				transform.eulerAngles=new Vector3(limitDownRight,0,transform.eulerAngles.z);
			}
		}
//movement
		else{ 
		//if (RX <= limitUpLeft && RX >= limitDownRight){
			if ((Input.GetKey ("up")) ){// & (transform.eulerAngles.x < limitUpLeft) || (transform.eulerAngles.x > limitDownRight)){
				transform.Rotate (Vector3.right, Time.deltaTime * tiltSpeed);
			}
			if ((Input.GetKey ("down")) ){// & (transform.eulerAngles.x < limitUpLeft) || (transform.eulerAngles.x > limitDownRight)){
				transform.Rotate (Vector3.left, Time.deltaTime * tiltSpeed);
			}
		}


		transform.eulerAngles=new Vector3(transform.eulerAngles.x,0,transform.eulerAngles.z);

//limiter
		if (RZ > limitUpLeft && RZ < limitDownRight){
			if (RZ > limitUpLeft){
				transform.eulerAngles=new Vector3(transform.eulerAngles.x,0,limitUpLeft);
			}
			if (RZ < limitDownRight){
				transform.eulerAngles=new Vector3(transform.eulerAngles.x,0,limitDownRight);
			}
		}
//movement
		else{
		//if (RZ <= limitUpLeft && RZ >= limitDownRight){
			if ((Input.GetKey ("right")) ){// & (transform.eulerAngles.z < limitUpLeft) || (transform.eulerAngles.z > limitDownRight)){
				transform.Rotate (Vector3.back, Time.deltaTime * tiltSpeed);
			}
			
			if ((Input.GetKey ("left")) ){// & (transform.eulerAngles.z < limitUpLeft) || (transform.eulerAngles.z > limitDownRight)){
				transform.Rotate (Vector3.forward, Time.deltaTime * tiltSpeed);
			}
		}

		//transform.rotation = Quaternion.identity;


		//if (Input.GetKey (KeyCode.None)){
		//	transform.rotation = Quaternion.identity;
		//}
	}
}
