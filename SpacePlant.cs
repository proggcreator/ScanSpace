using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Разработка програмного приложения ScanSpace
//Студент: Шибитов Давид
//Группа: А-08-17
namespace Lab10_11
{
    public partial class ScanSpace : Form
    {
        public ScanSpace()
        {
            InitializeComponent();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {  //прозрачность элементов
            this.Text = "SpacePlant";
            label6.Parent = pictureBox2; 
            label1.Parent = pictureBox2;
            label2.Parent = pictureBox2;
            label3.Parent = pictureBox2;
            label4.Parent = pictureBox2;
            label5.Parent = pictureBox2;
            label7.Parent = pictureBox2;
            label8.Parent = pictureBox2;
            label9.Parent = pictureBox2;
            label10.Parent = pictureBox2;
            button1.Parent = pictureBox2;
            button2.Parent = pictureBox2;
            button3.Parent = pictureBox2;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

          
            if (textBox3.Text != "") { rad = Convert.ToDouble(textBox3.Text) + trackBar3.Value; }
            else { rad =  trackBar3.Value; }
            if ((rad < 0)||(rad==0) ) {
                MessageBox.Show("Введите корректный радиус"); }
            else {
                Space_obj obj = new Space_obj();
                obj.PhisPar(rad);
            }
           
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

       

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            
            
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
        double rad; 
        int temp, grow;
        int pl;
        bool flag;   
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";      
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private string  IDObj () { // генерация Id планеты
            string id ="";
            Random r = new Random();
            id +=Convert.ToChar(r.Next(97, 122)) +r.Next(-100, 100).ToString() +
                r.Next(-100, 100).ToString() + Convert.ToChar(r.Next(97, 122)) +
                r.Next(-100, 100).ToString() ;
            return id;
        }


        private string Long ()
        { // генерация Id планеты
            string rs = "";
            Random s = new Random();
            rs +=   s.Next(1, 5000000).ToString() ;
            return rs;
        }
        


        private void PropertObj(string nam, string descr)
        {
            textBox5.Text = "Тип обьекта: " + nam + "\r\n";
            textBox5.Text += "Кодовое имя: ";
            Random r = new Random();
            textBox5.Text += "\r\n" + IDObj()+ "\r\n\r\n";
            textBox5.Text += descr + "\r\n";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
             char number = e.KeyChar;
            if ((!Char.IsDigit(number)) && (number != 8)&&(number != 45)) //ввод только  backspace numbers
            { 
                e.Handled = true;
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void BasicParam( int yer,double mass, int t ) {           
           
            textBox6.Text =  + mass + " * 10^30 кг ";
            textBox7.Text = Long()+ " *10^12 км";
            textBox8.Text =  + t + " K"; 
        }
        private void BasicParam(int yer, double mass) //для черных дыр(нет t)
        {
          
            textBox6.Text = +mass + " * 10^30 кг ";
            textBox7.Text = Long() + " *10^12 км";
            textBox8.Text = " Неизвестна ";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((!Char.IsDigit(number)) && (number != 8)) //ввод только  backspace numbers
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                flag = false;

                if (textBox1.Text == "") { pl = trackBar1.Value; }
                else { pl = Convert.ToInt32(textBox1.Text) + trackBar1.Value; }

                if (textBox2.Text == "") { temp = trackBar2.Value; }
                else { temp = Convert.ToInt32(textBox2.Text) + trackBar2.Value; }
                if (textBox3.Text == "") { rad = trackBar3.Value; }
                else { rad = Convert.ToDouble(textBox3.Text) + trackBar3.Value; }
                if (textBox4.Text == "") { grow = trackBar4.Value; }
                else { grow = Convert.ToInt32(textBox4.Text) + trackBar4.Value; }

                if ((pl >= 500) && (temp == 0) && (rad > 0) )
                {
                    Black_hole blhole = new Black_hole();
                    PropertObj(blhole.Name(), blhole.DescrHole());
                    blhole.Year = grow; //используем свойство, срабатывает блок Set
                    BasicParam(blhole.Year, blhole.GetMass(ref pl, rad));

                    pictureBox3.Image = Properties.Resources.blhole;
                    flag = true;
                }
                if ((pl > 0) && ((temp >= -40) && (temp <= 70)) && (rad > 0) && (flag == false) )
                {
                    LifPlant plant = new LifPlant();
                    plant.Year = grow;
                    PropertObj(plant.Name(), plant.DescrPlant());
                    textBox5.Text += plant.InfPlL() + "\r\n";
                    BasicParam(plant.Year, plant.GetMass(ref pl, rad), plant.GetTemp(temp));
                    pictureBox3.Image = Properties.Resources.eath2;
                    flag = true;
                }
                if (((pl < 500) && ((temp < -40) || ((temp > 70)&&((temp < 1500)))) && (rad > 0)) && (flag == false) )
                {
                    DiePlant plant = new DiePlant();
                    plant.Year = grow;
                    PropertObj(plant.Name(), plant.DescrPlant());
                    textBox5.Text += plant.INfPlD() + "\r\n";
                    BasicParam(plant.Year, plant.GetMass(ref pl, rad), plant.GetTemp(temp));
                    pictureBox3.Image = Properties.Resources.yup;
                    flag = true;
                }
                if ((pl > 0) && (temp >= 1500) && (rad > 0) && (flag == false))
                {
                    Star star = new Star();
                    star.Year = grow;
                    PropertObj(star.Name(), star.DescrStar());
                    BasicParam(star.Year, star.GetMass(ref pl, rad), star.GetTemp(temp));
                    pictureBox3.Image = Properties.Resources.sun;
                    flag = true;
                }
                if (flag == false)
                {

                    if (rad < 0) { MessageBox.Show("Введите корректный радиус"); }
                    textBox5.Text = "Данные о текущем обьекте отсутствуют";
                    pictureBox3.Image = Properties.Resources.find1;
                    
                }
            }
            catch (MyException ex)
            {
                MessageBox.Show($"Неккоректное значение: {ex.Message}");
                MessageBox.Show($"Некорректное значение: {ex.Value}");
                button3_Click(sender, e);
            }
            catch(FormatException)    //исключение преобразования типов
            {
                pictureBox3.Image = Properties.Resources.find1;
                MessageBox.Show("Неккоректное значение!"); 
                button3_Click(sender, e);

            }
        }
    }
}
