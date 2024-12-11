using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class AndroidRateUsPopUp : MonoBehaviour
{
	public delegate void OnRateUSPopupComplete(RateInfo state);



	public string title;

	public string message;

	public string rate;

	public string remind;

	public string declined;

	public event AndroidRateUsPopUp.OnRateUSPopupComplete onRateUSPopupComplete;

	private void RaiseOnOnRateUSPopupComplete(RateInfo state)
	{
		if (this.onRateUSPopupComplete != null)
		{
			this.onRateUSPopupComplete(state);
		}
	}

	public static AndroidRateUsPopUp Create()
	{
		return AndroidRateUsPopUp.Create("Like the Game?", "Rate US");
	}

	public static AndroidRateUsPopUp Create(string title, string message)
	{
		return AndroidRateUsPopUp.Create(title, message, "Rate!", "Remind me later", "No, thanks");
	}

	public static AndroidRateUsPopUp Create(string title, string message, string rate, string remind, string declined)
	{
		AndroidRateUsPopUp androidRateUsPopUp = new GameObject("AndroidRateUsPopUp").AddComponent<AndroidRateUsPopUp>();
		androidRateUsPopUp.title = title;
		androidRateUsPopUp.message = message;
		androidRateUsPopUp.rate = rate;
		androidRateUsPopUp.remind = remind;
		androidRateUsPopUp.declined = declined;
		androidRateUsPopUp.init();
		return androidRateUsPopUp;
	}

	public void init()
	{
		AndroidNative.ShowRateUsPopupNative(this.title, this.message, this.rate, this.remind, this.declined);
	}

	public void OnRatePopUpCallBack(string buttonIndex)
	{
		int num = (int)Convert.ToInt16(buttonIndex);
		if (num != 0)
		{
			if (num != 1)
			{
				if (num == 2)
				{
					this.RaiseOnOnRateUSPopupComplete(RateInfo.DECLINED);
				}
			}
			else
			{
				this.RaiseOnOnRateUSPopupComplete(RateInfo.REMIND);
			}
		}
		else
		{
			this.RaiseOnOnRateUSPopupComplete(RateInfo.RATED);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
