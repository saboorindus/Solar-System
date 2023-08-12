using UnityEngine;
using UnityEngine.EventSystems;

public class MyPrefabDetails : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Replace this code with the behavior you want when the object is clicked
        Debug.Log("GameObject Clicked: " + name);
    }
}
