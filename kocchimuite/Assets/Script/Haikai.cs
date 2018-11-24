using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haikai : MonoBehaviour {
    float TimeCount = 1;
    private float speed = 1f;
    private float rotationSmooth = 8f;
    private Vector3 targetPosition;
    private float changeTargetSqrDistance = 1f;
    private void Start()
    {
        targetPosition = GetRandomPositionOnLevel();
    }

    private void Update()
    {
        // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
        float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
        if (sqrDistanceToTarget < changeTargetSqrDistance)
        {
            targetPosition = GetRandomPositionOnLevel();
        }
        else
        { 
            float TimeCount = 1;
        }

        // 目標地点の方向を向く
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        TimeCount -= Time.deltaTime;
        if (TimeCount <= 0)
        {
            // 前方に進む
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }    
    }

    public Vector3 GetRandomPositionOnLevel()
    {
        float levelSize = 3f;
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }
}