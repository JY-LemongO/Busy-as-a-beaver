using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonResizer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private static readonly float resizeValue = 0.9f;
	private Button button;

	#region Lifecycle
	private void Awake()
	{
		button = GetComponent<Button>();
	}
	#endregion

	#region Public Functions
	public void OnPointerDown(PointerEventData eventData)
	{
		if (button.interactable)
		{
			transform.localScale = Vector3.one * resizeValue;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		transform.localScale = Vector3.one;
	}
	#endregion
}