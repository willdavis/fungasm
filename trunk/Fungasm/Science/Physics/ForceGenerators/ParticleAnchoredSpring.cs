using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    public class ParticleAnchoredSpring : IParticleForceGenerator
    {
        Vector _anchorPoint;
        double _springConstant;
        double _restLength;
        double _dampening;

        public ParticleAnchoredSpring(Vector anchorPoint, double springConst, double restLength, double dampening)
        {
            _anchorPoint = anchorPoint;
            _springConstant = springConst;
            _restLength = restLength;
            _dampening = dampening;
        }

        #region IParticleForceGenerator Members

        public void UpdateForce(Particle particle, double deltaTime)
        {
            Vector force;
            force = particle.Position;
            force -= _anchorPoint;

            double magnitude = force.Length();
            magnitude = Math.Abs(magnitude - _restLength);
            magnitude *= _springConstant;

            force.Normalize();
            force *= -magnitude;
            force *= _dampening;
            particle.AddForce(force);
        }

        #endregion
    }
}
