using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Vector3 rotationSpeed = new Vector3(0, 45, 0); // ���઺�t��

    private void Update()
    {
        // �b�C�@�V��s�ɱ��ફ�骺�����
        transform.rotation *= Quaternion.Euler(rotationSpeed * Time.deltaTime);
    }
}
