using UnityEditor;

[CustomEditor(typeof(GameBoard))]
public class GameBoardEditor : Editor
{
    SerializedProperty connections;

    void OnEnable()
    {
        connections = serializedObject.FindProperty("connections");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(connections, true);

        serializedObject.ApplyModifiedProperties();
    }
}
