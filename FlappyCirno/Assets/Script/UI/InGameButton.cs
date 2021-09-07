using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
public class InGameButton : MonoBehaviour, IPointerDownHandler
{
    private IInput input;
    [Inject]
    private void Construct(IInput input)
    {
        this.input = input;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        input.GetClick();
    }
}
