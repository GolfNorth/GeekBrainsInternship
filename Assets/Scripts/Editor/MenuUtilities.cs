using GeekBrainsInternship.Contexts;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    public sealed class MenuUtilities : MonoBehaviour
    {
        #region Methods

        [MenuItem("GolfNorth/Generate Scene Hierarchy")]
        private static void GenerateSceneHierarchy()
        {
            if (GameObject.Find("[root]") != null)
            {
                Debug.LogWarning("Root GameObject already exist");
                
                return;
            }

            var root = new GameObject("[root]");
            root.transform.SetAsFirstSibling();
            
            var contexts = new GameObject("[contexts]");
            contexts.transform.parent = root.transform;
            
            var managers = new GameObject("[managers]");
            managers.transform.parent = root.transform;
            
            var views = new GameObject("[views]");
            views.transform.parent = root.transform;
            
            Selection.activeObject = root;
            SetExpandedRecursive(root, true);
        }
        
        [MenuItem("GolfNorth/Create Project Context")]
        private static void CreateProjectContext(MenuCommand menuCommand)
        {
            var go = new GameObject();
            go.name = "[project-context]";
            go.AddComponent<ProjectContext>();
            
            PrefabUtility.SaveAsPrefabAsset(go, "Assets/Resources/ProjectContext.prefab");
            
            DestroyImmediate(go);
        }

        private static void SetExpandedRecursive(Object go, bool expand)
        {
            var type = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
            var methodInfo = type.GetMethod("SetExpandedRecursive");
 
            EditorApplication.ExecuteMenuItem("Window/Hierarchy");
            var window = EditorWindow.focusedWindow;

            if (methodInfo != null) 
                methodInfo.Invoke(window, new object[] {go.GetInstanceID(), expand});
        }

        #endregion
    }
}