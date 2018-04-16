using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Ichikara.Util;

public class LogoutButtonEvent : MonoBehaviour, TwitterDelegate {

	// Use this for initialization
	void Start () {
		
	}

	public void OnClick(){
		TwitterOAuth twitterOAuth = new TwitterOAuth(this);
		twitterOAuth.LogOut();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void Complete(string uniqueId){
	}
	public void Failure(string errorMessage){
	}
}
