
## Vuforia Stereo


[Vuforia](https://www.vuforia.com/) is a widely used marker-based AR SDK. This Unity example shows how to run Vuforia AR in VMG-PROV. In the dual/stereo camera set up, left camera is used for vuforia. Camera calibration data is used by rendering shader for rectification, detail explaination could be found [here](https://github.com/flankechen/vuforia_stereo_rectify).

## Requirement:

1.  Recommended specs: Intel Core i5-4460/8G RAM/GTX 660/at least two USB3.0/
2.  Windows x64 version.(tested on win7/win10)

## Installation

1.  Install and [Unity](https://unity3d.com/) 64bit editor(tested on Unity 5.4.0f3 (64-bit))

2.  Download and install Visual Studio 2012, the download address is here: https://www.microsoft.com/zh-cn/download/details.aspx?id=30682

3.  (Optional) Download and install OpenCV(version 2.4.X) as: http://docs.opencv.org/2.4.11/doc/tutorials/introduction/windows_install/windows_install.html. Minimum opencv dlls is provided in "/Assets/Plugins/" in the Unity project. However, we strongly recomend a full installation of opencv and config opencv dlls into the environment variable.

4.  (Optional) /opencv_dll/ folder holds a Visual Studio 2012 opencv project, which builds a opencv_dll.dll and copy to Unity plugin. If you need to compile and build it, open "/vuforia_stereo/StereoCameraProj/opencv_dll/opencv_dll.sln" with Visual Studio 2012 and config it to your opencv environment following:http://docs.opencv.org/2.4.11/doc/tutorials/introduction/windows_visual_studio_Opencv/windows_visual_studio_Opencv.html, then build the release version dll.

## How to Run

1.  Make sure "/save_param/" holds the proper calibration files of your VMG-PROV.(Or it can be found in the USB disk)

2.  Open this project with Unity editor and open the scene "Demo".

3.  Run the project and place the camera towards the marker:"market4.jpg", a virtual sphere will appera.

4. change the vuforia app license key to yours and change the image target if you like.
