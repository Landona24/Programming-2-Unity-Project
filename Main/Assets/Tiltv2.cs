using UnityEngine;
using System.Collections;
public class Tiltv2 : MonoBehaviour {
	public float TiltSpeed = 32;
	public float limitUpLeft = 30;
	public float limitDownRight = 330;
	public float AxisVertical = Input.GetAxis ("Vertical");
	public float AxisHorizontal = Input.GetAxis ("Horizontal");

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		AxisVertical = Input.GetAxis ("Vertical");
		AxisHorizontal = Input.GetAxis ("Horizontal");

		if ((Input.GetKey ("home"))) {
			while (transform.localEulerAngles.x != 0 && transform.localEulerAngles.z != 0){
				transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.identity, TiltSpeed * Time.deltaTime);
			}
		}
		else{
			if ((Input.GetAxis ("Vertical") > 0)){
				transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.Euler(limitDownRight,180,transform.localEulerAngles.z), (TiltSpeed * (Input.GetAxis ("Vertical"))) * Time.deltaTime);
			}
			if ((Input.GetAxis ("Vertical") < 0)){
					transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(limitUpLeft,180,transform.localEulerAngles.z), (TiltSpeed * -(Input.GetAxis ("Vertical"))) * Time.deltaTime);
			}
			if ((Input.GetAxis ("Horizontal") < 0)){
						transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.Euler(transform.localEulerAngles.x,180, limitDownRight), (TiltSpeed * -(Input.GetAxis ("Horizontal"))) * Time.deltaTime);
			}
			if ((Input.GetAxis ("Horizontal") > 0)){	
							transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(transform.localEulerAngles.x,180,limitUpLeft), (TiltSpeed * (Input.GetAxis ("Horizontal"))) * Time.deltaTime);
			}
		}
	}
}
