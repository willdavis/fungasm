﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Core
{
    public interface IGameObject
    {
        void Update(double deltaTime);
        void Render();
    }
}
