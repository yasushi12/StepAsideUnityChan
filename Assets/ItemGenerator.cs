using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すX方向の範囲
	private float posRange = 3.4f;

	//unitychanオブジェクトを入れる
	private GameObject unitychan;
	//unitychanのZ座標の位置
	private float unitychanZPos;
	//距離
	private int i = 0;


	// Use this for initialization
	void Start () {

		//unitychanオブジェクトの取得
		unitychan = GameObject.Find("unitychan");
		
	}
	
	// Update is called once per frame
	void Update () {

		//unitychanのZ座標を取得
		unitychanZPos = unitychan.transform.position.z;

		//スタート地点からアイテム生成開始
		//以降は、unitychanから見て50m先までアイテムを自動生成
		if (startPos + i <= unitychanZPos + 50 && unitychanZPos + 50 <= goalPos)
        {
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range(1, 11);
			if (num <= 2)
			{
				//コーンをX軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f)
				{
					GameObject cone = Instantiate(conePrefab) as GameObject;
					cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychanZPos + 50);
				}
			}
			else
			{
				//レーンごとにアイテムを生成
				for (int j = -1; j <= 1; j++)
				{
					//アイテムの種類を決める
					int item = Random.Range(1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//60%コイン配置：30%車配置：10%何もなし
					if (1 <= item && item <= 6)
					{
						//コインを生成
						GameObject coin = Instantiate(coinPrefab) as GameObject;
						coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychanZPos + 50 + offsetZ);
					}
					else if (7 <= item && item <= 9)
					{
						//車を生成
						GameObject car = Instantiate(carPrefab) as GameObject;
						car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychanZPos + 50 + offsetZ);
					}
				}
			}

			//一定の距離をカウント
			i += 15;

		}
	}
}
