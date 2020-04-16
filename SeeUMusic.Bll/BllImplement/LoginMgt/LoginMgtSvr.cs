using NeteaseCloudMusicApi;
using Newtonsoft.Json.Linq;
using SeeUMusic.Models.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SeeUMusic.Bll.BllImplement.LoginMgt
{
    public class LoginMgtSvr
    {
        public LoginMgtSvr()
        { }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="reqParamInfo"></param>
        /// <returns></returns>
        public Tuple<LoginInfo,string> Invoke<TResult>(LoginInfo LoginInfo)
        {
            bool isOk;
            JObject json;
            int uid;
            string nickName;
            string msg;
            LoginInfo loginInfo = new LoginInfo();

            using (CloudMusicApi api = new CloudMusicApi())
            {
                try
                {
                    /******************** 登录 ********************/

                    do
                    {
                        Dictionary<string, string> queries;
                        string account = LoginInfo.UserAccount;
                        bool isPhone;

                        queries = new Dictionary<string, string>();
                        isPhone = Regex.Match(account, "^[0-9]+$").Success;
                        queries[isPhone ? "phone" : "email"] = account;
                        queries["password"] = LoginInfo.UserPassword;
                        var rlt= api.RequestAsync(isPhone ? CloudMusicApiProviders.LoginCellphone : CloudMusicApiProviders.Login, queries);
                        isOk = rlt.Result.Item1;
                        json = rlt.Result.Item2;
                        if (!isOk)
                            msg = "登录失败，账号或密码错误";
                    } while (!isOk);
                    msg = "登录成功";

                    /******************** 登录 ********************/

                    /******************** 获取账号信息 ********************/

                    var rlt1 = api.RequestAsync(CloudMusicApiProviders.LoginStatus, CloudMusicApi.EmptyQueries);
                    isOk = rlt1.Result.Item1;
                    json = rlt1.Result.Item2;
                    if (!isOk)
                        msg = "获取账号信息失败："+json;
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
        }
    }
}
