using UnityEngine;
using System.Collections;
public class Transition : MonoBehaviour {
	public int Current = 0;
	public int ChildAmount = 0;
	public bool reset = false;
	public Transform Active;
	public float z = 0;
	public Transform Ball = null;
	public float Ballx = 0;
	public float Bally = 0;
	public float Ballz = 0;

	// Use this for initialization
	void Start () {
		Active = this.transform.GetChild(Current-1);

		Ball = GameObject.Find("Ball").transform;
		Ballx = this.transform.localPosition.x;
		Bally = this.transform.localPosition.y;
		Ballz = this.transform.localPosition.z;
	}

	void OnCollisionStay(UnityEngine.Collision hit){
		if (hit.collider.name == "") {
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.LoadLevel (Application.loadedLevelName);
		}

		Active = this.transform.GetChild(Current-1);
		ChildAmount = this.transform.childCount;

		if (reset == true){
			Input.ResetInputAxes ();

			if (Active.transform.rotation.x == 0 && Active.transform.rotation.z == 0){
				Ball.localPosition = new Vector3(Ballx,Bally,Ballz);

				if (Active.transform.localPosition.y >= GameObject.Find("Main Camera").transform.localPosition.y){
					if (Current == ChildAmount){
						Application.LoadLevel(Application.loadedLevelName);
						Current--;
					}

					this.transform.GetChild(Current).gameObject.SetActive(true);
					if (Current > 0){
						this.transform.GetChild(Current-1).gameObject.SetActive(false);
					}

						if (this.transform.GetChild(Current).transform.localPosition.y >= 0){
							this.transform.GetChild(Current-1).transform.position = Vector3.zero;
							reset = false;
							Current++;
						Ball = GameObject.Find ("Ball").transform;
						Ballx = this.transform.localPosition.x;
						Bally = this.transform.localPosition.y;
						Ballz = this.transform.localPosition.z;

						}
					else{

						this.transform.GetChild(Current).transform.localPosition = Vector3.MoveTowards(this.transform.GetChild(Current).transform.localPosition, Vector3.zero, 16*Time.deltaTime);
					}
				}
				else{
					Active.transform.localPosition = Vector3.MoveTowards(Active.localPosition, new Vector3(0,GameObject.Find ("Main Camera").transform.localPosition.y+1,0), 16*Time.deltaTime);
				}
			}
			else{
				Active.transform.localRotation = Quaternion.RotateTowards (Active.transform.localRotation, Quaternion.identity, 64*Time.deltaTime);
			}
		}


		if ((Input.GetKeyUp(KeyCode.PageUp)||(Ball.localPosition.y < -6) && (Current < ChildAmount+1))){
			reset = true;

			if (Current != ChildAmount){
				this.transform.GetChild(Current).transform.position = new Vector3(0, -(GameObject.Find("Main Camera").transform.localPosition.y), 0);
			}

			//Input.ResetInputAxes ();
			//while (this.transform.localEulerAngles.x != 0 && this.transform.localEulerAngles.z != 0){

			//}
			//this.transform.GetChild(Current).gameObject.SetActive(true);
			//if (Current > 0){
			//	this.transform.GetChild(Current-1).gameObject.SetActive(false);
			//}
			//Current++;
		}
		if (Input.GetKeyUp(KeyCode.PageDown) && Current > 1){
			this.transform.GetChild(Current-2).gameObject.SetActive(true);
			this.transform.GetChild(Current-1).gameObject.SetActive(false);
			Current--;
		}
	}
}
