using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int m_seconds;          //�˼ƭp�ɸg���⪺�`���
    public int m_min;              //�Ω�]�w�˼ƭp�ɪ�����
    public int m_sec;              //�Ω�]�w�˼ƭp�ɪ����

    public Text m_timer;           //�]�w�e���˼ƭp�ɪ���r


    void Start()
    {
      StartCoroutine(Countdown());   //�I�s�˼ƭp�ɪ���{

    }

    IEnumerator   Countdown()
    {
        yield return new WaitForSeconds(3); 
        m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        m_seconds = (m_min * 60) + m_sec;       //�N�ɶ����⬰���

        while (m_seconds > 0)                   //�p�G�ɶ��|������
        {
            yield return new WaitForSeconds(1); //���Ԥ@��A������

            m_seconds--;                        //�`��ƴ� 1
            m_sec--;                            //�N��ƴ� 1

            if (m_sec < 0 && m_min > 0)         //�p�G��Ƭ� 0 �B�����j�� 0
            {
                m_min -= 1;                     //���N������h 1
                m_sec = 59;                     //�A�N��Ƴ]�� 59
            }
            else if (m_sec < 0 && m_min == 0)   //�p�G��Ƭ� 0 �B�����j�� 0
            {
                m_sec = 0;                      //�]�w��Ƶ��� 0
            }
            m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        }

        yield return new WaitForSeconds(1);   //�ɶ������ɡA��� 00:00 ���d�@��


        // Load "Win" scene after the countdown finishes
        SceneManager.LoadScene("Dog_Lose");
    }
}