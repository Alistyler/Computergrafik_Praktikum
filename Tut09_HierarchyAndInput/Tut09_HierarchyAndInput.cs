using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Engine.Core.Scene;
using Fusee.Math.Core;
using Fusee.Engine.Core.Effects;
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
    [FuseeApplication(Name = "Tut09_HierarchyAndInput", Description = "Yet another FUSEE App.")]
    public class Tut09_HierarchyAndInput : RenderCanvas
    {
        private SceneContainer _scene;
        private SceneRendererForward _sceneRenderer;
        private Transform _baseTransform;
        private Transform _bodyTransform;
        private Transform _upperArmTransform;
        private Transform _foreArmTransform;
        private Transform _camAngle;
        private Transform _centre;
        private Transform _finger01;
        private Transform _finger02;
        private Transform _finger03;

        SceneContainer CreateScene()
        {
            // Initialize transform components that need to be changed inside "RenderAFrame"
            _camAngle = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 0, 0)
            };

            _baseTransform = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 0, 0)
            };

            _bodyTransform = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 6, 0)
            };

            _upperArmTransform = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(2, 4, 0)
            };

            _foreArmTransform = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(-2, 4, 0)
            };

            _centre = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 2.5f, 0)
            };

            _finger01 = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 1, -2.5f)
            };

            _finger02 = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(-0.45f, -2, -5)
            };

            _finger03 = new Transform
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0.95f, 0, 2.5f)
            };

            // Setup the scene graph
            return new SceneContainer
            {
                Children =
                {
                    new SceneNode
                    {
                        Name = "Camera",
                        Components =
                        {
                            _camAngle,
                            new Transform
                            {
                                Translation = new float3(0, 10, -50),
                            },
                            new Camera(ProjectionMethod.Perspective, 5, 100, M.PiOver4)
                            {
                                BackgroundColor =  (float4) ColorUint.Greenery,
                            }
                        }
                    },

                    new SceneNode
                    {
                        Name = "Base (grey)",
                        Components =
                        {
                            // TRANSFORM COMPONENT
                            _baseTransform,

                            // SHADER EFFECT COMPONENT
                            MakeEffect.FromDiffuseSpecular((float4) ColorUint.LightGrey),

                            // MESH COMPONENT
                            new CuboidMesh(new float3(10, 2, 10))
                        },
                        Children = 
                        {
                            new SceneNode
                            {
                                Name = "Base (red)",
                                Components =
                                {
                                    _bodyTransform,
                                    MakeEffect.FromDiffuseSpecular((float4) ColorUint.Red),
                                    new CuboidMesh(new float3(2, 10, 2))
                                },
                                Children =
                                {
                                    new SceneNode
                                    {
                                        Name = "Upperarm (green)",
                                        Components =
                                        {
                                            _upperArmTransform,
                                        },
                                        Children =
                                        {
                                            new SceneNode
                                            {
                                                Components=
                                                {
                                                new Transform{ Translation = new float3(0, 4, 0)},
                                                MakeEffect.FromDiffuseSpecular((float4) ColorUint.Green),
                                                new CuboidMesh(new float3 (2, 10, 2))
                                                },
                                                Children =
                                                {
                                                    new SceneNode
                                                    {
                                                        Name = "Forearm (blue)",
                                                        Components =
                                                        {
                                                            _foreArmTransform,
                                                        },
                                                        Children =
                                                        {
                                                            new SceneNode
                                                            {
                                                                Components =
                                                                {
                                                                new Transform{ Translation = new float3(0, 4, 0)},
                                                                MakeEffect.FromDiffuseSpecular((float4) ColorUint.Blue),
                                                                new CuboidMesh(new float3 (2, 10, 2))
                                                                },
                                                                Children = 
                                                                {
                                                                    new SceneNode
                                                                    {
                                                                        Name = "centre",
                                                                        Components =
                                                                        {
                                                                            _centre,
                                                                        },
                                                                        Children =
                                                                        {
                                                                            new SceneNode
                                                                            {
                                                                                Components =
                                                                                {
                                                                                    new Transform{ Translation = new float3(0, 0, 0)},
                                                                                    MakeEffect.FromDiffuseSpecular((float4) ColorUint.Greenery),
                                                                                    new CuboidMesh(new float3 (1, 1, 1))
                                                                                },
                                                                                Children =
                                                                                {
                                                                                    new SceneNode
                                                                                    {
                                                                                        Name = "Finger 01",
                                                                                        Components =
                                                                                        {
                                                                                            _finger01,
                                                                                        },
                                                                                        Children =
                                                                                        {
                                                                                            new SceneNode
                                                                                            {
                                                                                                Components =
                                                                                                {
                                                                                                    new Transform{ Translation = new float3(0, 0, 5)},
                                                                                                    MakeEffect.FromDiffuseSpecular((float4) ColorUint.Yellow),
                                                                                                    new CuboidMesh(new float3 (0.5f, 0.5f, 5))
                                                                                                },
                                                                                                Children =
                                                                                                {
                                                                                                    new SceneNode 
                                                                                                    {
                                                                                                        Name = "Finger 02",
                                                                                                        Components =
                                                                                                        {
                                                                                                            _finger02,
                                                                                                        },
                                                                                                        Children =
                                                                                                        {
                                                                                                            new SceneNode 
                                                                                                            {
                                                                                                                Components =
                                                                                                                {
                                                                                                                    new Transform{ Translation = new float3(0, 0, 5)},
                                                                                                                    MakeEffect.FromDiffuseSpecular((float4) ColorUint.Yellow),
                                                                                                                    new CuboidMesh(new float3 (0.5f, 0.5f, 5))
                                                                                                                },
                                                                                                                Children =
                                                                                                                {
                                                                                                                    new SceneNode
                                                                                                                    {
                                                                                                                        Name = "Finger 03",
                                                                                                                        Components = 
                                                                                                                        {
                                                                                                                        _finger03,
                                                                                                                        },
                                                                                                                        Children =
                                                                                                                        {
                                                                                                                            new SceneNode
                                                                                                                            {
                                                                                                                                Components =
                                                                                                                                {
                                                                                                                                    new Transform{ Translation = new float3(0, 0, -2.5f)},
                                                                                                                                    MakeEffect.FromDiffuseSpecular((float4) ColorUint.Yellow),
                                                                                                                                    new CuboidMesh(new float3 (0.5f, 0.5f, 5))
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }  
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }


        // Init is called on startup. 
        public override void Init()
        {
            // Set the clear color for the backbuffer to white (100% intensity in all color channels R, G, B, A).
            RC.ClearColor = new float4(0.8f, 0.9f, 0.7f, 1);

            _scene = CreateScene();

            // Create a scene renderer holding the scene above
            _sceneRenderer = new SceneRendererForward(_scene);
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            float _bodyRot = _bodyTransform.Rotation.y;
            _bodyRot += 0.1f * Keyboard.LeftRightAxis;
            _bodyTransform.Rotation = new float3(0, _bodyRot, 0);

            _bodyTransform.Rotation = new float3(0, _bodyRot + 45.0f * (M.Pi / 180.0f) * Time.DeltaTime * Keyboard.LeftRightAxis, 0);
            _upperArmTransform.Rotation = new float3(_upperArmTransform.Rotation.x + 45.0f * (M.Pi / 180.0f) * Time.DeltaTime * Keyboard.UpDownAxis, 0, 0);
            _foreArmTransform.Rotation = new float3(_foreArmTransform.Rotation.x + 45.0f * (M.Pi / 180.0f) * Time.DeltaTime * Keyboard.WSAxis, 0, 0);

            if(Mouse.LeftButton == true)
            {
                _camAngle.Rotation = new float3(0, _camAngle.Rotation.y + 45.0f * (M.Pi / 180.0f) * Time.DeltaTime * Mouse.Velocity.x, 0);
            }

            _finger01.Rotation = new float3(_finger01.Rotation.x - 45.0f * (M.Pi / 180.0f) * Time.DeltaTime * Keyboard.ADAxis, 0, 0);
            _finger02.Rotation = new float3(_finger02.Rotation.x + 45.0f * (M.Pi / 180.0f) * Time.DeltaTime * Keyboard.ADAxis, 0, 0);
            _finger03.Rotation = new float3(_finger03.Rotation.x + 45.0f * (M.Pi / 180.0f) * Time.DeltaTime * Keyboard.ADAxis, 0, 0);

            //Diagnostics.Debug(Mouse.Velocity.x);

            // Render the scene on the current render context
            _sceneRenderer.Render(RC);

            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered frame) on the front buffer.
            Present();
        }
    }
}