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
    public class Figure
    {
        public List<Vector3> VertexsList;

        public Figure()
        {
            
        }

        public virtual void RenderFigure(Vector3 pos, Color color)
        {

        }
    }
}
