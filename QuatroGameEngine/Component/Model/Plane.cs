using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace QuatroGameEngine.Component.Model
{
    public class Plane : Figure
    {
        public Plane(Vector3 pos, Color color)
        {
            VertexsList = new List<Vector3>();

            VertexsList.Add(new Vector3(10.0f, -10.0f, 10.0f));
            VertexsList.Add(new Vector3(10.0f, -10.0f, -10.0f));
            VertexsList.Add(new Vector3(-10.0f, -10.0f, -10.0f));
            VertexsList.Add(new Vector3(-10.0f, -10.0f, 10.0f));


            base.color = color;
            base.pos = pos;

            RenderFigure();
        }

        public override void RenderFigure()
        {
            GL.Begin(PrimitiveType.Quads);
            foreach (var vector3 in VertexsList)
            {
                Vector3 positioned = vector3 + pos;
                GL.Color3(color);
                GL.Vertex3(positioned);
            }
            GL.End();
        }
    }
}
