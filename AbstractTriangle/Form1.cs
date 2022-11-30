using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractTriangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            Triangle triangle = SetTriangleType();
            
            if (triangle == null)
            {
                MessageBox.Show("Ошибка при создании класса треугольника. Повторите попытку!");
                return;
            }

            // Устанавливаем начальные значения
            try
            {
                SetStartValues(triangle);
            }
            catch(Exception)
            {
                MessageBox.Show("Проверьте формат введенных данных!");
                return;
            }

            SetResultValues(triangle);
        }

        private void SetStartValues(Triangle triangle)
        {
            double a, b, c;

            if (double.TryParse(input_aSide.Text, out a) &&
                double.TryParse(input_bSide.Text, out b) &&
                double.TryParse(input_cSide.Text, out c))
            {
                triangle.SideA = a;
                triangle.SideB = b;
                triangle.SideC = c;
                return;
            }

            throw new Exception("Ошибка формата введеных данных");
        }
        private void SetResultValues(Triangle triangle)
        {
            double perimetr = triangle.Perimeter();
            double area = triangle.Area();

            label_perimetrResult.Text = triangle.Perimeter().ToString();
            label_areaResult.Text = triangle.Area().ToString();

            input_angle.Text = triangle.Angle.ToString();

            input_aSide.Text = triangle.SideA.ToString();
            input_bSide.Text = triangle.SideB.ToString();
            input_cSide.Text = triangle.SideC.ToString();
        }

        private Triangle SetTriangleType()
        {
            // Определяем треугольник по типу базового класса
            Triangle triangle = null;

            // Смотрим что за тип и реализуем его в виде этого типа (наследника)
            if (comboBox_triangleType.Text.ToLower() == "прямоугольный")
            {
                triangle = new RectangularTriangle();
            }

            if (comboBox_triangleType.Text.ToLower() == "равнобедренный")
            {
                triangle = new IsoscelesTriangle();
            }

            if (comboBox_triangleType.Text.ToLower() == "равносторонний")
            {
                triangle = new EquilateralTriangle();
            }

            return triangle;
        }
    }
}
