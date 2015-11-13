using System;
using AltBeaconOrg.BoundBeacon;
using System.Collections.Generic;
using Android.Util;

namespace AndroidAltBeaconLibrary.Sample
{
	public class RangeEventArgs : EventArgs
	{
		public Region Region { get; set; }
		public ICollection<Beacon> Beacons { get; set; }
	}

	public class RangeNotifier : Java.Lang.Object, IRangeNotifier
	{
		private const string TAG = "AndroidProximityReferenceApplication";

		public event EventHandler<RangeEventArgs> DidRangeBeaconsInRegionComplete;

		public void DidRangeBeaconsInRegion(ICollection<Beacon> beacons, Region region)
		{
			Log.Debug(TAG, "RangeNotifier.DidRangeBeaconsInRegion");
			OnDidRangeBeaconsInRegion(beacons, region);
		}

		private void OnDidRangeBeaconsInRegion(ICollection<Beacon> beacons, Region region)
		{
			Log.Debug(TAG, "RangeNotifier.OnDidRangeBeaconsInRegion");
			if (DidRangeBeaconsInRegionComplete != null)
			{
				DidRangeBeaconsInRegionComplete(this, new RangeEventArgs { Beacons = beacons, Region = region });
			}
		}
	}
}

