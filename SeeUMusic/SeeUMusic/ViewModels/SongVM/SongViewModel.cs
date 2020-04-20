using NeteaseCloudMusicApi;
using Newtonsoft.Json.Linq;
using SeeUMusic.Models.SongModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeeUMusic.ViewModels.SongVM
{
    public class SongViewModel:BaseViewModel
    {
        private static CloudMusicApi api = new CloudMusicApi();
        private static Dictionary<string, string> queries;
        private static bool isOk;
        private static string msg;
        private static JObject json;

        public SongViewModel()
        {
            SearchItemCmd = new Command<string>(SearchItemHandler);//注册 
        }

        /// <summary>
        /// 查找音乐
        /// </summary>
        /// <returns></returns>
        private async Task SearchMusic(string keyWords)
        {
            try
            {
                SongLst = new ObservableCollection<Song>();
                queries = new Dictionary<string, string>();
                queries["keywords"] = keyWords;
                (isOk, json) = await api.RequestAsync(CloudMusicApiProviders.Search, queries);
                if (!isOk)
                    throw new ApplicationException($"获取歌曲详情失败： {json}");
                var Lst = json["result"];
                foreach (JObject song in Lst["songs"])
                {
                    var item = song.ToObject<Song>();
                    SongLst.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ObservableCollection<Song> _SongLst;
        /// <summary>
        /// 歌曲列表
        /// </summary>
        public ObservableCollection<Song> SongLst
        {
            get 
            {
                return _SongLst;
            }
            set
            {
                if (_SongLst != value)
                {
                    _SongLst = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 查询条目处理
        /// </summary>
        /// <param name="notWeightWO"></param>
        public override async void SearchItemHandler(object obj)
        {
            var key = obj.ToString();
            await SearchMusic(key);
        }
    }
}
