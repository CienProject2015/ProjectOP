
using UnityEngine;
using System.Collections;
using System.IO;

public class ScreenShot : MonoBehaviour {

	private byte[] imageByte;

	public void OnClickScreenShot(){
		if (Application.platform == RuntimePlatform.Android) {
			StartCoroutine (ScreenShotRoutine ());
		} else {
			Application.CaptureScreenshot ("UnityScreenShot_" + Time.time.ToString () + ".png");
		}
		GameObject.Find ("_EventSystem").GetComponent<LogManager> ().ReceiveLog ("사진 저장 완료");

	}

	IEnumerator ScreenShotRoutine(){
		yield return new WaitForEndOfFrame ();
		Texture2D tex = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, true);
		tex.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0, true);
		tex.Apply ();

		imageByte = tex.EncodeToJPG ();
		DestroyImmediate (tex);
		string fileName = "mnt/sdcard/DCIM/Camera/UnityScreenShot_" + Time.time.ToString () + ".jpg";
		File.WriteAllBytes (fileName, imageByte);

		AndroidJavaClass classPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject> ("currentActivity"); 
		AndroidJavaClass classUri = new AndroidJavaClass ("android.net.Uri"); 
		AndroidJavaObject objIntent = new AndroidJavaObject ("android.content.Intent", new object[2] {
			"android.intent.action.MEDIA_SCANNER_SCAN_FILE",
			classUri.CallStatic<AndroidJavaObject> ("parse", "file://" + fileName)
		}); 
		objActivity.Call ("sendBroadcast", objIntent);
	}

}
