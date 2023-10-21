using System;
using UnityEngine;
using UnityEngine.Events;
using Lean.Transition;
using Lean.Gui;
using Lean.Touch;


[RequireComponent(typeof(RectTransform))]
public class BoutiquesTextUIStatic : MonoBehaviour
{
   /*using System;
using UnityEngine;
using UnityEngine.Events;
using Lean.Transition;
using Lean.Gui;
using Lean.Touch;


[RequireComponent(typeof(RectTransform))]
public class BoutiquesTextUIStatic : MonoBehaviour
{
    [System.Serializable] public class UnityEventString : UnityEvent<string> { }

    public enum BoundaryType
    {
        None,
        FlipPivot,
        ShiftPosition
    }

    [SerializeField] private LeanSelectByFinger selectByFinger;

    /// <summary>This allows you to delay how quickly the tooltip will appear or switch.</summary>
    public float ShowDelay { set { showDelay = value; } get { return showDelay; } }
    [SerializeField] private float showDelay;

    /// <summary>Move the attached Transform when the tooltip is open?</summary>
    bool Move { set { move = value; } get { return move; } }
    [SerializeField] private bool move = true;

    /// <summary>This allows you to control how the tooltip will behave when it goes outside the screen bounds.
    /// FlipPivot = If the tooltip goes outside one of the screen boundaries, flip its pivot point on that axis so it goes the other way.
    /// ShiftPosition = If the tooltip goes outside of the screen boundaries, shift its position until it's back inside.
    /// NOTE: If <b>FlipPivot</b> is used and the tooltip is larger than the screen size, then it will revert to <b>ShiftPosition</b>.</summary>
    public BoundaryType Boundary { set { boundary = value; } get { return boundary; } }
    [SerializeField] private BoundaryType boundary;

    /// <summary>This allows you to perform a transition when this tooltip appears.
    /// You can create a new transition GameObject by right clicking the transition name, and selecting <b>Create</b>.
    /// For example, the <b>Graphic.color Transition (LeanGraphicColor)</b> component can be used to change the color.
    /// NOTE: Any transitions you perform here should be reverted in the <b>Hide Transitions</b> setting using a matching transition component.</summary>
    public LeanPlayer OpenTransitions { get { if (openTransitions == null) openTransitions = new LeanPlayer(); return openTransitions; } }
    [SerializeField] private LeanPlayer openTransitions;

    /// <summary>This allows you to perform a transition when this tooltip hides.
    /// You can create a new transition GameObject by right clicking the transition name, and selecting <b>Create</b>.
    /// For example, the <b>Graphic.color Transition (LeanGraphicColor)</b> component can be used to change the color.</summary>
    public LeanPlayer HideTransitions { get { if (hideTransitions == null) hideTransitions = new LeanPlayer(); return hideTransitions; } }
    [SerializeField] private LeanPlayer hideTransitions;

    /// <summary>This allows you to perform an action when this tooltip appears.</summary>
    public UnityEventString OnOpen { get { if (onOpen == null) onOpen = new UnityEventString(); return onOpen; } }
    [SerializeField] private UnityEventString onOpen;

    /// <summary>This allows you to perform an action when this tooltip hides.</summary>
    public UnityEvent OnHide { get { if (onHide == null) onHide = new UnityEvent(); return onHide; } }
    [SerializeField] private UnityEvent onHide;


    #region[Added code] 

    public UnityEvent OnChangeTitle { get { if (onChangeTitle == null) onChangeTitle = new UnityEvent(); return onChangeTitle; } }
    [SerializeField] private UnityEvent onChangeTitle;
    public UnityEvent OnChangeDescription { get { if (onChangeDescription == null) onChangeDescription = new UnityEvent(); return onChangeTitle; } }
    [SerializeField] private UnityEvent onChangeDescription;

    //description&title hide
    public UnityEvent OnHideTitle { get { if (onHideTitle == null) onHideTitle = new UnityEvent(); return onHideTitle; } }
    [SerializeField] private UnityEvent onHideTitle;
    public UnityEvent OnHideDescription { get { if (onHideDescription == null) onHideDescription = new UnityEvent(); return onChangeTitle; } }
    [SerializeField] private UnityEvent onHideDescription;

    public bool isShowing;

    [SerializeField] private RectTransform rectLimit;
    [SerializeField] private RectTransform target;
    [SerializeField] private RectTransform rectToLimit;

    #endregion

    [System.NonSerialized]
    private RectTransform cachedRectTransform;

    [System.NonSerialized]
    private bool cachedRectTransformSet;

    [System.NonSerialized]
    private float currentDelay;

    [System.NonSerialized]
    private bool open;

    private static Vector3[] corners = new Vector3[4];

    // #if UNITY_EDITOR
    // private void Reset()
    // {
    // 	if(TryGetComponent(out Text text))
    // 	{
    // 		onOpen.AddListener(call: str => text.text = str);
    // 		
    // 		onHide.AddListener(() => text.text = "");
    // 	}
    // 	
    // 	//TODO: Make option for TextMeshPro text.
    // }
    // #endif



    protected virtual void Update()
    {
        if (cachedRectTransformSet == false)
        {
            cachedRectTransform = GetComponent<RectTransform>();
            cachedRectTransformSet = true;
        }

        //var finalData  = default(LeanTooltipData);
        var finalPoint = default(Vector2);


        if (selectByFinger.Selectables.Count > 0)
        {
            Debug.Log("We have a selection!");

            var selectable = selectByFinger.Selectables[0];

            Debug.Log("Selected item = " + selectable.name);

            if (selectable.TryGetComponent(out BoutiquesText text))
            {
                Debug.Log("...Has text component");

                if (text.Data == null)
                {
                    throw new ArgumentNullException(nameof(text.Data));
                }

                Debug.Log(message:
                    "<b>" + text.Data.Title + "</b>\n" +
                    "<i>" + text.Data.Text + "</i>");

                if (open)
                {

                    Show(textData: text.Data);

                }

                else
                {

                    Open(textData: text.Data);


                }

            }
            else
            {

                Debug.Log("...<b>Does NOT</b> have a text component");
                Hide();

            }
        }
        else
        {

            Debug.Log("Selected nothing, hiding");
            Hide();

        }

    }

    public void UpdateText(LeanSelectable selectable)
    {
        if (selectable.TryGetComponent(out BoutiquesText boutiquesText))
        {
            Open(textData: boutiquesText.Data);
        }
        else
        {


            Hide();

        }
    }

    public void Open(BoutiquesTextData textData)
    {
        open = true;



        if (openTransitions != null)
        {
            openTransitions.Begin();
        }


        Show(textData);
    }

    public void Show(BoutiquesTextData textData)
    {
        if (textData == null)
        {
            throw new ArgumentNullException(nameof(textData));
        }

        if (onOpen != null)
        {
            onOpen.Invoke(textData.Text);
        }
    }

    public void Hide()
    {
        if (hideTransitions != null)
        {
            hideTransitions.Begin();
            isShowing = false;

        }

        if (onHide != null)
        {
            onHide.Invoke();
            isShowing = false;


        }
    }


}*/

}
