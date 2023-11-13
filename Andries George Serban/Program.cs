using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;
// Proiect realizat de Andries George Serban 3132A

/**
    Aplicația utilizează biblioteca OpenTK v2.0.0 (stable) oficială și OpenTK. GLControl v2.0.0
    (unstable) neoficială. Aplicația fiind scrisă în modul consolă nu va utiliza controlul WinForms
    oferit de OpenTK!
    Tipul de ferestră utilizat: GAMEWINDOW. Se demmonstrează modul imediat de randare (vezi comentariu!)...
**/
namespace OpenTK_console_sample01 {
    class SimpleWindow : GameWindow {
        private float xPosition = 0; // lab 2 ex 2
        private Vector2[] objectPosition = new Vector2[3];
        private float rotationAngle = 0.0f;


        // Constructor.
        public SimpleWindow() : base(800, 600) {
            KeyDown += Keyboard_KeyDown;
            MouseMove += Mouse_Move;// lab 2 ex 2
        }

        void Mouse_Move(object sender, MouseMoveEventArgs e)// lab2 ex 2
        {
            xPosition = (float)e.X / Width * 2 - 1 ;
        }

        // Tratează evenimentul generat de apăsarea unei taste. Mecanismul standard oferit de .NET
        // este cel utilizat.
        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e) {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
        }

        // Setare mediu OpenGL și încarcarea resurselor (dacă e necesar) - de exemplu culoarea de
        // fundal a ferestrei 3D.
        // Atenție! Acest cod se execută înainte de desenarea efectivă a scenei 3D.v
        protected override void OnLoad(EventArgs e) {
            GL.ClearColor(Color.MidnightBlue);
            //string filePath = Path.Combine("Data", "TextFile1.txt");
            string filePath = "TextFile1.txt";

            // lab 3 incarcare date din fisier
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);
                        string[] date = line.Split(' ');
                        objectPosition[i++] = new Vector2(float.Parse(date[0]), float.Parse(date[1]));
                    }
                }
            }// lab 3 incarcare date din fisier

        }

        // Inițierea afișării și setarea viewport-ului grafic. Metoda este invocată la redimensionarea
        // ferestrei. Va fi invocată o dată și imediat după metoda ONLOAD!
        // Viewport-ul va fi dimensionat conform mărimii ferestrei active (cele 2 obiecte pot avea și mărimi 
        // diferite). 
        protected override void OnResize(EventArgs e) {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        // Secțiunea pentru "game logic"/"business logic". Tot ce se execută în această secțiune va fi randat
        // automat pe ecran în pasul următor - control utilizator, actualizarea poziției obiectelor, etc.
        protected override void OnUpdateFrame(FrameEventArgs e) {
            MouseState mouse = Mouse.GetState();
            rotationAngle = (mouse.X - Width / 2) / (float)Width;

            if (Keyboard.GetState().IsKeyDown(Key.A))// lab2 ex 2
            {
                xPosition -= 0.1f;
            }
            if (Keyboard.GetState().IsKeyDown(Key.D))// lab2 ex 2
            {
                xPosition += 0.1f;
            }
        }

        // Secțiunea pentru randarea scenei 3D. Controlată de modulul logic din metoda ONUPDATEFRAME.
        // Parametrul de intrare "e" conține informatii de timing pentru randare.
        protected override void OnRenderFrame(FrameEventArgs e) {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Modul imediat! Suportat până la OpenGL 3.5 (este ineficient din cauza multiplelor apeluri de
            // funcții).
            GL.Rotate(rotationAngle * 360.0f, 0, 0, 1);
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f + xPosition, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f + xPosition, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f + xPosition, 1.0f);

            GL.Color3(Color.DarkRed);
            GL.Vertex2(objectPosition[0]);
            GL.Vertex2(objectPosition[1]);
            GL.Vertex2(objectPosition[2]);

            GL.End();
            // Sfârșitul modului imediat!

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args) {

            // Utilizarea cuvântului-cheie "using" va permite dealocarea memoriei o dată ce obiectul nu mai este
            // în uz (vezi metoda "Dispose()").
            // Metoda "Run()" specifică cerința noastră de a avea 30 de evenimente de tip UpdateFrame per secundă
            // și un număr nelimitat de evenimente de tip randare 3D per secundă (maximul suportat de subsistemul
            // grafic). Asta nu înseamnă că vor primi garantat respectivele valori!!!
            // Ideal ar fi ca după fiecare UpdateFrame să avem si un RenderFrame astfel încât toate obiectele generate
            // în scena 3D să fie actualizate fără pierderi (desincronizări între logica aplicației și imaginea randată
            // în final pe ecran).
            using (SimpleWindow example = new SimpleWindow()) {

                // Verificați semnătura funcției în documentația inline oferită de IntelliSense!
                example.Run(30.0, 0.0);
            }
        }
    }
}
