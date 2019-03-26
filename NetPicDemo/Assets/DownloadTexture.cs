using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadTexture : MonoBehaviour
{

    public Image image;
    public RawImage rawImage;


    async  void Start()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553619317321&di=f80e6005e936268893a407f3e61ba6fa&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201502%2F02%2F20150202223641_SirzA.thumb.700_0.jpeg");
        await www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            //image.sprite = myTexture;
            //image.image = myTexture;
            rawImage.texture = myTexture;

        }
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553619317321&di=f80e6005e936268893a407f3e61ba6fa&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201502%2F02%2F20150202223641_SirzA.thumb.700_0.jpeg");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            //image.sprite = myTexture;
            //image.image = myTexture;
            rawImage.texture = myTexture;

        }
    }
}

public static class XAwaitExtensions
{
    public static TaskAwaiter GetAwaiter(this TimeSpan timespan)
    {
        return Task.Delay(timespan).GetAwaiter();
    }
}
