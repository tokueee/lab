using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls_text : MonoBehaviour
{
    private GameObject panel;//パネル操作用
    [SerializeField] private GameObject otext;//文字をつけ消しするための変数

    //テキスト取得
    [SerializeField] private Text pcontrol;
    [SerializeField] private Text mcontrol;
    [SerializeField] private Text light_s;
    [SerializeField] private Text mouse_c;
    [SerializeField] private Text menu_open;
    [SerializeField] private Text menu_close;

    //テキスト変更用変数
    private string headcontrol;
    private string movecontrol;
    private string lightcontrol;
    private string mousecontrol;
    private string menutext;
    private string menuclosetext;
    // Start is called before the first frame update

    void heading()
    {
        headcontrol = "PLAYER CONTROLS";
        pcontrol.text = headcontrol;
        pcontrol.fontSize = 50;
    }

    void Moving()
    {
        movecontrol = "MOVE\nW Key Front\tA Key Left\nS  key Back \tD Key Right\nMoveKey + SHIFT Dash";
        mcontrol.text = movecontrol;
        mcontrol.fontSize = 40;
    }
    void lighting()
    {
        lightcontrol = "LIGHT\nF Key    Light ON/OFF";
        light_s.text = lightcontrol;
        light_s.fontSize = 40;
    }
    void MouseControler()
    {
        mousecontrol = "MOUSE\nMoveMouse   CameraControl\nLeftClick   Use";
        mouse_c.text = mousecontrol;
        mouse_c.fontSize = 40;
    }
    void Menu_Opens()
    {
        menutext = "E Key MenuOpen";
        menu_open.text = menutext;
        menu_open.fontSize = 35;
    }
    void Menu_close()
    {
        menuclosetext = "E Key MenuClose";
        menu_close.text = menuclosetext;
        menu_close.fontSize = 45;
    }
    void TextSet()
    {
        heading();
        Moving();
        lighting();
        MouseControler();
        Menu_Opens();
        Menu_close();
    }

    void Start()
    {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
        TextSet();//初期設定
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && panel.activeSelf == false)
        {
            panel.SetActive(true);
            otext.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && panel.activeSelf)
        {
            panel.SetActive(false);
            otext.SetActive(true);
        }
    }
}
