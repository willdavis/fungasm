using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;
using Fungasm.Science;
using Fungasm.Science.Physics;
using Fungasm.Graphics;

using Tao.Platform.Windows;

namespace Fungasm.Core
{
    public class IntersectionTestState : IRenderable
    {
        ParticleGravity _gravity = new ParticleGravity(new Vector(0,-10,0));
        ParticleLinearDrag _linearDrag = new ParticleLinearDrag(0.005);
        ParticleAnchoredSpring _anchoredSpring = new ParticleAnchoredSpring(new Vector(250,0,0), 0.005, 2.0, 0.5);
        ParticleForceRegistry _forceRegistry = new ParticleForceRegistry();

        ParticleContactResolver _resolver = new ParticleContactResolver(1);
        List<Particle> _particleGenerator = new List<Particle>();
        List<ParticleContact> _contactsThisFrame = new List<ParticleContact>();

        Circle _circle = new Circle(Vector.Zero, 100);
        Rectangle _rectangle = new Rectangle(new Vector(-200, -100, 0), new Vector(200, -50, 0));
        MouseInput _input;
        SimpleOpenGlControl _openGLCtrl;

        public IntersectionTestState(MouseInput input, SimpleOpenGlControl openGLctrl)
        {
            Gl.glLineWidth(3);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            _input = input;
            _openGLCtrl = openGLctrl;

            Particle particle1 = new Particle(new Vector(250, 0, 0), Vector.Zero) { Mass = 0 };
            ParticleBungee newSpring = new ParticleBungee(particle1, 1.0f, 5.0);
            _particleGenerator.Add(particle1);
            _forceRegistry.Add(particle1, _gravity);
            for (int i = 0; i < 1000; i++)
            {
                Particle particle2 = new Particle(new Vector(0, 0, 0), new Vector(i*2, i*2, 0)) { Mass = 20 };
                
                _particleGenerator.Add(particle2);
                _forceRegistry.Add(particle2, _linearDrag);
                _forceRegistry.Add(particle2, _gravity);
                //_forceRegistry.Add(particle2, newSpring);
            }
        }

        #region IGameObject Members

        public void Update(double deltaTime)
        {
            _forceRegistry.UpdateForces(deltaTime);

            foreach (Particle particle in _particleGenerator)
            {
                System.Windows.Point currentPos = new System.Windows.Point(particle.Position.X, particle.Position.Y);
                if (_rectangle.Intersects(currentPos))
                {
                    particle.Velocity = new Vector(particle.Velocity.X, -particle.Velocity.Y/1.3, 0);
                }

                if (currentPos.Y < -(_openGLCtrl.Height / 2))
                {
                    ParticleContact newcontact = new ParticleContact();
                    newcontact.Particles[0] = particle;
                    newcontact.Particles[1] = null;

                    newcontact.ContactNormal = new Vector(0, 1, 0);
                    newcontact.Penetration = particle.Position.Y + (_openGLCtrl.Height / 2);
                    newcontact.Restitution = 0.7;

                    _contactsThisFrame.Add(newcontact);
                }

                if (currentPos.X < -_openGLCtrl.Width / 2)
                {
                    ParticleContact newcontact = new ParticleContact();
                    newcontact.Particles[0] = particle;
                    newcontact.Particles[1] = null;

                    newcontact.ContactNormal = new Vector(1, 0, 0);
                    newcontact.Penetration = particle.Position.X + (_openGLCtrl.Width / 2);
                    newcontact.Restitution = 0.5;

                    _contactsThisFrame.Add(newcontact);
                }

                if (currentPos.X > _openGLCtrl.Width / 2)
                {
                    ParticleContact newcontact = new ParticleContact();
                    newcontact.Particles[0] = particle;
                    newcontact.Particles[1] = null;

                    newcontact.ContactNormal = new Vector(-1, 0, 0);
                    newcontact.Penetration = (_openGLCtrl.Width / 2) - particle.Position.X;
                    newcontact.Restitution = 0.5;

                    _contactsThisFrame.Add(newcontact);
                }

                particle.Update(deltaTime);

                if (_contactsThisFrame.Count != 0)
                {
                    _resolver.ResolveContacts(_contactsThisFrame, deltaTime);
                    _contactsThisFrame.Clear();
                }
            }

            if (_circle.Intersects(_input.MousePosition))
            {
                _circle.Color = new Color(1, 0, 0, 1);
            }
            else
            {
                // If the circle's not intersected turn it back to white.
                _circle.Color = new Color(1, 1, 1, 1);
            }

            if (_rectangle.Intersects(_input.MousePosition))
                _rectangle.Color = new Color(1, 0, 0, 1);
            else
                _rectangle.Color = new Color(1,1,1,1);
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _circle.Draw();
            _rectangle.Render();
            foreach (Particle particle in _particleGenerator)
                particle.Render();

            // Draw the mouse cursor as a point
            Gl.glPointSize(3);
            Gl.glBegin(Gl.GL_POINTS);
            {
                Gl.glVertex2f((float)_input.MousePosition.X,
                (float)_input.MousePosition.Y);
            }
            Gl.glEnd();

            //Draw a center point for the screen
            Gl.glPointSize(3);
            Gl.glBegin(Gl.GL_POINTS);
            {
                Gl.glVertex2f(0, 0);
            }
            Gl.glEnd();
        }

        #endregion
    }
}
