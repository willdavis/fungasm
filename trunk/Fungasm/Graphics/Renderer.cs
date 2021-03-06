﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fungasm.Science;

using Tao.OpenGl;

namespace Fungasm.Graphics
{
    public class Renderer
    {
        Batch _batch = new Batch();
        int _currentTextureId = -1;

        public Renderer()
        {
            try
            {
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glEnable(Gl.GL_BLEND);
                Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Renderer failed\n{0}\n{1}", e.Message, e.StackTrace));
            }
        }

        public void DrawSprite(Sprite sprite)
        {
            if (sprite.Texture.Id == _currentTextureId)
            {
                _batch.AddSprite(sprite);
            }
            else
            {
                _batch.Draw(); // Draw all with current texture
                // Update texture info
                _currentTextureId = sprite.Texture.Id;
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, _currentTextureId);
                _batch.AddSprite(sprite);
            }
        }

        public void DrawText(Text text)
        {
            foreach (CharacterSprite c in text.CharacterSprites)
            {
                DrawSprite(c.Sprite);
            }
        }

        public void Render()
        {
            _batch.Draw();
        }
    }
}
