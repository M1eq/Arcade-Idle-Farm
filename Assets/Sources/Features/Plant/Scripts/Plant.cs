using DG.Tweening;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private PlantScaleConfig _config;

    public void Initialize(PlantScaleConfig config) => 
        _config = config;

    public void ScaleToSeed() => 
        ScaleTo(_config.SeedScale, _config.SeedScaleDuration);

    public void ScaleToWatered() => 
        ScaleTo(_config.WateredScale, _config.WateredScaleDuration);

    private void ScaleTo(Vector3 newScale, float duration)
    {
        transform.DOScale(newScale, duration)
            .SetEase(Ease.OutBack)
            .SetLink(transform.gameObject);
    }
}
