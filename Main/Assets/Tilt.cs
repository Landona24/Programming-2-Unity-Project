using UnityEngine;
using System.Collections;
public class Tilt : MonoBehaviour {
	public float TiltSpeed = 64;
	public float limitUpLeft = 30;
	public float limitDownRight = 330;
	public float AxisVertical = 0;
	public float AxisHorizontal = 0;
	public bool origin = false;
	public float iOx = 0;
	public float iOy = 0;

	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.Android){
			Input.gyro.enabled = true;
			iOx = Input.gyro.rotationRate.x;
			iOy = Input.gyro.rotationRate.y;
		}
		print (Application.platform);
	}

	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.identity, 4 * Time.deltaTime);

		//if (GameObject.Find("Ball").transform.position.y < -5){//Ball reset below -5
		//	transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.identity, TiltSpeed * Time.deltaTime);
		//	if(transform.localEulerAngles.x == 0 && transform.localEulerAngles.z == 0){
		//		Application.LoadLevel(Application.loadedLevelName);
		//	}
		//}
		//else{
			if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) {//Axis
				//if (Application.platform == RuntimePlatform.Android){
					//AxisHorizontal = iOx - Input.gyro.rotationRate.x;
					//AxisVertical = iOy - Input.gyro.rotationRate.y;
				//}
				//if (Application.platform == RuntimePlatform.WindowsPlayer){
					AxisVertical = Input.GetAxis ("Vertical");
					AxisHorizontal = Input.GetAxis ("Horizontal");
				//}
			}
			else{
				AxisVertical = 0;
				AxisHorizontal = 0;
			}
//			if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0){
//				AxisVertical = Input.GetAxis ("Mouse Y");
//				AxisHorizontal = Input.GetAxis ("Mouse X");
//			}

			if ((Input.GetKey ("home")) || origin) {//Rotation Origin
				if(transform.localEulerAngles.x != 0 && transform.localEulerAngles.z != 0){
					origin = true;
					transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.identity, TiltSpeed * Time.deltaTime);
				}
				else{origin = false;}
			}
			else{
				if (AxisVertical > 0){//Down
					transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.Euler(limitDownRight,0,transform.localEulerAngles.z), (TiltSpeed * (AxisVertical)) * Time.deltaTime);
				}
				if (AxisVertical < 0){//Up
					transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(limitUpLeft,0,transform.localEulerAngles.z), (TiltSpeed * -(AxisVertical)) * Time.deltaTime);
				}
				if (AxisHorizontal < 0){//Right
					transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.Euler(transform.localEulerAngles.x,0, limitDownRight), (TiltSpeed * -(AxisHorizontal)) * Time.deltaTime);
				}
				if (AxisHorizontal > 0){//Left
					transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(transform.localEulerAngles.x,0,limitUpLeft), (TiltSpeed * (AxisHorizontal)) * Time.deltaTime);
				}
			}
		}
	}
//}
