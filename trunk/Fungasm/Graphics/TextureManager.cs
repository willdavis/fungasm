using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;
using Tao.DevIl;

namespace Fungasm.Graphics
{
    public class TextureManager : IDisposable
    {
        Dictionary<String, Texture> _textureDatabase = new Dictionary<string, Texture>();

        public Texture Get(String name)
        {
            if (!_textureDatabase.ContainsKey(name))
                throw new KeyNotFoundException();

            return _textureDatabase[name];
        }

        public void LoadTexture(string textureId, string path)
        {
            int devilId = 0;
            Il.ilGenImages(1, out devilId);
            Il.ilBindImage(devilId); // set as the active texture.
            if (!Il.ilLoadImage(path))
            {
                System.Diagnostics.Debug.Assert(false,
                "Could not open file, [" + path + "].");
            }
            // The files we'll be using need to be flipped before passing to OpenGL
            Ilu.iluFlipImage();
            int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int openGLId = Ilut.ilutGLBindTexImage();
            System.Diagnostics.Debug.Assert(openGLId != 0);
            Il.ilDeleteImages(1, ref devilId);

            _textureDatabase.Add(textureId, new Texture(openGLId, width, height));
        }

        #region IDisposable Members

        public void Dispose()
        {
            foreach (Texture t in _textureDatabase.Values)
            {
                Gl.glDeleteTextures(1, new int[] { t.Id });
            }
        }

        #endregion
    }
}
