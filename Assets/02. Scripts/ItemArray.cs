﻿using UnityEngine;
using System.Collections;

public class ItemArray : MonoBehaviour {
    ArrayList arr_item = new ArrayList();
    IList item;
    int random;
    public GameObject obj_panel;
    public GameObject obj_act_panel;
    public GameObject obj_IceCube_Tank;
    public GameObject obj_IceCube_Whale;
    //public GameObject Items_MemoryChip;
    public GameObject Items_MemoryChip_hyup;
    public GameObject Items_MemoryChip_maeul;
    public GameObject Items_MemoryChip_bada;
    public GameObject Items_MemoryChip_sup;
    public GameObject Items_MemoryChip_dongul;
    public GameObject Text_Trash_Active;
    public GameObject Text_Trash_hint;
    public GameObject Text_SheetMusic_Active;
    public GameObject Text_SheetMusic_hint;
    public GameObject Tank2;
    public GameObject Fade;
    public GameObject slide_panel;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void tankstop()
    {
        SendMessage("tank_stop");
    }

    void tankstart()
    {
        SendMessage("tank_start");
    }

    void GainItem(Collider other){
        tankstop();
        string[] name = other.gameObject.name.Split('_');
        item = arr_item;
        if (name[0].Equals("Tank1"))
        {
            GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "전력을 나눠줘야 겠군.");
            tankstart();
        }
        else if (name[0].Equals("Obj"))
        {
            //만약 오브젝트를 발동시킬 수 있는 아이템이 있다면
            if (name[1].Equals("PineTree"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "계곡을 따라 나무들이 드문드문 보인다. 몇 백 년은 되었을 법한 것을 보니 예전에도 이 곳은 추운 곳이었던 것 같다.");
                tankstart();
            }
            else if (name[1].Equals("StrangeFlower")){
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 야생화를 꺾어서 가져가고 싶어하는 눈치다.");
                tankstart();
            }
            else if (name[1].Equals("Stone"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "물개로 추정된다. 펭귄의 상위 포식자가 있었나 보다.");
                tankstart();
            }
            else if (name[1].Equals("Trash"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 악취가 난다며 싫어 한다.없애자.");
                if (item.Contains("Items_Lighter"))
                {
                    obj_act_panel.SetActive(true);
                    Text_SheetMusic_Active.SetActive(false);
                    Text_Trash_Active.SetActive(true);
                    obj_act_panel.SendMessage("obj_act_yes_start", other);
                }
                else
                {
                    obj_panel.SetActive(true);
                    Text_SheetMusic_hint.SetActive(false);
                    Text_Trash_hint.SetActive(true);
                    obj_panel.SendMessage("obj_yes_start", other);
                }
                tankstart();
            }
            else if (name[1].Equals("Fish"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 나에게 먹으라고 물고기를 줬지만, 나는 물고기를 먹을 수 없다.");
                tankstart();
            }
            else if (name[1].Equals("Whale"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 호기심어린 눈빛으로 고래의 사체를 관찰한다.");
                tankstart();
            }
            else if (name[1].Equals("Piano"))
            {
                if (item.Contains("Items_SheetMusic"))
                {
                    obj_act_panel.SetActive(true);
                    Text_Trash_Active.SetActive(false);
                    Text_SheetMusic_Active.SetActive(true);
                    obj_act_panel.SendMessage("obj_act_yes_start", other);
                }
                else
                {
                    GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "나무에 무언가가 박혀있다. 악기? 음악이 존재하던 문명이 이 행성에 있던 모양이다.");
                    obj_panel.SetActive(true);
                    Text_Trash_hint.SetActive(false);
                    Text_SheetMusic_hint.SetActive(true);
                    obj_panel.SendMessage("obj_yes_start", other);
                }
                tankstart();
            }
            else if (name[1].Equals("ScotsPine"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "떡갈나무는 온대림에서 나는 식물이다. 과거 이 지역이 온대림이었던 것을 확인. 지금은 왜?");
                tankstart();
            }
            else if (name[1].Equals("BaobabTree"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "이 지역과는 어울리지 않는 큰 나무다. 이런 식물이 살 수 있는 환경이라는 것은 지하에는 물이 있는 것인가? 나뭇가지에 풍경이 메달려있다.");
                tankstart();
            }
            /*
            else if (name[1].Equals("CardboardBox"))
            {
                //만약 메모리칩 다 얻었으면 '아무것도 없다'만 떠야한다!!!!
                random = Random.Range(0, 3);
                Debug.Log(random);
                if (random >= 1)
                {
                    GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "메모리칩을 발견했다.");
                    item.Add(Items_MemoryChip);
                }
                else
                {
                    GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아무것도 없다.");
                }
                tankstart();
            }
            */
            else if (name[1].Equals("PengRock"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 날아다니는 전설인가?");
                tankstart();
            }
            else if (name[1].Equals("SinkHole"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "구멍에 빠져서 떨어졌다.");
                tankstart();
            }
            else if (name[1].Equals("IceCube"))
            {
                if (name[2].Equals("Whale"))
                {
                    Fade.SetActive(true);
                    Fade.SendMessage("Fade");
                    Destroy(other.gameObject);
                    GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 호기심어린 눈빛으로 고래의 사체를 관찰한다.");
                }
                else if (name[2].Equals("Tank"))
                {
                    if (item.Contains("Items_Penguin"))
                    {
                        Fade.SetActive(true);
                        Fade.SendMessage("Fade");
                        GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄에게 펭귄 마법을 써달라고 부택해야 겠다.(펭귄 인형을 건낸다.)");
                        Destroy(other.gameObject);
                    }
                    else
                    {
                        GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "탐사정1이 빙하에 갇혀있다. 구해야 한다.");
                    }
                }
                tankstart();
            }
            else if (name[1].Equals("PenguinTotemOld"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "세워져 있으나 많이 파손되어 있다. 별다른 기능이 없어 보인다");
                tankstart();
            }   
            else if (name[1].Equals("NoticeBoard"))
            {
                var map = GameObject.Find("UI Canvas").transform.FindChild("MapCanvus");
                map.gameObject.SetActive(true);
                SendMessage("tank_stop");
            }
            else if (name[1].Equals("IceSlide"))
            {
                //맵 이동
                slide_panel.SetActive(true);
            }
            else if (name[1].Equals("Adult"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "...나를 별로 좋아하지 않는 것 같다.");
                //미는 에니메이션
                Tank2.transform.Translate(new Vector3(0, 0, -15 * Time.deltaTime));
                tankstart();
            }
        }
        else if(name[0].Equals("Items"))
        {
            Debug.Log("Gain Items");
            item.Add(other.gameObject.name);
            //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아이템 " + other.gameObject.name + " 획득");
            if (name[1].Equals("Penguin"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "너무 귀엽다.");
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아이템 " + other.gameObject.name + " 획득");
            }
            else if (name[1].Equals("MemoryChip"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "메모리칩을 획득했다.");
            }
            else if (name[1].Equals("Lighter"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아이템 " + other.gameObject.name + " 획득");
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "불을 붙이는 물건이군.");
            }
            else if (name[1].Equals("SheetMusic"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아이템 " + other.gameObject.name + " 획득");
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "이상한 문양이 적힌 문서다. 해독할 수 없다.");
            }
            else if (name[1].Equals("PenguinTotem"))
            {
                GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "Totem");
            }
            tankstart();
        }
        //확인창 같은거 눌러서 tank_start시켜야 함
    }
}
