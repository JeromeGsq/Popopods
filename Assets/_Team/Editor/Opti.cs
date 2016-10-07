using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


[InitializeOnLoad]
public static class Opti {

    // Chargement de la liste des Gameobjects présents dans la hiérarchie
    static List<int> markedObjects;

    static Texture2D cubeGizmo;


    // Constructeur
    static Opti() {
        cubeGizmo = AssetDatabase.LoadAssetAtPath("Assets/_Team/Editor/Gizmo/cube.png", typeof(Texture2D)) as Texture2D;
        EditorApplication.hierarchyWindowItemOnGUI += DrawLine;

        EditorApplication.hierarchyWindowItemOnGUI += ShowColliderLogo;
        EditorApplication.hierarchyWindowItemOnGUI += ShowMeshLogo;
        EditorApplication.hierarchyWindowItemOnGUI += ShowAnimatorLogo;
        EditorApplication.hierarchyWindowItemOnGUI += ShowLightLogo;
    }

    #region Collider logo
    static void ShowColliderLogo(int instanceID, Rect selectionRect) {
        Rect logoRect = new Rect(selectionRect);
        logoRect.width = 8;
        logoRect.x -= 20;
        logoRect.y += 4;

        Rect textRect = new Rect(selectionRect);
        textRect.y += 1;

        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if(go != null && go.GetComponent<Collider>()) {

            GUI.color = new Color(0, 1, 0);
            GUI.Label(logoRect, cubeGizmo);
            GUI.color = new Color(1, 1, 1);
        }
    }
    #endregion

    #region Mesh logo
    static void ShowMeshLogo(int instanceID, Rect selectionRect) {
        Rect logoRect = new Rect(selectionRect);
        logoRect.width = 8;
        logoRect.x -= 16;
        logoRect.y += 4;

        Rect textRect = new Rect(selectionRect);
        textRect.y += 1;

        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if(go != null && go.GetComponent<MeshRenderer>()) {

            GUI.color = new Color(1, 1, 1);
            GUI.Label(logoRect, cubeGizmo);
            GUI.color = new Color(1, 1, 1);
        }
    }
    #endregion

    #region Animator logo
    static void ShowAnimatorLogo(int instanceID, Rect selectionRect) {
        Rect logoRect = new Rect(selectionRect);
        logoRect.width = 8;
        logoRect.x -= 16;
        logoRect.y += 8;

        Rect textRect = new Rect(selectionRect);
        textRect.y += 1;

        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if(go != null && (go.GetComponent<Animator>() || go.GetComponent<Animation>())) {

            GUI.color = new Color(1, 0, 0);
            GUI.Label(logoRect, cubeGizmo);
            GUI.color = new Color(1, 1, 1);
        }
    }
    #endregion

    #region Light logo
    static void ShowLightLogo(int instanceID, Rect selectionRect) {
        Rect logoRect = new Rect(selectionRect);
        logoRect.width = 8;
        logoRect.x -= 20;
        logoRect.y += 8;

        Rect textRect = new Rect(selectionRect);
        textRect.y += 1;

        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if(go != null && go.GetComponent<Light>()) {

            GUI.color = new Color(1, 1, 0);
            GUI.Label(logoRect, cubeGizmo);
            GUI.color = new Color(1, 1, 1);
        }
    }
    #endregion



    #region Separation Line
    //Créé une ligne de séparation dans la hiérachie
    [MenuItem("GameObject/Opti/Separation Line", false, 0)]
    static void Init() {
        GameObject go = new GameObject("___");
        if(Selection.activeTransform != null) {
            go.transform.parent = Selection.activeTransform;
        }
    }

    static void DrawLine(int instanceID, Rect selectionRect) {
        Rect r = new Rect(selectionRect);
        r.x = r.x - 30;
        r.y = r.y + 1;

        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if(go != null && go.name.Contains("___") && EditorGUIUtility.currentViewWidth > 0) {

            if(go.name.Contains("(")) {
                go.name = "___";
            }
            GUI.color = new Color(1, 1, 1);
            string size = "";
            for(int i = 0; i < EditorGUIUtility.currentViewWidth; i++) {
                if(i % 6 == 0) {
                    size += "_";
                }
            }
            GUI.Label(r, size);
        }
    }
    #endregion


}

