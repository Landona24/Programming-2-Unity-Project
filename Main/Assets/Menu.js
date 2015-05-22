#pragma strict
var Platform : GameObject;
Platform = GameObject.FindWithTag("Platform");

function Start () {
	Platform.SetActive(false);
}

function Update () {
	
}

function Play () {
	Platform.SetActive(true);
	GameObject.Find("Canvas").SetActive(false);
}

function Exit () {
	Application.Quit();
}
