using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Ichikara.Util;

public class ButtonEvent : MonoBehaviour, TwitterDelegate {

	[SerializeField] private Text userIdText;

	// Use this for initialization
	void Start () {

	}

	public void OnClick() {
		Debug.Log("Clicked");

		TwitterOAuth twitterOAuth = new TwitterOAuth(this);
		twitterOAuth.Authorize();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Complete(string uniqueId){
		Debug.Log(uniqueId);
		this.userIdText.text = "UserID : "+uniqueId;
	}

	public void Failure(string errorMessage){
		Debug.Log(errorMessage);
	}
}

