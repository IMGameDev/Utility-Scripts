using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogExtension {
	private static List<string> _registeredObjects = new List<string>();
	
	public static void EnableLogging(this object obj) {
		// Don't add to the _registeredObjects, if the class name of this object already exist
		if (_registeredObjects.Contains(obj.GetType().Name)) return;

		_registeredObjects.Add(obj.GetType().Name);
	}
	
	public static void DisableLogging(this object obj) {
		_registeredObjects.Remove(obj.GetType().Name);
	}

	public static void Log(this object obj, params object[] msg) {
		PrintLog(obj, "black", "", msg);
	}

	public static void LogSuccess(this object obj, params object[] msg) {
		PrintLog(obj, "green", "SUCCESS ", msg);
	}

	public static void LogWarning(this object obj, params object[] msg) {
		PrintLog(obj, "yellow", "WARNING ", msg);
	}

	public static void LogError(this object obj, params object[] msg) {
		PrintLog(obj, "red", "ERROR ", msg);
	}

	private static void PrintLog(object obj, string color, string prefix, params object[] msg) {
		if (!_registeredObjects.Contains(obj.GetType().Name)) return;
		
		Debug.Log($"<color={color}>{prefix}</color> {string.Join(" ", msg)}");
	}
}
