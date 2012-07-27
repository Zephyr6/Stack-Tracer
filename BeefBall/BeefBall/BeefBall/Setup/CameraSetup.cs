using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlatRedBall;

namespace BeefBall
{
	internal static class CameraSetup
	{
		internal static void SetupCamera(Camera cameraToSetUp)
		{
			FlatRedBallServices.GraphicsOptions.SetResolution(800, 600);
			cameraToSetUp.UsePixelCoordinates(false, 400, 300);



		}
	}
}
