using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDisplay : MonoBehaviour
{
    public int currentCamIndex = 0;

    WebCamTexture tex;

    public Text coso;

    public Text startStopText;

    public RawImage display;

    public void startstopcamera()
    {
        
        if(tex != null)
        {
            StopCamera();
            startStopText.text = "Start Camera";
        }
        else
        {
            StartCamç();
            startStopText.text = "Stop Camera";
            rotation();

        }
    }

    public void changeCamera()
    {
        if(tex !=null)
        {
            if (currentCamIndex < WebCamTexture.devices.Length)
            {
                currentCamIndex += 1;
            }
            if (currentCamIndex == WebCamTexture.devices.Length)
            {
                currentCamIndex = 0;
            }
          
            StartCamç();
            rotation();

        }
    }

    private void StartCamç()
    {
        WebCamDevice device = WebCamTexture.devices[currentCamIndex];

        tex = new WebCamTexture(device.name);

        display.texture = tex;
        tex.Play();
    }

    private void rotation()
    {
        if (tex.videoRotationAngle == 270)
        {
            display.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (tex.videoRotationAngle == 90)
        {
            display.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
    }

    private void StopCamera()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }
}
