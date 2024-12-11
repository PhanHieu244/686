
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class AdmobManager : MonoBehaviour
{
	private sealed class _RequestBanerCo_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal AdmobManager _this;

		internal object _current;

		internal bool _disposing;

		internal int _PC;

		object IEnumerator<object>.Current
		{
			get
			{
				return this._current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return this._current;
			}
		}

		public _RequestBanerCo_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(5f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				this._this.RequestBanner();
				this._PC = -1;
				break;
			}
			return false;
		}

		public void Dispose()
		{
			this._disposing = true;
			this._PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	
	private bool _isRewardedVideoSuccess;

	public event Action<bool> RewardedVideoFinishedEvent;

    public string AdmobInterestitalID, AdmobBannerID;

	public void Init()
	{
	}

	public bool IsRewardedVideoLoaded()
	{
		return false;
	}

	public void ShowRewardedAd()
	{
		
	}

	private void OnAdClosed(object sender, EventArgs e)
	{
		if (this.RewardedVideoFinishedEvent != null)
		{
			this.RewardedVideoFinishedEvent(this._isRewardedVideoSuccess);
		}
		this.ResetRewardedVideoStatur();
	}

	private void ResetRewardedVideoStatur()
	{
		this._isRewardedVideoSuccess = false;
	}


	public void RequestInterstitial()
	{
		
	}

	public bool IsInterstitialLoaded()
	{
		return false;
	}

	public void ShowInterstitial()
	{
	
	}

	public void RequestBanner()
	{
		
	}

	
	private IEnumerator RequestBanerCo()
	{
		AdmobManager._RequestBanerCo_c__Iterator0 _RequestBanerCo_c__Iterator = new AdmobManager._RequestBanerCo_c__Iterator0();
		_RequestBanerCo_c__Iterator._this = this;
		return _RequestBanerCo_c__Iterator;
	}

	private void BannerViewOnOnAdLoaded(object sender, EventArgs e)
	{
		
	}

	public void ShowBanner()
	{
		
	}

	

	public void RemoveAds()
	{
		
	}
}
