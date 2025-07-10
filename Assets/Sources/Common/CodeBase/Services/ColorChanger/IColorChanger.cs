using UnityEngine;

public interface IColorChanger
{
    void ChangeColorFor(MeshRenderer mesh, Color targetColor, float duration);
}