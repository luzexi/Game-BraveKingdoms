


using UnityEngine;



//init 1st scene
public class Init1stScene : CScene
{

    // on enter
    public override void OnEnter()
    {
        CScene.Switch<Init2ndScene>();
    }

    // on exit
    public override void OnExit()
    {
        //
    }
}

