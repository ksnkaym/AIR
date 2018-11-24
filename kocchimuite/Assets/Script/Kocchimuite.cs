using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kocchimuite : MonoBehaviour {
    //Unityちゃん
    public GameObject UnityChan;

    //顔ボーン
    [SerializeField] //inspectorウィンドウで編集できるようにするコマンド
    private Transform Charactor1_Head = null;

    //キャッシュ用カメラ Transform
    private Transform camra;

    //向きの初期条件
    private float rotationSmooth = 0.01f;
    private Vector3 cameraPosition;

    //初期処理
    public void Start(){
        this.camra = Camera.main.transform;
    }

    //毎フレーム処理
    public void FixedUpdate() {
        var cameraPosition = this.camra.position;

        //クリックしたら 
        if (Input.GetMouseButton(0))
        {
            //目の高さにあわせる
            cameraPosition.y = 0.3f;

            //顔を上げ下げ
            this.transform.LookAt(cameraPosition);
            var angle = this.transform.rotation.eulerAngles.x;
            angle = angle > 180f ? angle - 360f : angle;
            this.Charactor1_Head.localRotation = Quaternion.Euler(90f + Mathf.Clamp(angle, -30f, 30f), 0f, 0f);

            //身体をまわす
            //cameraPosition.y = this.transform.position.y;
            //this.transform.LookAt(cameraPosition);

            // 目標地点の方向を向く
            Quaternion cameraRotation = Quaternion.LookRotation(cameraPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, Time.deltaTime * rotationSmooth);

            ////Unityちゃんが1秒見てくれるコルーチンを開始   
            //StartCoroutine("Naniyo");
            //}

            //コルーチンの中身
            //IEnumerator Naniyo(){
            //    yield return new WaitForSeconds(1.0f);
        }
    }
}
