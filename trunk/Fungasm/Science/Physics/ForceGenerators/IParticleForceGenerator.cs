using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    /// <summary>
    /// Provides a basic interface for adding forces to a particle
    /// </summary>
    /// <remarks>
    /// A single force generator can be attached to multiple particles at a time
    /// </remarks>
    public interface IParticleForceGenerator
    {
        void UpdateForce(Particle particle, double deltaTime);
    }
}
