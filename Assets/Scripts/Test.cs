using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using  Baidu.Aip;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class Test : MonoBehaviour
{
    public string APP_ID = "你的 App ID";
    public string API_KEY = "你的 Api Key";
    public string SECRET_KEY = "你的 Secret Key";

    public Texture2D _Texture2D;
    // Start is called before the first frame update
    void Start1()
    {
        var client = new Baidu.Aip.ImageClassify.ImageClassify(API_KEY, SECRET_KEY);
        client.Timeout = 60000;  // 修改超时时间
        //client.
        byte[] bytes= _Texture2D.EncodeToPNG();
        string str= System.Convert.ToBase64String(bytes);
        bytes= Encoding.UTF8.GetBytes(str);
        JObject _jObject=  client.ObjectDetect(bytes);
        StringBuilder sb=new StringBuilder();
        foreach (var VARIABLE in _jObject)
        { 
            sb.Append(VARIABLE.Key+": "+VARIABLE.Value);
        }
        Debug.Log(sb);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AdvancedGeneralDemo();
        }
    }
    public void AdvancedGeneralDemo()
    {
        var client = new Baidu.Aip.ImageClassify.ImageClassify(API_KEY, SECRET_KEY);
        var image = File.ReadAllBytes(@"F:/UnityProject/BaiduAI_imgSense/Imgs/mt.jpg");
        Debug.Log(image.Length);
        // 调用通用物体和场景识别，可能会抛出网络等异常，请使用try/catch捕获
        var result = client.AdvancedGeneral(image);
        Debug.Log(result);
        //return;
        // 如果有可选参数
        var options = new Dictionary<string, object>{
            {"baike_num", 5}
        };
        // 带参数调用通用物体和场景识别
        result = client.AdvancedGeneral(image, options);
        Debug.Log(result);
    }
}
