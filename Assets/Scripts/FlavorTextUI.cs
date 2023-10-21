using System;

using JetBrains.Annotations;

using UnityEngine;
using UnityEngine.Events;
using Lean.Transition;
using Lean.Gui;
using Lean.Touch;

using LeanSelectable = Lean.Common.LeanSelectable;

[RequireComponent(typeof(RectTransform))]
public class FlavorTextUI : MonoBehaviour
{
	//[Serializable] public class UnityEventString : UnityEvent<string> {}
	
	//[Serializable] public class UnityEvent

	[SerializeField] private LeanSelectByFinger selectByFinger;
	
	/// <summary>This allows you to perform a transition when this tooltip appears.
	/// You can create a new transition GameObject by right clicking the transition name, and selecting <b>Create</b>.
	/// For example, the <b>Graphic.color Transition (LeanGraphicColor)</b> component can be used to change the color.
	/// NOTE: Any transitions you perform here should be reverted in the <b>Hide Transitions</b> setting using a matching transition component.</summary>
	[SerializeField] private LeanPlayer openTransitions = new LeanPlayer();

	/// <summary>This allows you to perform a transition when this tooltip hides.
	/// You can create a new transition GameObject by right clicking the transition name, and selecting <b>Create</b>.
	/// For example, the <b>Graphic.color Transition (LeanGraphicColor)</b> component can be used to change the color.</summary>
	[SerializeField] private LeanPlayer hideTransitions = new LeanPlayer();

	/// <summary>This allows you to perform an action when this tooltip appears.</summary>
	[SerializeField] private UnityEvent<String> onOpen = new UnityEvent<String>();
	/// <summary>This allows you to perform an action when this tooltip hides.</summary>
	[SerializeField] private UnityEvent onHide = new UnityEvent();
	
	[SerializeField] private UnityEvent<LeanSelectable> onSelectedNew     = new UnityEvent<LeanSelectable>();
	[SerializeField] private UnityEvent                 onSelectedNothing = new UnityEvent();
	
	//[SerializeField] private 
	
	[NonSerialized] private LeanSelectable currentSelection;
	//[NonSerialized] private Vector2 currentSelectionUIPosition; 

	[NonSerialized] private bool cachedRectTransformSet;

	[NonSerialized] private float currentDelay;
	
	[NonSerialized] private bool isOpen;

	private static Vector3[] corners = new Vector3[4];
	
	private void OnEnable()
	{
		selectByFinger.OnSelected.AddListener(OnNewSelected);
		
		selectByFinger.OnNothing.AddListener(OnNothingSelected);
	}

	private void OnDisable()
	{
		selectByFinger.OnSelected.RemoveListener(OnNewSelected);
		
		selectByFinger.OnNothing.RemoveListener(OnNothingSelected);
	}

	[PublicAPI]
	public void OnNewSelected(LeanSelectable selectable)
	{
		onSelectedNew?.Invoke(selectable);
		
		//Debug.Log("We have a selection!");

		//LeanSelectable selectable = selectByFinger.Selectables[0];
			
		//if(selectable != currentSelection)
		//{
		//Debug.Log("New selection!");
		//currentSelection = selectable;
		
		if (selectable.TryGetComponent(out FlavorText text))
		{
			//Debug.Log("...Has text component");
			
			if(text.Data == null)
			{
				throw new ArgumentNullException(nameof(text.Data));
			}
			
			if (isOpen)
			{
				Show(textData: text.Data);
			}
			else
			{
				Open(textData: text.Data);
			}
		}
		//}
	}

	[PublicAPI]
	public void OnNothingSelected()
	{
		onSelectedNothing?.Invoke();
		
		if(!isOpen)
		{
			return;
		}
		
		//currentSelection = null;
		
		Hide();
	}
	
	public void UpdateText(LeanSelectable selectable)
	{
		if (selectable.TryGetComponent(out FlavorText flavorText))
		{
			Open(textData: flavorText.Data);
		}
		else
		{
			Hide();
		}
	}

	public void Open(BoutiquesTextData textData)
	{
		isOpen = true;

		openTransitions?.Begin();

		Show(textData);
	}

	public void Show(BoutiquesTextData textData)
	{
		if (textData == null)
		{
			throw new ArgumentNullException(nameof(textData));
		}

		onOpen?.Invoke(textData.Text);
	}

	public void Hide()
	{
		isOpen = false;

		hideTransitions?.Begin();

		onHide?.Invoke();
	}
	
}