using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

public class DropdownFunction : MonoBehaviour
{
    //public List<GameObject> gameObjects = new List<GameObject>();
    public GameObject all, floor1, floor2, floor3;
    public GameObject topGroup, middleGroup, bottomGroup;
    public Dropdown myValue;
    private void Start()
    {
        #region["UI Activation"]

        topGroup.SetActive(true);
        middleGroup.SetActive(false);
        bottomGroup.SetActive(false);
        #endregion

        #region["3d object Activation"]
        all.SetActive(true);
        floor1.SetActive(false);
        floor2.SetActive(false);
        floor3.SetActive(false);
        #endregion
    }

    public void DropDownFunctioning()
    {
        if (myValue.value == 0)
        {
            //all
            #region["UI Activation"]

            topGroup.SetActive(true);
            middleGroup.SetActive(false);
            bottomGroup.SetActive(false);
            #endregion

            all.SetActive(true);
            floor1.SetActive(false);
            floor2.SetActive(false);
            floor3.SetActive(false);
            
        }
        else if (myValue.value == 1)
        {
            //top
            #region["UI Activation"]

            topGroup.SetActive(true);
            middleGroup.SetActive(false);
            bottomGroup.SetActive(false);
            #endregion

            all.SetActive(false);
            floor1.SetActive(true);
            floor2.SetActive(false);
            floor3.SetActive(false);
            
        }
        else if (myValue.value == 2)
        {
            //middle
            #region["UI Activation"]

            topGroup.SetActive(false);
            middleGroup.SetActive(true);
            bottomGroup.SetActive(false);
            #endregion

            all.SetActive(false);
            floor1.SetActive(false);
            floor2.SetActive(true);
            floor3.SetActive(false);
            
        }
        else if (myValue.value == 3)
        {
            //bottom
            #region["UI Activation"]

            topGroup.SetActive(false);
            middleGroup.SetActive(false);
            bottomGroup.SetActive(true);
            #endregion

            all.SetActive(false);
            floor1.SetActive(false);
            floor2.SetActive(false);
            floor3.SetActive(true);
            
        }
    }
        
   
    /*public List<GameObject> floors;
    public Dropdown drop;

    private void Start()
    {
        floors[0].SetActive(true);
    }

    private int currentActiveIndex = 0;
    void OnMouseDown()
    {
        floors[currentActiveIndex].SetActive(false);
        currentActiveIndex++;
        if (currentActiveIndex >= floors.Count)
            currentActiveIndex = 0;
        floors[currentActiveIndex].SetActive(true);
    }

    public void DropdownFunctioning()
    {
        floors[currentActiveIndex].SetActive(false);
        currentActiveIndex=drop.;
        if (currentActiveIndex >= floors.Count)
            currentActiveIndex = 0;
        floors[currentActiveIndex].SetActive(true);
    }
    private void Update()
    {
    }*/






}
