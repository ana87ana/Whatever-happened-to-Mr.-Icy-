using UnityEngine;

public class LastScene : MonoBehaviour
{
    public RectTransform uiElement; 
    public Vector2 targetPosition;    
    public float dropDuration = 1f;

    public void StartDrop()
    {
        StartCoroutine(DropCoroutine());
    }

    private System.Collections.IEnumerator DropCoroutine()
    {
        Vector2 startPos = uiElement.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < dropDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / dropDuration);
            uiElement.anchoredPosition = Vector2.Lerp(startPos, targetPosition, t);
            yield return null;
        }
    }
}
