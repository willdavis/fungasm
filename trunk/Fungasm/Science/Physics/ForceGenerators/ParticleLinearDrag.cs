using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    public class ParticleLinearDrag : IParticleForceGenerator
    {
        // constant that depends on the properties of the fluid and the dimensions of the object
        // 0.01 seems to be a good number to start with
        double _dragCoeff;

        public ParticleLinearDrag(double dragCoeff) 
        {
            _dragCoeff = dragCoeff;
        }

        #region IParticleForceGenerator Members

        public void UpdateForce(Particle particle, double deltaTime)
        {
            // Very low Reynolds numbers — Stokes' drag
            // Drag force = -(dragCoeff * Velocity)
            Vector force;
            force = particle.Velocity.Invert() * _dragCoeff;

            particle.AddForce(force);
        }

        #endregion
    }
}
