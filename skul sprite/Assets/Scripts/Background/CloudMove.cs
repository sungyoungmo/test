using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public GameObject[] clouds;
    public float cloudSpeed = 1.0f;
    private float maxPositionX = 120f;
    private float resetPositionX = -60f;

    void Update()
    {
        foreach (GameObject cloud in clouds)
        {
            // 구름을 오른쪽으로 이동
            cloud.transform.Translate(Vector3.right * cloudSpeed * Time.deltaTime);

            // 구름이 제한 위치에 도달하면 리셋 위치로 이동
            if (cloud.transform.position.x > maxPositionX)
            {
                cloud.transform.position = new Vector3(resetPositionX, cloud.transform.position.y, cloud.transform.position.z);
            }
        }
    }
}
