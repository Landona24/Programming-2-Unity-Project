using UnityEngine;
using System.Collections;
public class Tiltv2 : MonoBehaviour {
	public GameObject Ball;
	public float TiltSpeed = 32;
	public float limitUpLeft = 30;
	public float limitDownRight = 330;
	public float AxisVertical = 0;
	public float AxisHorizontal = 0;
	public bool origin = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Ball.transform.position.y < -5){
			transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.identity, TiltSpeed * Time.deltaTime);
			if(transform.localEulerAngles.x == 0 && transform.localEulerAngles.z == 0){
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
		else{
			if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) {
				AxisVertical = Input.GetAxis ("Vertical");
				AxisHorizontal = Input.GetAxis ("Horizontal");
			}
			else{
				AxisVertical = 0;
				AxisHorizontal = 0;
			}
//			if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0){
//				AxisVertical = Input.GetAxis ("Mouse Y");
//				AxisHorizontal = Input.GetAxis ("Mouse X");
//			}

			if ((Input.GetKey ("home")) || origin) {
				if(transform.localEulerAngles.x != 0 && transform.localEulerAngles.z != 0){
					origin = true;
					transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.identity, TiltSpeed * Time.deltaTime);
				}
				else{origin = false;}
			}
			else{
				if (AxisVertical > 0){
					transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.Euler(limitDownRight,0,transform.localEulerAngles.z), (TiltSpeed * (AxisVertical)) * Time.deltaTime);
				}
				if (AxisVertical < 0){
					transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(limitUpLeft,0,transform.localEulerAngles.z), (TiltSpeed * -(AxisVertical)) * Time.deltaTime);
				}
				if (AxisHorizontal < 0){
					transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.Euler(transform.localEulerAngles.x,0, limitDownRight), (TiltSpeed * -(AxisHorizontal)) * Time.deltaTime);
				}
				if (AxisHorizontal > 0){	
					transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(transform.localEulerAngles.x,0,limitUpLeft), (TiltSpeed * (AxisHorizontal)) * Time.deltaTime);
				}
			}
		}
	}
}
