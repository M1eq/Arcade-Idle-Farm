using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(UniqueID))]
public class UniqueIDEditor : Editor
{
    private void OnEnable() =>
        UpdateID();

    private void UpdateID()
    {
        var uniqueID = (UniqueID)target;
        
        if (string.IsNullOrEmpty(uniqueID.Id))
            GenerateIdFor(uniqueID);
        else
            RegenerateSameIds(uniqueID);
    }

    private void RegenerateSameIds(UniqueID uniqueID)
    {
        UniqueID[] uniqueIDs = FindObjectsByType<UniqueID>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        if (uniqueIDs.Any(other => other != uniqueID && other.Id == uniqueID.Id))
            GenerateIdFor(uniqueID);
    }

    private void GenerateIdFor(UniqueID uniqueID)
    {
        string generatedId = $"{uniqueID.gameObject.scene.name}_{GUID.Generate().ToString()}";
        uniqueID.SetId(generatedId);

        if (Application.isPlaying == false)
        {
            EditorUtility.SetDirty(uniqueID);
            EditorSceneManager.MarkSceneDirty(uniqueID.gameObject.scene);
        }
    }
}