using UnityEngine;
using System.Collections;

public class Tilt : MonoBehaviour {
	public int TiltSpeed = 16;
	// Use this for initialization
	void Start () {
		//transform.Rotate (Vector3.
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.identity;
		if (transform.localEulerAngles.y != 0){
			transform.eulerAngles=new Vector3(transform.eulerAngles.x,0,transform.eulerAngles.z);
		}
		//transform.rotation = Quaternion.identity;
		if ((Input.GetKey ("up")) ){// & (transform.eulerAngles.x < 20) || (transform.eulerAngles.x > 340)){
			transform.Rotate (Vector3.right, Time.deltaTime * TiltSpeed);
		}
		if ((Input.GetKey ("right")) ){// & (transform.eulerAngles.z < 20) || (transform.eulerAngles.z > 340)){
			transform.Rotate (Vector3.back, Time.deltaTime * TiltSpeed);
		}
		if ((Input.GetKey ("down")) ){// & (transform.eulerAngles.x < 20) || (transform.eulerAngles.x > 340)){
				transform.Rotate (Vector3.left, Time.deltaTime * TiltSpeed);
		}
		if ((Input.GetKey ("left")) ){// & (transform.eulerAngles.z < 20) || (transform.eulerAngles.z > 340)){
			transform.Rotate (Vector3.forward, Time.deltaTime * TiltSpeed);
		}
		//if (Input.GetKey (KeyCode.None)){
		//	transform.rotation = Quaternion.identity;
		//}
	}
}
