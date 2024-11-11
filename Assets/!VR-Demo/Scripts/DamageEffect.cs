using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DamageEffect : MonoBehaviour
{
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private float fadeTime = 3f;

    private Image damageEffectImage;

    private void Awake()
    {
        damageEffectImage = GetComponent<Image>();
    }

    private void Update()
    {
        FadeOutEffect();
    }

    private void FadeOutEffect()
    {
        if (damageEffectImage.color.a > 0)
        {
            float targetAlpha = Mathf.MoveTowards(damageEffectImage.color.a, 0f, fadeTime * Time.deltaTime);
            damageEffectImage.color = new Color(damageColor.r, damageColor.g, damageColor.b, targetAlpha);
        }
    }

    public void TriggerColorChange()
    {
        damageEffectImage.color = damageColor;
    }
}
