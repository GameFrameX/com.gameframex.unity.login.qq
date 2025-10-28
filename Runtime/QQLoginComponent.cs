// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.Login.QQ.Runtime
{
    /// <summary>
    /// QQ登录组件。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/QQLogin")]
    [UnityEngine.Scripting.Preserve]
    [RequireComponent(typeof(GameFrameXQQLoginCroppingHelper))]
    public class QQLoginComponent : GameFrameworkComponent
    {
        private const int DefaultPriority = 0;

        private IQQLoginManager _QQLoginManager = null;

        /// <summary>
        ///  QQ 登录 App Id
        /// </summary>
        [SerializeField] private string m_AppId = string.Empty;

        [SerializeField] private string m_AppKey = string.Empty;

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected override void Awake()
        {
            ImplementationComponentType = Utility.Assembly.GetType(componentType);
            InterfaceComponentType = typeof(IQQLoginManager);
            base.Awake();

            _QQLoginManager = GameFrameworkEntry.GetModule<IQQLoginManager>();
            if (_QQLoginManager == null)
            {
                Log.Fatal("Red system manager is invalid.");
                return;
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void Init()
        {
            _QQLoginManager.Init(m_AppId, m_AppKey);
        }

        [UnityEngine.Scripting.Preserve]
        public void Login(Action<QQLoginSuccess> loginSuccess, Action<int> loginFail)
        {
            _QQLoginManager.Login(loginSuccess, loginFail);
        }

        [UnityEngine.Scripting.Preserve]
        public void LogOut()
        {
            _QQLoginManager.LogOut();
        }
    }
}