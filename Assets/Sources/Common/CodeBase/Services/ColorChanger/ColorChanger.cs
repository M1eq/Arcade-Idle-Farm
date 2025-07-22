using DG.Tweening;
using UnityEngine;

public class ColorChanger : IColorChanger
{
    public void ChangeColorFor(MeshRenderer mesh, Color targetColor, float duration)
    {
        DOTween.Kill(mesh.material);
        
        mesh.material.DOColor(targetColor, duration)
            .SetLink(mesh.gameObject);
    }
}
