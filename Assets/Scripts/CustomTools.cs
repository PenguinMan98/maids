using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(Tile)), CanEditMultipleObjects]
public class CustomTools : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Update Adjacent Walls"))
        {
            Debug.Log("Time to update the walls!");
            //do the thing
        }
    }
}
