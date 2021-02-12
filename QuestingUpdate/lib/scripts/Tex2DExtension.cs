using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QuestingUpdate.lib.scripts
{
    static class Tex2DExtension
    {
        public static Texture2D DrawCircle(this Texture2D tex, int x, int y, int r, Color color)
        {
            float rSquared = r * r;

            for (int u = 0; u < tex.width; u++)
            {
                for (int v = 0; v < tex.height; v++)
                {
                    if ((x - u) * (x - u) + (y - v) * (y - v) < rSquared) tex.SetPixel(u, v, color);
                }
            }

            return tex;
        }
    }
}
