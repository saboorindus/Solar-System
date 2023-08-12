using UnityEngine;
using UnityEngine.UI;

public class ClampScrollView : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;

    private float maxScrollPos;

    void Start()
    {
        // Calculate the maximum scroll position
        CalculateScrollBounds();
    }

    private void CalculateScrollBounds()
    {
        // Get the height of the content and the scroll view viewport
        float contentHeight = content.rect.height;
        float viewportHeight = ((RectTransform)scrollRect.viewport.transform).rect.height;

        // Calculate the maximum scroll position
        maxScrollPos = Mathf.Max(contentHeight - viewportHeight, 0);
    }

    void LateUpdate()
    {
        // Update the maximum scroll position (in case the content size changes dynamically)
        CalculateScrollBounds();

        // Get the current vertical scroll position (normalized)
        float normalizedScrollPos = scrollRect.normalizedPosition.y;

        // Clamp the normalized scroll position to the allowed range (0 to 1)
        float clampedNormalizedPos = Mathf.Clamp01(normalizedScrollPos);

        // Set the clamped normalized position to the scroll view's content
        scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, clampedNormalizedPos);
    }
}
