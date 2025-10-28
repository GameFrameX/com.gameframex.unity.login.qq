# GameFrameX.Login.QQ QQ 登录组件

> GameFrameX.Login.QQ 是 GameFrameX 框架的 QQ 登录组件，基于 ShareSDK 封装，提供初始化、登录、登出能力。

## 功能

- 初始化 QQ 登录配置（`AppId`、`AppKey`）
- 发起 QQ 授权登录并返回用户信息
- 取消授权 / 退出登录

## 环境与依赖

- Unity `2019.4+`
- 依赖 `com.gameframex.unity (>= 1.1.1)`
- 依赖 `GameFrameX.Event.Runtime`、`GameFrameX.ShareSdk.Runtime`
- 需要导入第三方 `cn.sharesdk.unity3d` 插件，并在场景中存在 `ShareSDK` 组件

## 安装

- Unity Package Manager（从 Git）：在 `Window > Package Manager > + > Add package from git URL...` 输入：
  `https://github.com/gameframex/com.gameframex.unity.login.qq.git`
- 或者从磁盘添加：`Window > Package Manager > + > Add package from disk...`，选择本包的 `package.json`

## 快速开始

1. 在 `GameEntry` 对象上挂载 `QQLoginComponent` 组件。
2. 在 Inspector 面板填入从 `https://connect.qq.com` 获取的 `AppId` 与 `AppKey`。
3. 在场景中放置 `ShareSDK` 组件（来自 ShareSDK 插件）。
4. 在代码中调用：

```csharp
using GameFrameX.Login.QQ.Runtime;
using UnityEngine;

public class QQLoginDemo : MonoBehaviour
{
    void Start()
    {
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
                // code 来源于 ShareSDK 的 ResponseState，参见下方说明
            });

        // 如需登出
        // qqLogin.LogOut();
    }
}
```

## API 说明

- `QQLoginComponent.Init()`：初始化，内部会调用 `IQQLoginManager.Init(appId, appKey)`。
- `QQLoginComponent.Login(Action<QQLoginSuccess> onSuccess, Action<int> onFail)`：发起 QQ 授权登录。
- `QQLoginComponent.LogOut()`：取消授权 / 退出登录。

## 数据模型（QQLoginSuccess）

- `NickName`：昵称
- `OpenId`：开放平台 OpenID
- `UnionId`：UnionID（如已开通）
- `PhotoUrl`：头像地址

## 平台配置

- QQ 开放平台：注册应用并获取 `AppId`、`AppKey`（https://connect.qq.com）。
- Android：ShareSDK 插件会自动合并所需的 `AndroidManifest` 与依赖。如需自定义或排查，请参考 ShareSDK 官方文档。
- iOS：按照 ShareSDK 文档配置 URL Scheme（通常为 `tencent{AppId}`），并在 Xcode 启用相关权限。

## 常见问题

- 场景缺少 `ShareSDK` 组件：`Init()` 时可能导致空引用，请先添加。
- `AppId/AppKey` 未设置或配置错误：登录将失败，请确认来自 `connect.qq.com` 的信息正确无误。
- 登录失败 `code`：对应 ShareSDK 的 `ResponseState`（如失败、取消）。建议打印日志并参考 ShareSDK 文档进行定位。

## 版本与许可

- 版本：`1.0.0`；Unity：`2019.4+`
- 许可证：MIT + Apache-2.0（详见仓库 `LICENSE.md`）

## 相关链接

- GameFrameX 文档：https://gameframex.doc.alianblank.com
- QQ 开放平台：https://connect.qq.com
- 本包仓库：https://github.com/gameframex/com.gameframex.unity.login.qq.git
