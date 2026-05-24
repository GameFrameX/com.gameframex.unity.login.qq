<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X QQ ログイン

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.qq?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.qq/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.qq?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.qq/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援**

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · [QQグループ](https://qm.qq.com/q/5s5e1e6e6e)

**言語**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

## プロジェクト概要

Game Frame X QQ ログインは、GameFrameX フレームワークの QQ ログインコンポーネントで、ShareSDK をベースに構築され、初期化、ログイン、ログアウト機能を提供します。

## クイックスタート

### インストール

以下のいずれかの方法をお選びください：

1. プロジェクトの `manifest.json` の `dependencies` セクションに以下を追加：
   ```json
   {"com.gameframex.unity.login.qq": "https://github.com/AlianBlank/com.gameframex.unity.login.qq.git"}
   ```

2. Unity の Package Manager で `Git URL` を使用：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.qq.git
   ```

3. リポジトリをダウンロードして Unity プロジェクトの `Packages` ディレクトリに配置。自動的にロードされます。

## 使用例

1. `GameEntry` オブジェクトに `QQLoginComponent` コンポーネントをアタッチ。
2. Inspector で https://connect.qq.com から取得した `AppId` と `AppKey` を設定。
3. シーンに `ShareSDK` コンポーネント（ShareSDK プラグインから）を配置。
4. コードで呼び出し：

```csharp
// QQ ログインコンポーネントの取得
var qqLogin = GameEntry.GetComponent<QQLoginComponent>();

// 初期化（Inspector の AppId/AppKey を読み取り）
qqLogin.Init();

// ログイン
qqLogin.Login(
    (result) =>
    {
        Debug.Log($"QQ ログイン成功: {result}");
        Debug.Log($"JSON: {JsonUtility.ToJson(result)}");
    },
    (code) =>
    {
        Debug.LogError($"QQ ログイン失敗, code={code}");
    });

// ログアウト
qqLogin.LogOut();
```

## 依存関係

- `com.gameframex.unity`: GameFrameX コアフレームワーク
- `com.gameframex.unity.sharesdk`: ShareSDK 統合

## ドキュメントとリソース

- ドキュメント: https://gameframex.doc.alianblank.com
- リポジトリ: https://github.com/GameFrameX/com.gameframex.unity.login.qq
- Issues: https://github.com/GameFrameX/com.gameframex.unity.login.qq/issues

## ライセンス

このプロジェクトは MIT ライセンスの下で公開されています。詳細は [LICENSE](LICENSE.md) ファイルを参照してください。
