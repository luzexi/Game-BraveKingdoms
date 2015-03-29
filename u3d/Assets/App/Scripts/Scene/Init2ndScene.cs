


using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Resource;



//init 1st scene
public class Init2ndScene : CScene
{
    public ResAPI m_cNowApi = null;
    private string m_strZipPath = "";
    public ZipProxy m_cZip = null;
    public bool m_bInitOk = false;

    // on enter
    public override void OnEnter()
    {
        bool is_init = PlayerPrefs.GetInt("init" , 0) != 0;
        this.m_cZip = null;
        if(!is_init)
        {
            this.m_strZipPath = "";
            this.m_bInitOk = false;
#if UNITY_EDITOR
            CScene.Switch<MainScene>();
            return;
#elif UNITY_IPHONE
            this.m_strZipPath = "file://" + Application.streamingAssetsPath + "/dl.zip";
#elif UNITY_ANDROID
            this.m_strZipPath = Application.streamingAssetsPath + + "/dl.zip";
#endif
            Debug.Log("zip path " + this.m_strZipPath);
            this.m_cNowApi = ResAPI.Create();
            this.m_cNowApi.Request(this.m_strZipPath,RESOURCE_TYPE.WEB_TEXT_BYTES);
            this.m_cNowApi.m_delFinishCallback = LoadFinish;
            return;
        }
        CScene.Switch<MainScene>();
    }

    private void LoadFinish(Dictionary<string , object> res)
    {
        string zipfile_path = Application.persistentDataPath + "/dl.zip";
        string unzip_path = Application.persistentDataPath + "";
        // string zipfile_path = "/Users/luzexi/dl.zip";
        // string unzip_path = "/Users/luzexi/lua";
        Debug.Log("bytes " + ((byte[])(res[this.m_strZipPath])).Length);
        File.WriteAllBytes(zipfile_path , (byte[])(res[this.m_strZipPath]));
        if( !Directory.Exists(unzip_path) )
        {
            Directory.CreateDirectory(unzip_path);
        }
        this.m_cZip = ZipManager.sInstance.uncompless(zipfile_path , unzip_path , (System.Action<object>)((var)=>{Debug.Log("ok in ini");this.m_bInitOk = true;}) );
    }

    public override void Update()
    {
        if(this.m_cZip != null)
        {
            if(this.m_bInitOk)
            {
                this.m_cZip = null;
                CScene.Switch<MainScene>();
            }
        }
        return;
    }

    // on exit
    public override void OnExit()
    {
        //
    }
}

