<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X QQ 登錄

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.qq?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.qq/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.qq?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.qq/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使**

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**語言**: [English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 項目簡介

Game Frame X QQ 登錄是 GameFrameX 框架的 QQ 登錄組件，基於 ShareSDK 封裝，提供初始化、登錄、登出能力。

## 快速開始

### 安裝

任選以下方式之一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 節點下添加以下內容：
   ```json
   {"com.gameframex.unity.login.qq": "https://github.com/AlianBlank/com.gameframex.unity.login.qq.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加庫，地址為：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.qq.git
   ```

3. 直接下載倉庫放置到 Unity 項目的 `Packages` 目錄下，會自動加載識別。

## 使用範例

1. 在 `GameEntry` 對象上掛載 `QQLoginComponent` 組件。
2. 在 Inspector 面板填入從 https://connect.qq.com 獲取的 `AppId` 與 `AppKey`。
3. 在場景中放置 `ShareSDK` 組件（來自 ShareSDK 插件）。
4. 在代碼中調用：

```csharp
// 獲取 QQ 登錄組件
var qqLogin = GameEntry.GetComponent<QQLoginComponent>();

// 初始化（讀取 Inspector 中的 AppId/AppKey）
qqLogin.Init();

// 登錄
qqLogin.Login(
    (result) =>
    {
        Debug.Log($"QQ 登錄成功: {result}");
        Debug.Log($"JSON: {JsonUtility.ToJson(result)}");
    },
    (code) =>
    {
        Debug.LogError($"QQ 登錄失敗, code={code}");
    });

// 登出
qqLogin.LogOut();
```

## 依賴項

- `com.gameframex.unity`: GameFrameX 核心框架
- `com.gameframex.unity.sharesdk`: ShareSDK 集成

## 文檔與資源

- 文檔地址: https://gameframex.doc.alianblank.com
- 倉庫地址: https://github.com/GameFrameX/com.gameframex.unity.login.qq
- 問題反饋: https://github.com/GameFrameX/com.gameframex.unity.login.qq/issues

## 開源協議

本項目遵循 MIT 許可證。詳細信息請查看 [LICENSE](LICENSE.md) 文件。
