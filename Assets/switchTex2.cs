using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchTex2 : MonoBehaviour
{

    public Texture black;
    public Texture white;
    public Texture scratches;
    private Renderer mr;
    private Texture nonScratches;
    private int selection;

    // Use this for initialization
    void Awake()
    {

        mr = GetComponent<Renderer>();

        selection = PlayerPrefs.GetInt("selection");

        if (selection == 1)
        {
            mr.material.SetTexture("_MainTex", white);
        }
        else if (selection != 1)
        {
            mr.material.SetTexture("_MainTex", black);
        }


        nonScratches = mr.material.GetTexture("_MainTex");


    }


    public void takingDamage()
    {
        mr.material.SetTexture("_MainTex", scratches);


    }
    public void notTakingDamage()
    {
        mr.material.SetTexture("_MainTex", nonScratches);
    }









}