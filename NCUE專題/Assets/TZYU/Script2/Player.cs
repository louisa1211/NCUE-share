using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public string sceneName; // �ؼг������W��

    private void OnCollisionEnter(Collision collision)
    {
        // �ˬd�I��������O�_�O�A�Q�n���ؼЪ���
        if (collision.gameObject.CompareTag("bone"))
        {
            // ������ؼг���
            SceneManager.LoadScene("Dog_Win");
        }
    }
}
