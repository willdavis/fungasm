using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Fungasm.Core;
using Fungasm.Graphics;

using Tao.OpenGl;
using Tao.DevIl;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MouseInput _input = new MouseInput();

        public MainWindow()
        {
            InitializeComponent();

            TextureManager _textureManager = new TextureManager();
            if (!ErrorManager.Instance.Init())
                Console.WriteLine("Unable to initialise Error Log files.");
            
            VideoTask video = new VideoTask();
            InputTask task = new InputTask();
            video.Init(openGLControl);
            task.Init(this, _input, openGLControl);

            Setup2DGraphics(this.ActualWidth, this.ActualHeight);

            KernelS.Instance.AddTask(video);
            KernelS.Instance.AddTask(task);
            Renderer _renderer = new Renderer();

            // Init DevIl
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            _textureManager.LoadTexture("testTexture", "dilbert-02.jpg");
            _textureManager.LoadTexture("GayRoss", "testTextureZOMG.tif");
            _textureManager.LoadTexture("fontTest", "Fonts/test_0.tga");
            _textureManager.LoadTexture("TimesFont", "Fonts/timesFont_0.tga");

            StateManager.Instance.AddState("SplashScreen", new SplashScreenState(StateManager.Instance, _textureManager, _renderer));
            StateManager.Instance.AddState("SpriteTest", new DrawSpriteState(_textureManager, _renderer));

            StateManager.Instance.ChangeState("SplashScreen");

            KernelS.Instance.AddTask(StateManager.Instance);
            KernelS.Instance.Execute();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Gl.glViewport(0, 0, (int)this.ActualWidth, (int)this.ActualHeight);
            Setup2DGraphics(this.ActualWidth, this.ActualHeight);
        }
        private void Setup2DGraphics(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StateManager.Instance.AddState("CircleTest", new IntersectionTestState(_input, openGLControl));
            StateManager.Instance.ChangeState("CircleTest");
            e.Handled = true;
        }
    }
}
