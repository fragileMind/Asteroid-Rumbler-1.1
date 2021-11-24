using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClickText : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
            if(linkIndex > -1)
            {
                Debug.Log("Linked id: " + linkIndex);
            }
        }
    }
}
