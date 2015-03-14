public static class tk2dMenu
{
	public const string root = "2D Toolkit/";
#if UNITY_4_6 || UNITY_5_0 || UNITY_6_0
	public const string createBase = "GameObject/2D Object/tk2d/";
#else
	public const string createBase = "GameObject/Create Other/tk2d/";
#endif
}
