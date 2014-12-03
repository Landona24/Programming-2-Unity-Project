using UnityEngine;
using System.Collections;
public class Tiltv2 : MonoBehaviour {
	public float TiltSpeed = 32;
	public float limitUpLeft = 30;
	public float limitDownRight = 330;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey ("home"))) {
			while (transform.localEulerAngles.x != 0 && transform.localEulerAngles.z != 0){
				transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.identity, TiltSpeed * Time.deltaTime);
			}
		}
		else{
			if ((Input.GetKey ("up"))){
				transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(limitUpLeft,0,transform.localEulerAngles.z), TiltSpeed * Time.deltaTime);
			}
			if ((Input.GetKey ("down"))){
				transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.Euler(limitDownRight,0,transform.localEulerAngles.z), TiltSpeed * Time.deltaTime);
			}
			if ((Input.GetKey ("left"))){	
				transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(transform.localEulerAngles.x,0,limitUpLeft), TiltSpeed * Time.deltaTime);
			}
			if ((Input.GetKey ("right"))) {
				transform.localRotation = Quaternion.RotateTowards (transform.localRotation, Quaternion.Euler (transform.localEulerAngles.x, 0, limitDownRight), TiltSpeed * Time.deltaTime);
			}
		}
	}
}
