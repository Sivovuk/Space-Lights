using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPManager : MonoBehaviour {

	public void RemoveAds(){

		PurchaseManager.Instance.BuyNoAds();

	}

}
