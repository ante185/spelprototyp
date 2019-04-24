using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class displayText : MonoBehaviour
{
    public GameMasterEmil list;

    public Text hS;


    private void Start()
    {
        hS.text = list.completeList;
    }




}
