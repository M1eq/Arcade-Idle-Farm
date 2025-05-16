using DG.Tweening;
using UnityEngine;

public class ColorChanger : IColorChanger
{
    public void ChangeColorTo(MeshRenderer mesh, Color targetColor, float duration) => 
        mesh.material.DOColor(targetColor, duration);
}
