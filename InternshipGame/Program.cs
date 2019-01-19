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
        double Radius { get; set; } // радиус
        void Move();
    }

    interface ISize // размеры прямоугольных объектов
    {
        double Length { get; set; } // длина
        double Width { get; set; } // ширина
    }

    interface ILocation // локация прямоугольных объектов
    {
        double X1 { get; set; } // левый верхний угол
        double Y1 { get; set; }
        double X2 { get; set; } // правый верхний угол
        double Y2 { get; set; }
        double X3 { get; set; } // левый нижний угол
        double Y3 { get; set; }
        double X4 { get; set; } // правый нижний угол
        double Y4 { get; set; }
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
