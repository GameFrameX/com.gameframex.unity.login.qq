// ==========================================================================================
//  GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//  GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//  均受中华人民共和国及相关国际法律法规保护。
//  are protected by the laws of the People's Republic of China and relevant international regulations.
// 
//  使用本项目须严格遵守相应法律法规及开源许可证之规定。
//  Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
// 
//  本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//  This project is dual-licensed under the MIT License and Apache License 2.0,
//  完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//  please refer to the LICENSE file in the root directory of the source code for the full license text.
// 
//  禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//  It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//  侵犯他人合法权益等法律法规所禁止的行为！
//  or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//  因基于本项目二次开发所产生的一切法律纠纷与责任，
//  Any legal disputes and liabilities arising from secondary development based on this project
//  本项目组织与贡献者概不承担。
//  shall be borne solely by the developer; the project organization and contributors assume no responsibility.
// 
//  GitHub 仓库：https://github.com/GameFrameX
//  GitHub Repository: https://github.com/GameFrameX
//  Gitee  仓库：https://gitee.com/GameFrameX
//  Gitee Repository:  https://gitee.com/GameFrameX
//  官方文档：https://gameframex.doc.alianblank.com/
//  Official Documentation: https://gameframex.doc.alianblank.com/
// ==========================================================================================

using System;
using cn.sharesdk.unity3d;
using GameFrameX.Event.Runtime;
using GameFrameX.Runtime;
using GameFrameX.ShareSdk.Runtime;
using UnityEngine.Device;

namespace GameFrameX.Login.QQ.Runtime
{
    [UnityEngine.Scripting.Preserve]
    public sealed class QQLoginManager : GameFrameworkModule, IQQLoginManager
    {
        [UnityEngine.Scripting.Preserve]
        public QQLoginManager()
        {
        }

        private EventComponent _eventComponent;
        private ShareSDK _shareSDK;

        private bool isInit = false;

        /// <summary>
        /// 初始化 QQ 登录组件。
        /// </summary>
        /// <param name="appId">QQ 登录 App Id。</param>
        /// <param name="appKey">QQ 登录 App Key。</param>
        [UnityEngine.Scripting.Preserve]
        public void Init(string appId, string appKey)
        {
            if (isInit)
            {
                return;
            }

            _eventComponent = GameEntry.GetComponent<EventComponent>();
            _eventComponent.CheckSubscribe(AuthEventArgs.EventId, OnAuthEventArgs);
            _shareSDK = UnityEngine.Object.FindObjectOfType<ShareSDK>();
            _shareSDK.devInfo.qq.AppId = appId;
            _shareSDK.devInfo.qq.AppKey = appKey;
            isInit = true;
        }

        private void OnAuthEventArgs(object sender, GameEventArgs e)
        {
            if (e is AuthEventArgs eventArgs)
            {
                if (eventArgs.Type != PlatformType.QQ)
                {
                    return;
                }

                if (eventArgs.State == ResponseState.Success)
                {
                    if (_loginSuccess == null)
                    {
                        return;
                    }

                    var qqLoginSuccess = new QQLoginSuccess();
                    if (eventArgs.Data != null)
                    {
                        if (eventArgs.Data.ContainsKey("nickname"))
                        {
                            qqLoginSuccess.NickName = eventArgs.Data["nickname"].ToString();
                        }

                        if (eventArgs.Data.ContainsKey("openid"))
                        {
                            qqLoginSuccess.OpenId = eventArgs.Data["openid"].ToString();
                        }

                        if (eventArgs.Data.ContainsKey("unionid"))
                        {
                            qqLoginSuccess.UnionId = eventArgs.Data["unionid"].ToString();
                        }

                        if (eventArgs.Data.ContainsKey("figureurl"))
                        {
                            qqLoginSuccess.PhotoUrl = eventArgs.Data["figureurl"].ToString();
                        }
                    }

                    _loginSuccess.Invoke(qqLoginSuccess);
                }
                else
                {
                    _loginFail?.Invoke((int)eventArgs.State);
                }
            }
        }

        private Action<QQLoginSuccess> _loginSuccess;
        private Action<int> _loginFail;

        /// <summary>
        /// 登录 QQ 账号。
        /// </summary>
        /// <param name="loginSuccess">登录成功回调。</param>
        /// <param name="loginFail">登录失败回调。</param>
        [UnityEngine.Scripting.Preserve]
        public void Login(Action<QQLoginSuccess> loginSuccess, Action<int> loginFail)
        {
            _loginSuccess = loginSuccess;
            _loginFail = loginFail;
#if UNITY_EDITOR
            _loginSuccess?.Invoke(new QQLoginSuccess() { NickName = "test", OpenId = SystemInfo.deviceUniqueIdentifier, PhotoUrl = "test", UnionId = SystemInfo.deviceUniqueIdentifier });
            return;
#endif
            _shareSDK.Authorize(PlatformType.QQ);
            var authInfo = _shareSDK.GetAuthInfo(PlatformType.QQ);
            Log.Debug(authInfo);
        }

        /// <summary>
        /// 退出登录 QQ 账号。
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public void LogOut()
        {
            _shareSDK.CancelAuthorize(PlatformType.QQ);
        }

        protected override void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        protected override void Shutdown()
        {
        }
    }
}