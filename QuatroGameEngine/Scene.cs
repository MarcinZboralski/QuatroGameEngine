using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuatroGameEngine.Component;
using QuatroGameEngine.Component.Model;

namespace QuatroGameEngine
{
    [System.Serializable]
    public class Scene
    {
        private List<GameComponent> Components = new List<GameComponent>();

        public Scene()
        {
            Components = new List<GameComponent>();
        }

        public void ResetScene()
        {
            Components = new List<GameComponent>();
        }

        public void AddToScene(GameComponent component)
        {
            Components.Add(component);
        }

        public void RenderScene()
        {
            foreach (var con in Components)
            {
               Figure f = (Figure) con;
                f.RenderFigure();
            }
        }
    }
}
