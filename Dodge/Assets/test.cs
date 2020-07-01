using System.Security.Claims;
using UnityEditor;
using UnityEngine;

public class Test : EditorWindow
{
    [MenuItem("Window/test")]
    static void init()
    {
        Test Window = (Test)EditorWindow.GetWindow(typeof(Test));
        Window.Show();
    }

    void OnGUI()
    {
        Handles.color = Color.red;
        Handles.DrawRectangle(0, new Vector3(200, 200, 0), Quaternion.identity, 100);
        Handles.DrawSolidDisc(new Vector3(200, 200, 0), Vector3.forward, 100)
;            
    }
}
