using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using QuatroGameEngine.Component.Model;
using QuatroGameEngine.Input;

namespace QuatroGameEngine
{
    public class GameEngineWindow
    {
        private Vector3 currPos = new Vector3(0,0,0);
        private float root = 0f;
        private float root1 = 0f;

        public Scene CurentScene;
        public static GameWindow Window;
        public GameEngineWindow(GameWindow window)
        {
            Window = window;
            Start();
        }

        void Start()
        {
            Window.Load += Loaded;
            Window.Resize += Resize;
            Window.RenderFrame += Render;
            Window.Run(1.0f/60f);
            InitScene();
           
        }

        private void InitScene()
        {
            CurentScene = new Scene();

            CurentScene.ResetScene();

            CurentScene.AddToScene(new Plane(new Vector3(0, 0, 0), Color.Gold));

            CurentScene.AddToScene(new Cube(new Vector3(-20, 0, 0), Color.Blue));
            CurentScene.AddToScene(new Cube(new Vector3(20, 0, 0), Color.Red));
            CurentScene.AddToScene(new Cube(new Vector3(20, 0, 20), Color.Green));

            CurentScene.AddToScene(new Cube(new Vector3(-20, 0, 20), Color.FromArgb(55, 234, 65)));
            CurentScene.AddToScene(new Cube(new Vector3(20, 0, -20), Color.FromArgb(128, 77, 0)));
            CurentScene.AddToScene(new Cube(new Vector3(-20, 0, -20), Color.FromArgb(0, 255, 209)));

        }

        private void Resize(object sender, EventArgs e)
        {
          //  double size = MathHelper.DegreesToRadians(1 / 2.0);
            GL.Viewport(0,0,Window.Width,Window.Height);
          //  GL.Frustum(-size, size, -size / (Window.Width / Window.Height), size / (Window.Width / Window.Height),1f,10000f);
            Matrix4 m = Matrix4.CreateFromAxisAngle(currPos,root);
            Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView(1, Window.Width / Window.Height, 1f, 10000f);
            matrix.ExtractRotation(true);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();         
            GL.MultMatrix(ref matrix);
            GL.LoadMatrix(ref matrix);
            //GL.Ortho(-50,50,-50,50,-1,1);
            GL.MatrixMode(MatrixMode.Modelview0Ext);

        }

        private void Render(object sender, FrameEventArgs e)
        {
            if (CurentScene == null)
            {
                InitScene();
            }

            Vector3 camPos = new Vector3();
            float camRoot = 0f;
            float camRoot1 = 0f;

            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            #region Input

         
            if (InputSystem.GetKeyDown(Key.W))
            {
                camPos = new Vector3(0, 0, 1);
            }

            if (InputSystem.GetKeyDown(Key.S))
            {
                camPos = new Vector3(0, 0, -1);
            }

            if (InputSystem.GetKeyDown(Key.A))
            {
                camPos = new Vector3(1, 0, 0);
            }

            if (InputSystem.GetKeyDown(Key.D))
            {
                camPos = new Vector3(-1, 0, 0);
            }

            if (InputSystem.GetKeyDown(Key.Q))
            {
                camPos = new Vector3(0, 1, 0);
            }

            if (InputSystem.GetKeyDown(Key.E))
            {
                camPos = new Vector3(0, -1, 0);
            }

            if (InputSystem.GetKeyDown(Key.Up))
            {
                camRoot = 1f;
            }

            if (InputSystem.GetKeyDown(Key.Down))
            {
                camRoot = -1f;
            }

            if (InputSystem.GetKeyDown(Key.Right))
            {
                camRoot1 = 1f;
            }

            if (InputSystem.GetKeyDown(Key.Left))
            {
                camRoot1 = -1f;
            }

            #endregion

            GL.PushMatrix();
            GL.PopMatrix();
            GL.Translate(currPos += camPos);
            GL.Rotate(root += camRoot, 1, 0, 0);
            GL.Rotate(root1 += camRoot1, 0, 1, 0);
           // new Cube(new Vector3(-20, -20, 0), Color.Blue);
            CurentScene.RenderScene();

            Window.SwapBuffers();
            Console.Title = Window.RenderFrequency.ToString();

        }



        private void Loaded(object obj, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(204, 217, 210));
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
