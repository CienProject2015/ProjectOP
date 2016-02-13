using UnityEngine;
using System.Collections;

public class ItemArray : MonoBehaviour {
    ArrayList arr_item = new ArrayList();
    IList item;
    public GameObject obj_panel;
    public GameObject obj_act_panel;
    public GameObject Items_MemoryChip;
    public GameObject Text_Trash_Active;
    public GameObject Text_Trash_hint;
    public GameObject Text_SheetMusic_Active;
    public GameObject Text_SheetMusic_hint;
    public GameObject Tank2;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GainItem(Collider other){
        SendMessage("tank_stop");
        string[] name = other.gameObject.name.Split('_');
        item = arr_item;

        if (name[0].Equals("Obj"))
        {
            //만약 오브젝트를 발동시킬 수 있는 아이템이 있다면
            if (name[1].Equals("PineTree"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "계곡을 따라 나무들이 드문드문 보인다. 몇 백 년은 되었을 법한 것을 보니 예전에도 이 곳은 추운 곳이었던 것 같다.");
                Debug.Log("계곡을 따라 나무들이 드문드문 보인다. 몇 백 년은 되었을 법한 것을 보니 예전에도 이 곳은 추운 곳이었던 것 같다.");
            }
            else if (name[1].Equals("StrangeFlower")){
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 야생화를 꺾어서 가져가고 싶어하는 눈치다.");
                Debug.Log("펭귄이 야생화를 꺾어서 가져가고 싶어하는 눈치다.");
            }
            else if (name[1].Equals("Stone"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "물개로 추정된다. 펭귄의 상위 포식자가 있었나 보다.");
                Debug.Log("물개로 추정된다. 펭귄의 상위 포식자가 있었나 보다.");
            }
            else if (name[1].Equals("Trash"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 악취가 난다며 싫어 한다.없애자.");
                Debug.Log("펭귄이 악취가 난다며 싫어 한다.없애자.");
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
                
            }
            else if (name[1].Equals("Fish"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 나에게 먹으라고 물고기를 줬지만, 나는 물고기를 먹을 수 없다.");
                Debug.Log("펭귄이 나에게 먹으라고 물고기를 줬지만, 나는 물고기를 먹을 수 없다.");
            }
            else if (name[1].Equals("Whale"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "펭귄이 호기심어린 눈빛으로 고래의 사체를 관찰한다.");
                Debug.Log("펭귄이 호기심어린 눈빛으로 고래의 사체를 관찰한다.");
                //펭귄이 마법을 써서 고래 사채만 남음.
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
                    //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "나무에 무언가가 박혀있다. 악기? 음악이 존재하던 문명이 이 행성에 있던 모양이다.");
                    Debug.Log("나무에 무언가가 박혀있다. 악기? 음악이 존재하던 문명이 이 행성에 있던 모양이다.");
                    obj_panel.SetActive(true);
                    Text_Trash_hint.SetActive(false);
                    Text_SheetMusic_hint.SetActive(true);
                    obj_panel.SendMessage("obj_yes_start", other);
                }
            }
            else if (name[1].Equals("ScotsPine"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "떡갈나무는 온대림에서 나는 식물이다. 과거 이 지역이 온대림이었던 것을 확인. 지금은 왜?");
                Debug.Log("떡갈나무는 온대림에서 나는 식물이다. 과거 이 지역이 온대림이었던 것을 확인. 지금은 왜?");
            }
            else if (name[1].Equals("BaobabTree"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "이 지역과는 어울리지 않는 큰 나무다. 이런 식물이 살 수 있는 환경이라는 것은 지하에는 물이 있는 것인가? 나뭇가지에 풍경이 메달려있다.");
                Debug.Log("이 지역과는 어울리지 않는 큰 나무다. 이런 식물이 살 수 있는 환경이라는 것은 지하에는 물이 있는 것인가? 나뭇가지에 풍경이 메달려있다.");
            }
            else if (name[1].Equals("CardboardBox"))
            {
                var random = Random.Range(0, 3);
                Debug.Log(random);
                if (random >= 1)
                {
                    //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "메모리칩을 발견했다.");
                    Debug.Log("메모리칩을 발견했다.");
                    item.Add(Items_MemoryChip);
                }
                else
                {
                    //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아무것도 없다.");
                    Debug.Log("아무것도 없다.");
                }
            }
        }
        else if(name[0].Equals("Items"))
        {
            Debug.Log("Gain Items");
            item.Add(other.gameObject.name);
            //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아이템 " + other.gameObject.name + " 획득");
            if (name[1].Equals("Penguin"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아이템 " + other.gameObject.name + " 획득");
                Debug.Log("너무 귀엽다.");
            }
            else if (name[1].Equals("Lighter"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아이템 " + other.gameObject.name + " 획득");
                Debug.Log("불을 붙이는 물건이군.");
            }
            else if (name[1].Equals("SheetMusic"))
            {
                //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "아이템 " + other.gameObject.name + " 획득");
                Debug.Log("이상한 문양이 적힌 문서다. 해독할 수 없다.");
            }
            else if (name[1].Equals("PenguinTotem"))
            {
                Debug.Log("Totem");
            }
        }
        Debug.Log(other.gameObject.name);
        //확인창 같은거 눌러서 tank_start시켜야 함
        Tank2.SendMessage("tank_start");
    }
}
