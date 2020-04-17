using NeteaseCloudMusicApi;
using Newtonsoft.Json.Linq;
using SeeUMusic.Models.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SeeUMusic.Bll.BllImplement.LoginMgt
{
    public class LoginMgtSvr
    {
        private CloudMusicApi api = new CloudMusicApi();
        private int uid;
        private string nickName;
        public string errorMsg;

        public LoginMgtSvr()
        { }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="reqParamInfo"></param>
        /// <returns></returns>
        public Tuple<LoginInfo,string> Invoke<TResult>(LoginInfo LoginInfo)
        {
            LoginInfo loginInfo = new LoginInfo();
            bool isOk;
            string msg;
            JObject json;

            try
            {
                do
                {
                    Dictionary<string, string> queries;
                    string account = LoginInfo.UserAccount;
                    bool isPhone;

                    queries = new Dictionary<string, string>();
                    isPhone = Regex.Match(account, "^[0-9]+$").Success;
                    queries[isPhone ? "phone" : "email"] = account;
                    queries["password"] = LoginInfo.UserPassword;
                    var rlt = api.RequestAsync(isPhone ? CloudMusicApiProviders.LoginCellphone : CloudMusicApiProviders.Login, queries);
                    isOk = rlt.Result.Item1;
                    json = rlt.Result.Item2;
                    if (!isOk)
                        msg = "登录失败，账号或密码错误";
                } while (!isOk);
                msg = "登录成功";

                /******************** 获取账号信息 ********************/

                var rlt1 = api.RequestAsync(CloudMusicApiProviders.LoginStatus, CloudMusicApi.EmptyQueries);
                isOk = rlt1.Result.Item1;
                json = rlt1.Result.Item2;
                if (!isOk)
                    msg = "获取账号信息失败：" + json;
                uid = (int)json["profile"]["userId"];
                nickName = json["profile"]["nickname"].ToString();
                loginInfo.UserId = uid;
                loginInfo.Nickname = nickName;
                /******************** 获取账号信息 ********************/

                return Tuple.Create<LoginInfo, string>(LoginInfo, msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public async Task<string> LogoutInvoke<TResult>()
        {
            bool isOk;
            string msg;
            JObject json;

            try
            {
                if (uid != 0)
                {
                    (isOk, json) = await api.RequestAsync(CloudMusicApiProviders.Logout, CloudMusicApi.EmptyQueries);

                    if (!isOk)
                    {
                        msg = "退出登录失败：" + json;
                    }
                    else
                    {
                        msg = "退出登录成功";
                    }
                }
                else
                {
                    msg = "请先进行登录操作！";
                }
            }
            catch (Exception ex)
            {
                return msg = "退出登录失败：" + ex;
            }

            return msg;
        }
    }
}
