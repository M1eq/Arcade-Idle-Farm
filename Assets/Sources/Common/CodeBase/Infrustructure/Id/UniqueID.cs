using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UniqueID : MonoBehaviour
{
    [field: SerializeField] public string Id { get; private set; }
    
    #if UNITY_EDITOR
    
    public void ResetID() => 
        Id = string.Empty;
    
    public void UpdateID()
    {
        if (string.IsNullOrEmpty(Id))
            GenerateId();
        else
            RegenerateSameIds();
    }
    
    private void RegenerateSameIds()
    {
        UniqueID[] uniqueIDs = FindObjectsByType<UniqueID>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        if (uniqueIDs.Any(other => other != this && other.Id == Id))
            GenerateId();
    }

    private void GenerateId()
    {
        string generatedId = $"{gameObject.scene.name}_{GUID.Generate().ToString()}";
        Id = generatedId;

        if (Application.isPlaying == false)
        {
            EditorUtility.SetDirty(this);
            EditorSceneManager.MarkSceneDirty(gameObject.scene);
        }
    }
    
    #endif
}