using UnityEngine;
using System.Collections;

public class CopyFromVuforiaCamera : MonoBehaviour
{

    private MeshFilter _vuforiaBackgroundMesh = null;
    private MeshFilter _customMeshFilter = null;

    private GameObject _backgroundPlaneL;

    private Camera _cameraR, _cameraL;


	void Start () 
    {
        _customMeshFilter = GetComponent<MeshFilter>();
        _backgroundPlaneL = GameObject.Find("BackgroundPlaneL");
        _cameraR = GameObject.Find("CameraR").GetComponent<Camera>();
        _cameraL = GameObject.Find("CameraL").GetComponent<Camera>();
	}
	

	void Update () 
    {
        if (_backgroundPlaneL.GetComponent<MeshFilter>() && _vuforiaBackgroundMesh == null)
            _vuforiaBackgroundMesh = _backgroundPlaneL.GetComponent<MeshFilter>();
      //  else
      //      return;

		if (_vuforiaBackgroundMesh) 
		{
			transform.localPosition = _vuforiaBackgroundMesh.transform.localPosition;
			transform.localEulerAngles = _vuforiaBackgroundMesh.transform.localEulerAngles;
			transform.localScale = _vuforiaBackgroundMesh.transform.localScale;

			_customMeshFilter.mesh = _vuforiaBackgroundMesh.mesh;
			_cameraR.projectionMatrix = _cameraL.projectionMatrix;
			_cameraR.fieldOfView = _cameraL.fieldOfView;
			_cameraR.CopyFrom(_cameraL);
			_cameraR.transform.localPosition = new Vector3 (_cameraL.transform.localPosition.x+24, _cameraL.transform.localPosition.y, _cameraL.transform.localPosition.z);
			_cameraR.rect = new Rect(0.5f, 0, 0.5f, 1f);
			_cameraR.cullingMask = -1 ^ (1 << LayerMask.NameToLayer("L"));
		}

	}
}
