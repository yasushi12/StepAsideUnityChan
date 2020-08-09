using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

	//Main Cameraオブジェクトを入れる
	private GameObject MyCamera;


	// Use this for initialization
	void Start () {
		//Main Cameraオブジェクト情報を取得する
		MyCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        //アイテムが画面外に出たとき（アイテムがMain CameraのZ座標以下になった）とき、アイテムを破棄する
        if (gameObject.transform.position.z <= MyCamera.transform.position.z)
        {
			Destroy(gameObject);
        }
	}
}
