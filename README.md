# unity-test-project
Unityのテストをするためのリポジトリ

# フォルダ構成
* unity-test/
    - Assets/
        - Plugins/
        - Scripts/
            - TwitterOAuth.cs (Twitterへのログイン・ログアウトの処理)
        - Twitter/
        - Plugins.meta
        - Scripts.meta
        - Twitter.meta
        - TwitterTest.unity
        - TwitterTest.unity.meta
    - ProjectSettings

* README.md

# 使い方
### 初期設定
1. TwitterKit for UnityをAssetStoreなどからインストール
2. メニューバーから [Tools] > [Twitter Kit] を選択
3. inspectorにTwitterKitSettingsが表示されるので、API KeyとAPI Secretを入力
4. Assets/Twitter/Scripts/TwitterInit.csをGameObjectにアタッチ。
### Twitterを用いて一意なIDを入手する
1. unity-test/Assets/Scripts/TwitterOAuth.csをコピー
2. TwitterDelegateを継承
3. ログイン成功時の処理をCompleteのデリゲートメソッドに書く
4. 失敗時の処理はFailureメソッドを書く
5. TwitterOAuthクラスのインスタンスを生成する
6. Authorize()で認証を行いid取得、Logout()でセッション破棄

### 注意事項
* Delegateメソッド`public void Complete(string uniqueId){}`はセッション情報はなくidのみ取得します。
* Delegateメソッド`public void Failure(string errorMessage){}`の`
errorMessage`は`using TwitterKit.Unity`しなくても使えるようにApiError型(エラーコードとメッセージがそれぞれ格納)を展開してStringにしてしまっています。
