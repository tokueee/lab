using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Titel : MonoBehaviour
{
    public GameObject came;
    [SerializeField] private GameObject canvaspanel;
    [SerializeField] private Text menu_closes;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject C_button;

    private float dtimes;
    private float stimers;

    private bool deley;

    private string menuclosetexts;

    void Menu_closes()
    {
        menuclosetexts = "MenuClose";
        menu_closes.text = menuclosetexts;
        menu_closes.fontSize = 45;
    }
    // Start is called before the first frame update
    void Start()
    {
        Menu_closes();
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        //cntrol + P‚ÅƒvƒŒƒC
        Debug.Log("Current Scene: " + SceneManager.GetActiveScene().name);
    }

    public void Click()
    {
        if (canvaspanel.activeSelf == false)
        {
            canvaspanel.SetActive(true);
            button.SetActive(false);
        }
    }

    public void Close_click()
    {
        if (canvaspanel.activeSelf)
        {
            deley = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Space) && canvaspanel.activeSelf == false)
        {
            canvaspanel.SetActive(true);
        }
        if (canvaspanel.activeSelf)
        {
            deley = true;
            //canvaspanel.SetActive(false);
        }*/

        if (deley)
        {
            dtimes = Time.deltaTime;
            stimers = stimers + (dtimes % 4.2f);
            Debug.Log(stimers);
            if (stimers > 4)
            {
                //deley = false;
                canvaspanel.SetActive(false);
                C_button.SetActive(false);
                if (stimers > 5)
                {
                    deley = false;
                    SceneManager.LoadScene("LightSampleScene");
                }
                //SceneManager.LoadScene("LightSampleScene");
                /*if (Input.GetKeyDown(KeyCode.Space) && canvaspanel.activeSelf)
                {
                    deley = true;
                    //canvaspanel.SetActive(false);
                }

                if (deley)
                {
                    times = Time.deltaTime;
                    stimer = stimer + (times % 4.2f);
                    Debug.Log(stimer);
                    if(stimer > 4)
                    {
                        //deley = false;
                        canvaspanel.SetActive(false);
                        if(stimer > 5)
                        {
                            deley = false;
                            SceneManager.LoadScene("LightSampleScene");
                        }
                        //SceneManager.LoadScene("LightSampleScene");
                    }
                }*/
            }
        }
    }
}
