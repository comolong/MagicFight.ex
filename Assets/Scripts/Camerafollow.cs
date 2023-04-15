using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] Transform player;//�쨤���m
    [SerializeField] float timeoffset;//���Y���ʳt��(�Ʀr�V�j�V��)
    [SerializeField] Vector3 offsetPos;//���Y�|�����}��h��

    [SerializeField] Vector3 boundsMin;//���Y�k�B�W��ɳ]�w
    [SerializeField] Vector3 boundsMax;//���Y���B�U��ɳ]�w


    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 startPos = transform.position;//���o��e���Y��m
            Vector3 targetPos = player.position;//���o��e�}���m

            targetPos.x += offsetPos.x;//�]�w���Y����
            targetPos.y += offsetPos.y;//�]�w���Y����
            targetPos.z = transform.position.z;//�Sԣ����

            targetPos.x = Mathf.Clamp(targetPos.x, boundsMin.x, boundsMax.x);//�������Y�W�X�a�����
            targetPos.y = Mathf.Clamp(targetPos.y, boundsMin.y, boundsMax.y);//�������Y�W�X�a�����

            float t = 1f - Mathf.Pow(1f - timeoffset, Time.deltaTime * 30);//�p�����Y���ʳt��
            transform.position = Vector3.Lerp(startPos, targetPos, t);//�N���Y��startPos�H�C�����ʶZ��t���ʨ�targetPos
        }
        
    }
}
