using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace TranslationTool
{
    public class YandexTranslate
    {
        private readonly string _apiKey;
        public YandexTranslate(string key)
        {
            _apiKey = key;
        }

        public List<string> GetLangs()
        {
            var requestString =
                String.Format("https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}",
                _apiKey);
            var request = WebRequest.Create(requestString);
            var response = request.GetResponse();
            var yandexDataContractSerializer = new DataContractJsonSerializer(typeof(GetLangsData));
            var getLangsData = (GetLangsData)yandexDataContractSerializer.ReadObject(response.GetResponseStream());
            return getLangsData.Dirs;
        }
        public List<string> GetLangs(string ui)
        {
            var requestString =
                String.Format("https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}&ui={1}",
                _apiKey, ui);
            var request = WebRequest.Create(requestString);
            var response = request.GetResponse();
            var sr = new StreamReader(response.GetResponseStream());
            var json = sr.ReadToEnd();
            json = json.Remove(json.Length - 3);
            json = json.Substring(json.IndexOf("langs") + 8);
            json = json.Replace('"', ' ');
            return json.Split(',').ToList();
        }
        public string Detect(string text)
        {
            var requestString =
                String.Format("https://translate.yandex.net/api/v1.5/tr.json/detect?key={0}&text={1}",
                _apiKey, text);
            var request = WebRequest.Create(requestString);
            var response = request.GetResponse();
            var yandexDataContractSerializer = new DataContractJsonSerializer(typeof(DetectData));
            var detectData = (DetectData)yandexDataContractSerializer.ReadObject(response.GetResponseStream());
            return detectData.Lang;
        }
        public List<string> Translate(string lang, string text)
        {
            var requestString =
                String.Format("https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang={2}&format={3}",
                _apiKey, text, lang, "plain");

            var request = WebRequest.Create(requestString);
            if ((requestString.Length > 10240) && (request.Method.StartsWith("GET")))
                throw new ArgumentException("Text is too long (>10Kb)");
            var response = request.GetResponse();

            TranslateData translateData;
            var yandexDataContractSerializer = new DataContractJsonSerializer(typeof(TranslateData));
            try
            {
                translateData = (TranslateData)yandexDataContractSerializer.ReadObject(response.GetResponseStream());
            }
            catch (Exception)
            {
                translateData = new TranslateData();
                translateData.Text = new List<string>();
            }
            return translateData.Text;
        }
        [DataContract]
        internal class TranslateData
        {
            [DataMember(Name = "code")]
            internal int Code { get; set; }
            [DataMember(Name = "lang")]
            internal string Lang { get; set; }
            [DataMember(Name = "text")]
            internal List<string> Text { get; set; }
        }
        [DataContract]
        public class GetLangsData
        {
            [DataMember(Name = "dirs")]
            internal List<string> Dirs { get; set; }
        }
        [DataContract]
        internal class DetectData
        {
            [DataMember(Name = "code")]
            internal int Code { get; set; }
            [DataMember(Name = "lang")]
            internal string Lang { get; set; }
        }
    }
    
}
