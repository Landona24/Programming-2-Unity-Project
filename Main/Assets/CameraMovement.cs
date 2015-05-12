using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float Bx = 0;
	public float By = 0;
	public float Bz = 0;
	//public float Cv = 0;
	public float scale = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Ball") != null) {
			Bx = GameObject.Find ("Ball").transform.position.x;
			By = GameObject.Find ("Ball").transform.position.y;
			Bz = GameObject.Find ("Ball").transform.position.z;
			//Cv = new Vector3(GameObject.Find("Main Camera").transform.localPosition.x*(By/6), 0, GameObject.Find("Main Camera").transform.localPosition.z*(By/6)).magnitude;
			Vector3 Cp = transform.localPosition;
			Cp.x = Bx;
			Cp.y = Mathf.Lerp (((GameObject.Find ("Ball").GetComponent <BallManagement> ().Bv) * 2 + 4), scale, Time.time);//Cv*2+4;
			Cp.z = Bz;
			transform.localPosition = Cp;
		}
	}
}
