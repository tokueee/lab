using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randam : MonoBehaviour
{
    bool SaveGet_rand = true;

    Player playerscript; //�ĂԃX�N���v�g�ɂ����Ȃ���
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {
        GameObject obj = GameObject.Find("Player"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<Player>();
        //�t���Ă���X�N���v�g���擾
        if (playerscript.flags[0])
        {
            if (Get_Randam(ref SaveGet_rand))
            {
                //Debug.Log�����_���������Ăяo�������Ƃ�\������
                
                Debug.Log("hit");
            }
        }
        else
        {
            SaveGet_rand = true;
        }
    }


    private bool Get_Randam(ref bool SaveGet_rand)//1/5�̊m����true��Ԃ��֐�
    {
        bool get_randam = false;//true=get
        //�����_������x�~�߂邽�߂̕ϐ�
        int chance = 5;
        if (SaveGet_rand) {
            int randnum5 = Random.Range(0, chance);//0����chance�܂ł̃����_���ϐ��𐶐��̂���
                                                  //Debug_log�\��
            Debug.Log("randnum");
            Debug.Log(randnum5);

            if(randnum5 == 0)
            {
                get_randam = true;
            }
            SaveGet_rand = false;
        }

        return get_randam;
    }
}
