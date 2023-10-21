using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderMenuAnim : MonoBehaviour
{
    LeanSelectableByFinger leanSelectableByFinger;

    public GameObject SliderMenu;
    public void ShowHideMenuOnButton()
    {
        if (SliderMenu != null)
        {
            Animator animator = SliderMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }

        }

    }
    public void ShowMenu3dSelect()
    {
        
        //this one doesn't work
        /*if (Input.GetMouseButtonDown(0))
        {
            //to prevent indicator to be clicked when using UI elements.
            //It is put after checking for button click and before creating Ray
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Selectable"))
                { GetComponent<Animator>().Play("Slider"); }
                else
                {
                    GetComponent<Animator>().Play("HideSlider");
                }
            }
        }*/
    }
}
