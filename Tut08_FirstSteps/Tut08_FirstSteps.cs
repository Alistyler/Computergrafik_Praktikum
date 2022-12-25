using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Engine.Core.Scene;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;
using Fusee.Engine.Gui;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuseeApp
{
    [FuseeApplication(Name = "Tut08_FirstSteps", Description = "Yet another FUSEE App.")]
    public class Tut08_FirstSteps : RenderCanvas
    {
        private SceneContainer _scene;
        private SceneRendererForward _sceneRenderer;
        private float _cubeAngle = 0;
        private Camera _camera;
        private Transform _cubeTransform;
        private Transform _cubeTransform_r;
        private Transform _cubeTransform_k;
        private Transform _cubeTransform_l;
        private Transform _cameraTransform;


        // Init is called on startup. 
        public override void Init()
        {
            // Create a scene tree containing the camera :
            // _scene---+
            //          |
            //          +---cameraNode-----_camera

        // THE CAMERA
            // Two components: one Transform and one Camera component.
            _camera =  new Camera(ProjectionMethod.Perspective, 5, 100, M.PiOver4) {BackgroundColor = (float4) ColorUint.Greenery};
            _cameraTransform = new Transform { Translation = new float3(0, 0, -50) };
            var cameraNode = new SceneNode();
            cameraNode.Components.Add(_cameraTransform);
            cameraNode.Components.Add(_camera);

        // THE CUBE
            // Three components: one Transform, one SurfaceEffect (blue material) and the Mesh
            _cubeTransform = new Transform { Scale = new float3(1, 1, 1), Translation = new float3(0, 0, 0) };
            var cubeEffect = MakeEffect.FromDiffuseSpecular((float4) ColorUint.Blue);
            var cubeMesh = new CuboidMesh(new float3(10, 10, 10));

            _cubeTransform_l = new Transform { Scale = new float3(1, 1, 1), Translation = new float3(0, 0, 0) };
            var cubeEffect_l = MakeEffect.FromDiffuseSpecular((float4) ColorUint.Red);
            var cubeMesh_l = new CuboidMesh(new float3(10, 10, 10));

            _cubeTransform_r = new Transform { Scale = new float3(1, 1, 1), Translation = new float3(0, 0, 0) };
            var cubeEffect_r = MakeEffect.FromDiffuseSpecular((float4) ColorUint.Yellow);
            var cubeMesh_r = new CuboidMesh(new float3(10, 10, 10));

            _cubeTransform_k = new Transform { Scale = new float3(1, 1, 1), Translation = new float3(0, 0, 0) };
            var cubeEffect_k = MakeEffect.FromDiffuseSpecular((float4) ColorUint.Green);
            var cubeMesh_k = new CuboidMesh(new float3(1, 1, 1));

            // Assemble the cube node containing the three components
            var cubeNode_foreground = new SceneNode();
            var cubeNode = new SceneNode();
            
            cubeNode_foreground.Components.Add(_cubeTransform_r);
            cubeNode_foreground.Components.Add(cubeEffect_r);
            cubeNode_foreground.Components.Add(cubeMesh_r);

            cubeNode.Components.Add(_cubeTransform_k);
            cubeNode.Components.Add(cubeEffect_k);
            cubeNode.Components.Add(cubeMesh_k);

            cubeNode.Components.Add(_cubeTransform_l);
            cubeNode.Components.Add(cubeEffect_l);
            cubeNode.Components.Add(cubeMesh_l);

            cubeNode.Components.Add(_cubeTransform);
            cubeNode.Components.Add(cubeEffect);
            cubeNode.Components.Add(cubeMesh);


        // THE SCENE
            // Create the scene containing the cube as the only object
            _scene = new SceneContainer();
            _scene.Children.Add(cameraNode);
            _scene.Children.Add(cubeNode_foreground);
            _scene.Children.Add(cubeNode);

            // Create a scene renderer holding the scene above
            _sceneRenderer = new SceneRendererForward(_scene);
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            //Animate the camera angle
            _cubeAngle = _cubeAngle + 90.0f * M.Pi/180.0f * DeltaTime;

            //Animate the cube
            _cubeTransform_r.Translation = new float3(0, M.Cos(6 * TimeSinceStart), 0);
            _cubeTransform_r.Rotation = new float3(_cubeAngle * 2 * M.Pi, _cubeAngle * TimeSinceStart - 230.0f, _cubeAngle);

            _cubeTransform_k.Translation = new float3(0, 0, 20);
            _cubeTransform_k.Rotation = new float3(0, 0,  _cubeAngle * TimeSinceStart - 460.0f);

            _cubeTransform_l.Translation = new float3(0, -23 , 0);
            _cubeTransform_l.Rotation = new float3(0,  _cubeAngle, 0);

            _cubeTransform.Translation = new float3(0, 46, 0);
            _cubeTransform.Rotation = new float3( _cubeAngle, 0, 0);

            // Render the scene tree
            _sceneRenderer.Render(RC);

            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered frame) on the front buffer.
            Present();
        }

    }
}