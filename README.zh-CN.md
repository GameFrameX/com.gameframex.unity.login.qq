<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X QQ 登录

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.qq?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.qq/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.qq?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.qq/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使**

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**语言**: [English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 项目简介

Game Frame X QQ 登录是 GameFrameX 框架的 QQ 登录组件，基于 ShareSDK 封装，提供初始化、登录、登出能力。

## 快速开始

### 安装

任选以下方式之一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容：
   ```json
   {"com.gameframex.unity.login.qq": "https://github.com/AlianBlank/com.gameframex.unity.login.qq.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加库，地址为：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.qq.git
   ```

3. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

## 使用示例

1. 在 `GameEntry` 对象上挂载 `QQLoginComponent` 组件。
2. 在 Inspector 面板填入从 https://connect.qq.com 获取的 `AppId` 与 `AppKey`。
3. 在场景中放置 `ShareSDK` 组件（来自 ShareSDK 插件）。
4. 在代码中调用：

```csharp
// 获取 QQ 登录组件
var qqLogin = GameEntry.GetComponent<QQLoginComponent>();

// 初始化（读取 Inspector 中的 AppId/AppKey）
qqLogin.Init();

// 登录
qqLogin.Login(
    (result) =>
    {
        Debug.Log($"QQ 登录成功: {result}");
        Debug.Log($"JSON: {JsonUtility.ToJson(result)}");
    },
    (code) =>
    {
        Debug.LogError($"QQ 登录失败, code={code}");
    });

// 登出
qqLogin.LogOut();
```

## 依赖项

- `com.gameframex.unity`: GameFrameX 核心框架
- `com.gameframex.unity.sharesdk`: ShareSDK 集成

## 文档与资源

- 文档地址: https://gameframex.doc.alianblank.com
- 仓库地址: https://github.com/GameFrameX/com.gameframex.unity.login.qq
- 问题反馈: https://github.com/GameFrameX/com.gameframex.unity.login.qq/issues

## 开源协议

本项目遵循 MIT 许可证。详细信息请查看 [LICENSE](LICENSE.md) 文件。
