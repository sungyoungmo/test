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
            // ������ ���������� �̵�
            cloud.transform.Translate(Vector3.right * cloudSpeed * Time.deltaTime);

            // ������ ���� ��ġ�� �����ϸ� ���� ��ġ�� �̵�
            if (cloud.transform.position.x > maxPositionX)
            {
                cloud.transform.position = new Vector3(resetPositionX, cloud.transform.position.y, cloud.transform.position.z);
            }
        }
    }
}
