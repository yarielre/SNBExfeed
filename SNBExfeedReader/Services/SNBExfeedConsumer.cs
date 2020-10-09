using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SNBExfeedReader.Services
{
    public class SNBExfeedConsumer
    {
        public readonly string SNBRssUrl = "https://www.snb.ch/selector/en/mmr/exfeed/rss";
        public async Task<rss> ConsumeAsync()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(SNBRssUrl);
            rss snbRssObject;
            using (var rssStream = await result.Content.ReadAsStreamAsync())
            {
               snbRssObject =  SNBExfeedSerializer.Deserialize(rssStream);
            }
            return snbRssObject;
        }
    }
}
