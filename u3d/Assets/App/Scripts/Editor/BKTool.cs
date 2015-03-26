

using UnityEditor;




public class BKTool
{
    [MenuItem("BKTool/Scene/Game")]
    public static void Scene_Game()
    {
        EditorApplication.OpenScene("Assets/Scenes/Game.unity");
    }

    [MenuItem("BKTool/Scene/UITest")]
    public static void Scene_UITest()
    {
        EditorApplication.OpenScene("Assets/Scenes/UITest.unity");
    }
}