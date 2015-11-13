using System;
using AltBeaconOrg.BoundBeacon;
using Android.Util;

namespace AndroidAltBeaconLibrary.Sample
{			
	public class MonitorEventArgs : EventArgs
	{
		public Region Region { get; set; }
		public int State { get; set; }
	}

	public class MonitorNotifier : Java.Lang.Object, IMonitorNotifier
	{
		private const string TAG = "AndroidProximityReferenceApplication";

		public event EventHandler<MonitorEventArgs> DetermineStateForRegionComplete;
		public event EventHandler<MonitorEventArgs> EnterRegionComplete;
		public event EventHandler<MonitorEventArgs> ExitRegionComplete;

		public void DidDetermineStateForRegion(int state, Region region)
		{
			Log.Debug(TAG, "MonitorNotifier.DidDetermineStateForRegion");
			OnDetermineStateForRegionComplete(state, region);
		}

		public void DidEnterRegion(Region region)
		{
			Log.Debug(TAG, "MonitorNotifier.DidEnterRegion");
			OnEnterRegionComplete(region);
		}

		public void DidExitRegion(Region region)
		{
			Log.Debug(TAG, "MonitorNotifier.DidExitRegion");
			OnExitRegionComplete(region);
		}

		private void OnDetermineStateForRegionComplete(int state, Region region)
		{
			Log.Debug(TAG, "MonitorNotifier.OnDetermineStateForRegionComplete");
			if (DetermineStateForRegionComplete != null)
			{
				DetermineStateForRegionComplete(this, new MonitorEventArgs { State = state, Region = region });
			}
		}

		private void OnEnterRegionComplete(Region region)
		{
			Log.Debug(TAG, "MonitorNotifier.OnEnterRegionComplete");
			if (EnterRegionComplete != null)
			{
				EnterRegionComplete(this, new MonitorEventArgs { Region = region });
			}
		}

		private void OnExitRegionComplete(Region region)
		{
			Log.Debug(TAG, "MonitorNotifier.OnExitRegionComplete");
			if (ExitRegionComplete != null)
			{
				ExitRegionComplete(this, new MonitorEventArgs{ Region = region });
			}
		}
	}
}

