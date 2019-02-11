using System;
using System.Windows.Forms;

namespace InternshipGame
{
    interface IBall // размер шара
    {
        int X { get; set; } // левый верхний угол
        int Y { get; set; }
    }

    interface ISize // размеры прямоугольных объектов
    {
        int Width { get; set; } // длина
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
