


using UnityEngine;



//init 1st scene
public class MainScene : CScene
{

    // on enter
    public override void OnEnter()
    {
        MyLua.sInstance.Init();
    }

    // on exit
    public override void OnExit()
    {
        MyLua.sInstance.Destroy();
    }
}

