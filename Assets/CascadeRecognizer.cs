using OpenCvSharp;
using OpenCvSharp.Demo;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class CascadeRecognizer : WebCamera
{
    public TextAsset faces;
    public GameObject playerObject;
    public RectTransform canvasRectTransform;
    private CascadeClassifier cascadeFaces;
	[SerializeField] float threshX;

    protected override void Awake()
    {
        base.Awake();

        // classifier
        FileStorage storageFaces = new FileStorage(faces.text, FileStorage.Mode.Read | FileStorage.Mode.Memory);
        cascadeFaces = new CascadeClassifier();
        if (!cascadeFaces.Read(storageFaces.GetFirstTopLevelNode()))
        {
            throw new System.Exception("FaceProcessor.Initialize: Failed to load faces cascade classifier");
        }
    }

    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
    {
        Mat image = OpenCvSharp.Unity.TextureToMat(input);
        Mat gray = image.CvtColor(ColorConversionCodes.BGR2GRAY);
        Mat equalizeHistMat = new Mat();

        Cv2.EqualizeHist(gray, equalizeHistMat);
        OpenCvSharp.Rect[] rawFaces = cascadeFaces.DetectMultiScale(gray, 1.1, 6);
        for (int i = 0; i < rawFaces.Length; i++)
        {
            //Cv2.Rectangle((InputOutputArray)image, rawFaces[i], Scalar.LightGreen, 2);

            //顔検出位置の座標の計算
            var cx = rawFaces[i].TopLeft.X + (rawFaces[i].Width / 2f);
            var cy = rawFaces[i].TopLeft.Y + (rawFaces[i].Height / 2f);

			Debug.Log(cx);

        	Vector3 pos = playerObject.transform.position;
			if (cx < image.Width / 2f - threshX){
            	pos.x = 2.0f;
			}
			else if (cx > image.Width / 2f + threshX){
            	pos.x = -2.0f;
			}
			else {
            	pos.x = 0.0f;
			}
        	playerObject.transform.position = pos;
        }
        output = OpenCvSharp.Unity.MatToTexture(image);
        return true;
    }
}
