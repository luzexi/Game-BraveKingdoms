using UnityEngine;
using System.Collections;

//this script used for test purpose ,it do by default 1000 logs  + 1000 warnings + 1000 errors
//so you can check the functionality of in game logs
//just drop this scrip to any empty game object on first scene your game start at
public class TestReporter : MonoBehaviour {
	
	public int logTestCount = 1000 ;
	int currentLogTestCount;
	Reporter reporter ;
	GUIStyle style ;
	Rect rect1 ;
	Rect rect2 ;
	Rect rect3 ;
	Rect rect4 ;
	Rect rect5 ;
	Rect rect6 ;
	// Use this for initialization
	void Start () {
		Application.runInBackground = true ;

		reporter = FindObjectOfType( typeof(Reporter)) as Reporter ;
		Debug.Log("test long text sdf asdfg asdfg sdfgsdfg sdfg sfg" 	+ 
		          "sdfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdfg " 	+ 
		          "sdfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdfg " 	+ 
		          "sdfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdfg " 	+ 
		          "sdfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdfg " 	+ 
		          "sdfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdfg ssssssssssssssssssssss" 	+ 
		          "asdf asdf asdf asdf adsf \n dfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdf" +
		          "asdf asdf asdf asdf adsf \n dfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdf"+
		          "asdf asdf asdf asdf adsf \n dfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdf"+
		          "asdf asdf asdf asdf adsf \n dfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdf"+
		          "asdf asdf asdf asdf adsf \n dfgsdfg sdfg sdf gsdfg sfdg sf gsdfg sdfg asdf");
		
		style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter ;
		style.normal.textColor = Color.white ;
		style.wordWrap = true ;
		
		for( int i = 0 ; i < 10 ; i ++ )
		{
			Debug.Log("Test Collapsed log");
			Debug.LogWarning("Test Collapsed Warning");
			Debug.LogError("Test Collapsed Error");
		}

		rect1 = new Rect (Screen.width/2-120, Screen.height/2-225, 240, 50) ;
		rect2 = new Rect (Screen.width/2-120, Screen.height/2-175, 240, 100) ;
		rect3 = new Rect (Screen.width/2-120, Screen.height/2-50, 240, 50) ;
		rect4 = new Rect (Screen.width/2-120, Screen.height/2, 240, 50) ;
		rect5 = new Rect (Screen.width/2-120, Screen.height/2+50, 240, 50) ;
		rect6 = new Rect (Screen.width/2-120, Screen.height/2+100, 240, 50) ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		int drawn = 0;
		while ( currentLogTestCount < logTestCount && drawn < 10)
		{
			Debug.Log("Test Log " + currentLogTestCount );
			Debug.LogError("Test LogError " + currentLogTestCount );
			Debug.LogWarning("Test LogWarning " + currentLogTestCount );
			drawn++;
			currentLogTestCount++;
		}
		 
		//GameObject o = null; 
		//o.name = "opps this is null";
	}
	void OnGUI()
	{
		if( reporter && !reporter.show )
		{
			GUI.Label (rect1, "Draw circle on screen to show logs" , style);
			GUI.Label (rect2, "To use Reporter just drag drop reporter prefab in first scene your game start at " , style);
			if( GUI.Button( rect3 , "Load ReporterScene")){
				Application.LoadLevel("ReporterScene");
			}
			if( GUI.Button( rect4 , "Load test1")){
				Application.LoadLevel("test1");
			}
			if( GUI.Button( rect5 , "Load test2")){
				Application.LoadLevel("test2");
			}
			GUI.Label (rect6, "fps : " + reporter.fps.ToString("0.0") , style);
		}
	}
}
