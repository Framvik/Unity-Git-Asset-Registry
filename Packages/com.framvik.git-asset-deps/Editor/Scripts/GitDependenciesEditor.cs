using UnityEditor;
using UnityEngine;

namespace Framvik.GitAssets.Dependencies
{
    /// <summary>
    /// Simple editor for callbacks when editing GitDependencies files.
    /// </summary>
    [CustomEditor(typeof(GitDependencies))]
    public class GitDependenciesEditor : Editor
    {
        private SerializedProperty m_URLs;
        private bool m_PendingChanges = false;

        private void OnEnable()
        {
            m_URLs = serializedObject.FindProperty("GitURLs");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_URLs);
            if (serializedObject.ApplyModifiedProperties())
                m_PendingChanges = true;

            if (m_PendingChanges)
            {
                EditorGUILayout.LabelField("Changes have been made to the dependencies!");
                EditorGUILayout.LabelField("You may want to refresh the git dependency solver");
            }
            if (GUILayout.Button("Refresh Git Packages"))
            {
                if (GitAssetDependencyEvents.RefreshGitDependencies())
                {
                    m_PendingChanges = false;
                }
            }
        }
    }
}