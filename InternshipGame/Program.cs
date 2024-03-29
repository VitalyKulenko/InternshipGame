﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace InternshipGame
{

    interface IWall : ILocation, ISize, IDraw { } // стены

    interface IPlatform : ILocation, ISize, IDraw { } // платформа

    interface IBrick : ILocation, ISize, IDraw { } // кирпичи

    interface IBall : ILocation, IDraw // шар
    {
        int Width { get; } // ширина
        int Height { get; } // длина
        int Angle { get; set; } // угол
        int Speed { get; } // скорость
    }

    interface IDraw // рисование
    {
        void Draw(Graphics graph);
    }

    interface ISize // размеры прямоугольных объектов
    {
        int Width { get; set; } // ширина
        int Height { get; } // длина
    }

    interface ILocation // локация прямоугольных объектов
    {
        int X { get; set; } // левый верхний угол
        int Y { get; set; }
    }

    static class Program
    {
        // Главная точка входа для приложения.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
