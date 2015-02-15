using UnityEngine;
using System.Collections;

public class rotateScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {


		transform.rotation = Quaternion.identity;
		transform.Rotate (0, 0, DeviceRotation.getZRoll());
		print (DeviceRotation.getZRoll ());
	}
}

public static class DeviceRotation {
	private static bool gyroInitialized = false;
	
	public static bool HasGyroscope {
		get {
			return SystemInfo.supportsGyroscope;
		}
	}
	
	public static Quaternion Get() {
		if (!gyroInitialized) {
			InitGyro();
		}
		
		return HasGyroscope
			? ReadGyroscopeRotation()
				: Quaternion.identity;
	}
	
	private static void InitGyro() {
		if (HasGyroscope) {
			Input.gyro.enabled = true;                // enable the gyroscope
			Input.gyro.updateInterval = 0.0167f;    // set the update interval to it's highest value (60 Hz)
		}
		gyroInitialized = true;
	}
	
	private static Quaternion ReadGyroscopeRotation() {
		return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
	}

	public static float getZRoll() {
		Quaternion referenceRotation = Quaternion.identity;
		Quaternion deviceRotation = DeviceRotation.Get();
		Quaternion eliminationOfXY = Quaternion.Inverse(
			Quaternion.FromToRotation(referenceRotation * Vector3.forward, 
		                          deviceRotation * Vector3.forward)
			);
		Quaternion rotationZ = eliminationOfXY * deviceRotation;
		return rotationZ.eulerAngles.z;
	}
}