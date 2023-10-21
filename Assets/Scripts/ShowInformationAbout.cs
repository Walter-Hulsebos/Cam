using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowInformationAbout : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //to prevent indicator to be clicked when using UI elements.
            //It is put after checking for button click and before creating Ray
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Selectables"))
                {
                    GetComponent<Animator>().Play("Slider");
                }


            }
            else
            {
                GetComponent<Animator>().Play("HideSlider");
            }

            //Try with leanTouch
            /*if (Input.GetMouseButtonDown(0))
            {
                //to prevent indicator to be clicked when using UI elements.
                //It is put after checking for button click and before creating Ray
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    return;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Boutiques"))
                    {
                        GetComponent<Animator>().Play("Slider");
                    }


                }
                else
                {
                    GetComponent<Animator>().Play("HideSlider");
                }*/
            }
    }
}
