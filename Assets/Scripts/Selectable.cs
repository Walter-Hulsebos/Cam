
using UnityEngine;
//This script works together with ClickedObject script
public class Selectable : MonoBehaviour
{
    // Stores the current selection and can only be modified by this class
    private static Selectable _currentSelection;
    // Public read-only accessor if needed
    public static Selectable CurrentSelection => _currentSelection;

    // Deselects if current selection and resets the selection
    public static void ClearSelection()
    {
        // if there is a current selection -> deselect it
        if (_currentSelection) _currentSelection.Deselect();

        // "forget" the reference
        _currentSelection = null;
    }

    // In general rather cache reused references
    [SerializeField] private Renderer _renderer;

    // Optional accessor
    public bool IsSelected => _currentSelection == this;

    private void Awake()
    {
        // if not referenced yet get it ONCE on runtime
        if (!_renderer) _renderer = GetComponent<Renderer>();

        // I would also ensure the default state initially
        Deselect();
    }

    public void Select()
    {
        // if this is already the selected object -> nothing to do
        if (_currentSelection == this) return;

        // otherwise first clear any existing selection
        ClearSelection();

        // set your color
        _renderer.material.color = Color.yellow;

        // and store yourself as the current selection
        _currentSelection = this;
        
    }

    public void Deselect()
    {
        // set your color
        _renderer.material.color = Color.white;

        // if this is the current selection forget the reference
        // usually this should always be the case anyway
        if (_currentSelection == this)
        {
            _currentSelection = null;
        }
    }
}
