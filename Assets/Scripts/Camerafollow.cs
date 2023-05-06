using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] Transform player;//抓角色位置
    [SerializeField] float timeoffset;//鏡頭移動速度(數字越大越快)
    [SerializeField] Vector3 offsetPos;//鏡頭會偏移腳色多少

    [SerializeField] Vector3 boundsMin;//鏡頭右、上邊界設定
    [SerializeField] Vector3 boundsMax;//鏡頭左、下邊界設定


    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 startPos = transform.position;//取得當前鏡頭位置
            Vector3 targetPos = player.position;//取得當前腳色位置

            targetPos.x += offsetPos.x;//設定鏡頭偏移
            targetPos.y += offsetPos.y;//設定鏡頭偏移
            targetPos.z = transform.position.z;//沒啥屁用

            targetPos.x = Mathf.Clamp(targetPos.x, boundsMin.x, boundsMax.x);//防止鏡頭超出地圖邊界
            targetPos.y = Mathf.Clamp(targetPos.y, boundsMin.y, boundsMax.y);//防止鏡頭超出地圖邊界

            float t = 1f - Mathf.Pow(1f - timeoffset, Time.deltaTime * 30);//計算鏡頭移動速度
            transform.position = Vector3.Lerp(startPos, targetPos, t);//將鏡頭由startPos以每次移動距離t移動到targetPos
        }
        
    }
}
