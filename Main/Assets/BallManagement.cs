using UnityEngine;
using System.Collections;

public class BallManagement : MonoBehaviour {
	public float Bv = 0;
	public float v = 0;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}

//	void OnCollisionStay(UnityEngine.Collision hit){
//		v = hit.relativeVelocity.magnitude;
//			if (hit.relativeVelocity.magnitude > 2){
//			this.transform.rigidbody.velocity = Vector3.Reflect(((hit.relativeVelocity*-1)*10/11), hit.contacts[0].normal);
			//Vector3 Bv = GameObject.Find("Ball").rigidbody.velocity;
				
				//Bv.x = (Bv.x*-1);
				//Bv.y = (Bv.y*-1);
				//Bv.z = (Bv.z*-1);
				//rigidbody.velocity = Bv;
//			}
//		}
	// Update is called once per frame
	void Update () {
		Bv = (Mathf.Abs(transform.InverseTransformDirection(rigidbody.velocity).x)+Mathf.Abs(transform.InverseTransformDirection(rigidbody.velocity).z))/2;
	}
}
