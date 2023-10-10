using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public Transform bone; // �ѦҰ��Y����
    public AudioSource dogAudioSource; // ���s���n���ӷ�
    public Animator dogAnimator; // ����Animator�ե�
    public float maxVolumeDistance = 100f; // �̤j���q�Z��
    public float minVolumeDistance = 50f; // �̤p���q�Z��
    private Vector3 lastPosition; // �W�@�V����m

    void Start()
    {
        dogAudioSource.mute = true;
        lastPosition = transform.position;
    }

    private void Update()
    {
        // �p�⪱�a�P���Y�������Z��
        float distanceToBone = Vector3.Distance(transform.position, bone.position);

        // �ھڶZ���]�w���s�n�������q
        if (distanceToBone <= minVolumeDistance)
        {
            // ���a�Z�����Y50���إH���A���s�n���j�n
            dogAudioSource.volume = 1f;
        }
        else if (distanceToBone <= maxVolumeDistance)
        {
            // ���a�Z�����Y100���إH���A���s�n���ھڶZ���]�w���q
            float volume = 1f - (distanceToBone - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance);
            dogAudioSource.volume = Mathf.Clamp01(volume);
        }
        else
        {
            // ���a�Z�����Y�W�L100���ءA���s�n���R��
            dogAudioSource.volume = 0f;
        }

        // �p�⪱�a�����ʶZ��
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        // �ھڲ��ʶZ���ӱ���ʵe����
        if (distanceMoved > 0f)
        {
            // ���a�����ʡA���񪯪����ʰʵe
            dogAnimator.SetBool("IsMoving", true);
        }
        else
        {
            // ���a�S�����ʡA����񪯪����ʰʵe
            dogAnimator.SetBool("IsMoving", false);
        }

        // ��s�W�@�V����m
        lastPosition = transform.position;
    }
}
