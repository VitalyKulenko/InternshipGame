using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipGame
{
    interface IDraw // рисование
    {
        void Draw();
    }

    interface IDisappear // исчезновение
    {
        void Disappear();
    }

    interface IBall // радиус и движение шара
    {
        float X { get; set; } // левый верхний угол
        float Y { get; set; }
        void Move();
    }

    interface ISize // размеры прямоугольных объектов
    {
        float Width { get; set; } // длина
    }

    interface ILocation // локация прямоугольных объектов
    {
        float X { get; set; } // левый верхний угол
        float Y { get; set; }
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
