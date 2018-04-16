using System.Collections;
using System.Collections.Generic;
using TwitterKit.Unity;
using UnityEngine.UI;
using UnityEngine;

public class getSessionButtonEvent : MonoBehaviour {

	[SerializeField] private Text TokenText;
	[SerializeField] private Text SecretText; 

	// Use this for initialization
	void Start () {
		Twitter.Init();
	}

	//セッション情報を入手するメソッドを認証クラスに書きたくないのでここで処理
	public void OnClick(){
		if(Twitter.Session != null){
			this.TokenText.text = "Token : " + Twitter.Session.authToken.token;
			this.SecretText.text = "Secret : " + Twitter.Session.authToken.secret;
		}else{
			this.TokenText.text = "Token : ";
			this.SecretText.text = "Secret : ";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
