<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X QQ Login

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.qq?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.qq/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.qq?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.qq/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams**

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · [QQ Group](https://qm.qq.com/q/5s5e1e6e6e)

**Language**: **English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## Project Overview

Game Frame X QQ Login is a QQ login component for the GameFrameX framework, built on ShareSDK, providing initialization, login, and logout capabilities.

## Quick Start

### Installation

Choose one of the following methods:

1. Add the following to the `dependencies` section in your project's `manifest.json`:
   ```json
   {"com.gameframex.unity.login.qq": "https://github.com/AlianBlank/com.gameframex.unity.login.qq.git"}
   ```

2. Use `Git URL` in Unity's Package Manager:
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.qq.git
   ```

3. Download the repository and place it in your Unity project's `Packages` directory. It will be loaded automatically.

## Usage Examples

1. Attach the `QQLoginComponent` component to the `GameEntry` game object.
2. Set the `AppId` and `AppKey` obtained from https://connect.qq.com in the Inspector.
3. Place a `ShareSDK` component (from the ShareSDK plugin) in the scene.
4. Call the methods:

```csharp
// Get QQ login component
var qqLogin = GameEntry.GetComponent<QQLoginComponent>();

// Initialize (reads AppId/AppKey from Inspector)
qqLogin.Init();

// Login
qqLogin.Login(
    (result) =>
    {
        Debug.Log($"QQ login successful: {result}");
        Debug.Log($"JSON: {JsonUtility.ToJson(result)}");
    },
    (code) =>
    {
        Debug.LogError($"QQ login failed, code={code}");
    });

// Logout
qqLogin.LogOut();
```

## Dependencies

- `com.gameframex.unity`: GameFrameX core framework
- `com.gameframex.unity.sharesdk`: ShareSDK integration

## Documentation & Resources

- Documentation: https://gameframex.doc.alianblank.com
- Repository: https://github.com/GameFrameX/com.gameframex.unity.login.qq
- Issues: https://github.com/GameFrameX/com.gameframex.unity.login.qq/issues

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE.md) for details.
