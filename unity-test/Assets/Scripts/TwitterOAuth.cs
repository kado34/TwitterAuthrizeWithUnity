//----  Twitter認証を行うクラス  ----//
//ログイン処理とセッション破棄を行う    //

using System;
using UnityEngine;
using TwitterKit.Unity;

namespace Ichikara.Util {

	public interface TwitterDelegate {
		void Complete(string token);
		void Failure(string errorMessage);
	}

	public class TwitterOAuth {
		private TwitterDelegate d;

		public TwitterOAuth(TwitterDelegate d) {
			this.d = d;
			//API Keyの設定を行っている
			Twitter.Init();
			Debug.Log("[Info] : Instance is created.");
		}

		public void Authorize() {
			Debug.Log("[Info] : Start Login");
			//Twitterのセッションが残っていれば格納
			TwitterSession session = Twitter.Session;
			if (session == null){
				//セッションが空であれば、ログインを依頼
				Twitter.LogIn(logInComplete,logInFailure);
			}else{
				logInComplete(session);
			}

		}

		public void LogOut() {
			Debug.Log("[Info] : Log out session.");
			Twitter.LogOut();
		}

		//ログイン成功時にその旨を残し、delegateに一意なidを渡して処理を委託
		private void logInComplete(TwitterSession session) {
			string uniqueId = session.id.ToString();
		
			Debug.Log("[Info] : Login sucsess. " + uniqueId);
			this.d.Complete(uniqueId);
		}

		//ログイン失敗時にエラー表示
		private void logInFailure(ApiError error) {
			string errorMessage = "[Error] : Login failed code - "+error.code+" message-"+error.message;
			this.d.Failure(errorMessage);
		}
	}
}
