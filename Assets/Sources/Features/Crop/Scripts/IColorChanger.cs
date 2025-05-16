using UnityEngine;

public interface IColorChanger
{
    void ChangeColorTo(MeshRenderer mesh, Color targetColor, float duration);
}