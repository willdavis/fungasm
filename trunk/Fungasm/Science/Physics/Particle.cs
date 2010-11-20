using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fungasm.Core;
using Tao.OpenGl;

namespace Fungasm.Science.Physics
{
    public class Particle : IRenderable
    {
        private Vector _position;
        private Vector _velocity;
        private Vector _acceleration;
        private double _inverseMass;
        private double _kineticEnergy;

        public Particle()
        {
            _position = new Vector(Vector.Zero);
            _velocity = new Vector(Vector.Zero);
            _acceleration = new Vector(Vector.Zero);
        }
        public Particle(Vector position, Vector velocity)
        {
            _position = position;
            _velocity = velocity;
            _acceleration = new Vector(Vector.Zero);
        }

        /// <summary>
        /// Gets or Sets the Particle's Mass
        /// </summary>
        /// <remarks>
        /// Mass is stored in it's inverse form (1/m)
        /// Storing the mass in the form (1/m) simplifies calculations by removing the division operator foreach update
        /// as well as prevents zero mass particles and allows for infinite mass particles.
        /// 0 InverseMass = Infinite Mass
        /// Cant set infinite InverseMass, therefore 0 mass partice cannot be attained
        /// </remarks>
        public double Mass
        {
            get { return 1 / _inverseMass; }
            set 
            {
                if (value == 0)
                {
                    _inverseMass = 0;
                    HasFiniteMass = false;
                }
                else
                {
                    _inverseMass = 1 / value;
                    HasFiniteMass = true;
                }
            }
        }
        public double InverseMass { get { return _inverseMass; } }
        public bool HasFiniteMass
        { get; set; }
        public double KineticEnergy
        {
            get { return _kineticEnergy; }
            set { _kineticEnergy = value; }
        }
        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Vector Velocity
        { 
            get { return _velocity; } 
            set { _velocity = value; }
        }
        public Vector Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }
        public Vector NetForce { get; set; }

        public void AddForce(Vector force) { NetForce += force; }

        #region IRenderable Members

        public void Update(double deltaTime)
        {
            // Update linear position
            _position.AddScaledVector(_velocity, deltaTime);
            //_position.AddScaledVector(_acceleration, deltaTime*deltaTime*0.5);

            // Work out the acceleration from the current net force.
            Vector resultingAcc = _acceleration;
            resultingAcc.AddScaledVector(NetForce, _inverseMass);

            //update linear velocity from the acceleration
            _velocity.AddScaledVector(resultingAcc, deltaTime);

            //update Kinetic Energy
            _kineticEnergy = NetForce.DotProduct(_velocity.Scale(deltaTime));

            NetForce.Clear();
        }

        public void Render()
        {
            Gl.glPointSize(3);
            Gl.glBegin(Gl.GL_POINTS);
            {
                Gl.glVertex2f((float)_position.X, (float)_position.Y);
            }
            Gl.glEnd();
        }

        #endregion
    }
}
