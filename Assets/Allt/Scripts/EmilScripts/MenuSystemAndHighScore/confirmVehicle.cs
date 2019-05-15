using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class confirmVehicle : MonoBehaviour {

    public Button vehOne;
    public Button vehTwo;



    private void Start()
    {
        vehOne.onClick.AddListener(selectOne);
        vehTwo.onClick.AddListener(selectTwo);
    }



    public void beginPlay()
    {
        SceneManager.LoadScene(1);




    }


    private void selectOne()
    {
        PlayerPrefs.SetInt("selection", 0);

    }
    private void selectTwo()
    {
        PlayerPrefs.SetInt("selection", 1);


    }

}
