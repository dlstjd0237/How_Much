using UnityEditor;
using UnityEngine;

public class WelcomeWindow : EditorWindow
{
    private GUIStyle textureButton;
    private GUIStyle headingText;
    private GUIStyle commonText;

    private Texture2D top;

    private Texture2D image1;

    private Texture2D linkButton;

    private Texture2D logo;

    private Vector2 scrollIndex;

    [UnityEditor.Callbacks.DidReloadScripts]
    private static void OpenWindowOnUnityStart()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
            return;

 
    }




    private void DrawFooter()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(logo, textureButton))
            Application.OpenURL("https://www.emaceart.com");

        GUILayout.BeginVertical();
        GUILayout.Space(10f);
        GUILayout.Label("Visit my free zone. If you like this content, don't forget leave review :)", commonText);
        GUILayout.Space(10f);
        if (GUILayout.Button(linkButton, textureButton))
            Application.OpenURL("https://assetstore.unity.com/lists/free-zone-178789");

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }
}