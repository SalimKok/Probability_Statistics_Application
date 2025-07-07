using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasitSeri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> list = new List<int>();
        int min;
        int max;
        int adet;
        Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            list.Add(int.Parse(textBox1.Text));
            foreach (var i in list)
            {
                listBox1.Items.Add(i);
            }
            textBox1.Clear();
            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            button10.Visible = false;
            button9.Visible = false;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            /*
            List<int> liste = new List<int>{81, 89, 116, 130, 168, 170, 192, 203, 224, 226, 249, 345, 364, 367, 424,
                456, 464, 544, 548, 557, 586, 592, 601, 623, 643, 801, 831, 842, 854, 921, 940, 1020, 1080, 1100, 1130, 1350, 1520, 1850, 1850, 2030 };

            List<int> liste2 = new List<int>{  520, 660, 740, 800, 840, 930,570,685 ,760, 810 ,850 ,940,595 ,710, 780, 810, 860, 990,610,
                730, 790, 810, 860, 1045,635 ,740 ,790, 840, 890, 1080};

            List<int> liste3 = new List<int> { 145,235,150,210,155,210,170,205,175,200};

            foreach (var item in liste3)
             {
                 listBox1.Items.Add(item);
             }
            */





        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            min = int.Parse(textBox2.Text);
            max = int.Parse(textBox3.Text);
            adet = int.Parse(textBox4.Text);


            for (int i = 0; i < adet; i++)
            {

                int a = rnd.Next(min, max + 1);
                if (adet <= (max - min + 1))
                {
                    if (!listBox2.Items.Contains(a))
                    {
                        listBox2.Items.Add(a);
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                    listBox2.Items.Add(a);
            }

        }
        int frknstablosu()
        {
            listBox2.Items.Clear ();    
            int n, r, k, h, t;

            list.Clear();
            foreach (int item in listBox1.Items)
            {
                list.Add(item);
            }

            n = (list.Count);
            list.Sort();
            foreach (var i in list)
            {
                listBox2.Items.Add(i);
            }
            t = list[0];
            r = (list[n - 1] - t);

            k = (int)(Math.Ceiling(Math.Sqrt(n)));

            h = (int)Math.Ceiling((double)r / k);

            for (int i = 0; i < k; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = t;
                t += h;
            }

            t = list[0];
            for (int i = 0; i < k; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = t + h - 1;
                t += h;
            }

            t = list[0];
            for (int i = 0; i < k; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = t - 0.5;
                t += h;
            }

            t = list[0];
            for (int i = 0; i < k; i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = t + h - 0.5;
                t += h;
            }
            t = list[0];
            int fr = 0, u = 0, frr = 0;

            for (int i = 0; i < k; i++)
            {
                for (int p = 0; p < n; p++)
                {
                    if (list[p] > (t - 0.5 + u) && list[p] < (t + h - 0.5 + u))
                    {
                        fr++;
                    }

                }
                u += h;
                dataGridView1.Rows[i].Cells[4].Value = fr;

                dataGridView1.Rows[i].Cells[6].Value = frr + fr;
                dataGridView1.Rows[i].Cells[8].Value = (double)(frr + fr) / n;
                frr += fr;
                dataGridView1.Rows[i].Cells[7].Value = (double)fr / n;
                fr = 0;

            }

            t = list[0];
            for (int i = 0; i < k; i++)
            {
                dataGridView1.Rows[i].Cells[5].Value = ((double)2 * t + h - 1) / 2;
                t += h;
            }
            return h;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Basit seri")
            {
                listBox2.Items.Clear();
                list.Sort();
                foreach (var i in list)
                {
                    listBox2.Items.Add(i);
                }
            }
            if (comboBox1.Text == "Frekans seri")
            {
                listBox2.Items.Clear();
                Dictionary<int, int> tekrarSayilari = new Dictionary<int, int>();

                foreach (int i in list)
                {
                    if (tekrarSayilari.ContainsKey(i))
                        tekrarSayilari[i]++;
                    else
                        tekrarSayilari[i] = 1;
                }

                foreach (var item in tekrarSayilari)
                {
                    listBox2.Items.Add(item.Key + " --> " + item.Value + " tane");

                }
            }
            if (comboBox1.Text == "Basit rastgele örnek")
            {
                groupBox1.Visible = true;
            }
            if (comboBox1.Text == "Sistematik rastgele örnek")
            {
                groupBox2.Visible = true;
            }

            if (comboBox1.Text == "Frekans tablosu")
            {
                frknstablosu();
            }

            if (comboBox1.Text == "Aritmatik ortalama")
            {
                listBox2.Items.Clear();
                double ort = (double)list.Sum() / list.Count;
                listBox2.Items.Add("aritmatik ort:" + ort.ToString("F2"));
            }

            if (comboBox1.Text == "Medyan")
            {
                double medyan = 0;
                listBox2.Items.Clear();
                list.Sort();
                if (list.Count() % 2 == 1)
                {
                    medyan = list[list.Count / 2];
                    listBox2.Items.Add("medyan:" + medyan.ToString("F2"));
                }
                else
                {
                    double a, b;
                    a = list[(list.Count / 2)];
                    b = list[(list.Count / 2) - 1];
                    medyan= ((a + b) / 2);
                    listBox2.Items.Add("medyan:" +medyan.ToString("F2"));
                }
            }

            if (comboBox1.Text == "Mod")
            {
                listBox2.Items.Clear();
                Dictionary<int, int> tekrarSayilari = new Dictionary<int, int>();

                foreach (int i in list)
                {
                    if (tekrarSayilari.ContainsKey(i))
                        tekrarSayilari[i]++;
                    else
                        tekrarSayilari[i] = 1;
                }
                if (tekrarSayilari.Count > 0)
                {
                    int enCokTekrarEdenSayi = tekrarSayilari.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                    int enCokTekrarSayisi = tekrarSayilari[enCokTekrarEdenSayi];

                    //MessageBox.Show($"En çok tekrar eden sayı: {enCokTekrarEdenSayi}, Tekrar sayısı: {enCokTekrarSayisi}");
                    listBox2.Items.Add("Modu:" + enCokTekrarEdenSayi);
                }
                else
                {
                    MessageBox.Show("Liste boş!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }

            if (comboBox1.Text == "Geometrik ortalama")
            {
                listBox2.Items.Clear();
                double logToplam = 0.0;
                int adet = list.Count;

                foreach (int i in list)
                {
                    logToplam += Math.Log10(i);
                }

                double sonuc = Math.Pow(10, logToplam / adet);
                listBox2.Items.Add("Geometrik ort: " + sonuc.ToString("F2"));
            }

            if (comboBox1.Text == "Harmonik ortalama")
            {
                listBox2.Items.Clear();
                int adet = list.Count;
                decimal toplamTers = 0m;

                foreach (int i in list)
                {
                    if (i == 0)
                    {
                        listBox2.Items.Add("Veri içinde 0 olduğu için harmonik ortalama hesaplanamaz.");
                        return;
                    }
                    toplamTers += 1m / i;
                }

                decimal sonuc = adet / toplamTers;
                // Decimal tipinde yuvarlama için Math.Round yerine decimal.Round kullanılır:
                sonuc = decimal.Round(sonuc, 2);

                listBox2.Items.Add("Harmonik ort: " + sonuc.ToString());
            }
            double varyans = 0;
            if (comboBox1.Text == "Varyans (S^2)")
            {
                listBox2.Items.Clear();
                double ort = (double)list.Sum() / list.Count;
                int adet = list.Count;
                double toplam = 0;
                foreach (int i in list)
                {
                    double q = i - ort; 
                    q = Math.Pow(q, 2);
                    toplam = toplam + q;
                }
                varyans = toplam / (adet - 1);
                listBox2.Items.Add("S^2 = " + varyans.ToString("F2"));
            }

            double stsapma()
            {
                listBox2.Items.Clear();
                double ort = (double)list.Sum() / list.Count;
                int adet = list.Count;
                double toplam = 0;
                foreach (int i in list)
                {
                    double q = i - ort;
                    q = Math.Pow(q, 2);
                    toplam = toplam + q;
                }
                varyans = toplam / (adet - 1);
                double ST = Math.Sqrt(varyans);

                return ST;
            }

            if (comboBox1.Text == "Standart Sapma (S)")
            {
                listBox2.Items.Add("S = " + stsapma().ToString("F2"));
            }

            if (comboBox1.Text == "OMS")
            {
                listBox2.Items.Clear();
                double ort = (double)list.Sum() / list.Count;
                int adet = list.Count;
                double toplam = 0;
                foreach (int i in list)
                {
                    double q = i - ort;
                    q = Math.Abs(q);
                    toplam = toplam + q;
                }
                double oms = toplam / adet;

                listBox2.Items.Add("oms = " + oms.ToString("F2"));
            }

            if (comboBox1.Text == "Q1")
            {
                int h = frknstablosu();
                listBox2.Items.Clear();
                int adet = list.Count;
                double b = (double)adet / 4;
                double q1 = 0;
                double n1 = 0;
                double l1 = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    if (n1 < b)
                        n1 += double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    else
                    {
                        n1 = n1 - double.Parse(dataGridView1.Rows[i - 1].Cells[4].Value.ToString());
                        q1 = double.Parse(dataGridView1.Rows[i - 1].Cells[4].Value.ToString());
                        l1 = double.Parse(dataGridView1.Rows[i - 1].Cells[2].Value.ToString());
                        break;
                    }

                }
                double j1 = b - n1;
                double sonuc = l1 + ((j1 * h) / q1);
                listBox2.Items.Add("Q1 = " + sonuc.ToString("F2"));

            }

            if (comboBox1.Text == "Q3")
            {
                int h = frknstablosu();
                listBox2.Items.Clear();
                int adet = list.Count;
                double b = ((double)adet * 3) / 4;
                double q3 = 0;
                double n3 = 0;
                double l3 = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    if (n3 < b)
                        n3 += double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    else
                    {
                        n3 = n3 - double.Parse(dataGridView1.Rows[i - 1].Cells[4].Value.ToString());
                        q3 = double.Parse(dataGridView1.Rows[i - 1].Cells[4].Value.ToString());
                        l3 = double.Parse(dataGridView1.Rows[i - 1].Cells[2].Value.ToString());
                        break;
                    }


                }
                double j3 = b - n3;
                double sonuc = l3 + ((j3 * h) / q3);
                listBox2.Items.Add("Q3 = " + sonuc.ToString("F2"));

            }

            if (comboBox1.Text == "Çarpıklık (m3)")
            {
                listBox2.Items.Clear();
                double ort = (double)list.Sum() / list.Count;
                int adet = list.Count;
                double toplam = 0;
                foreach (int i in list)
                {
                    double q = i - ort;
                    q = Math.Pow(q, 3);
                    toplam = toplam + q;
                }
                varyans = toplam / (adet - 1);
                listBox2.Items.Add("m3 = " + varyans.ToString("F2"));
            }

            if (comboBox1.Text == "Basıklık (m4)")
            {
                listBox2.Items.Clear();
                double ort = (double)list.Sum() / list.Count;
                int adet = list.Count;
                double toplam = 0;
                foreach (int i in list)
                {
                    double q = i - ort;
                    q = Math.Pow(q, 4);
                    toplam = toplam + q;
                }
                varyans = toplam / (adet - 1);
                listBox2.Items.Add("m4 = " + varyans.ToString("F2"));
            }

            if (comboBox1.Text == "Değişim Katsayısı")
            {
                listBox2.Items.Clear();
                double ort = (double)list.Sum() / list.Count;
                double ST = stsapma();
                listBox2.Items.Add("Dk = " + (ST / ort).ToString("F2"));
            }

            if (comboBox1.Text == "Toplam Olasılık / Bayes")
            {
               
                dataGridView1.Visible = false;
                groupBox3.Visible = true;
                label2.Width = 600;
                label2.Height = 100;
                label2.TextAlign = ContentAlignment.TopLeft;
                label2.Text = "Olayın sonucu veriliyor, hangi nedenden kaynaklanmış olduğunun olasılığımı isteniyor ?";
                
                

            }

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }
      
        private void button4_Click(object sender, EventArgs e)
        {
            int N, n, k, Rnd;
            N = int.Parse(textBox6.Text);
            n = int.Parse(textBox5.Text);
            k = N / n;
            Random rnd = new Random();
            Rnd = rnd.Next(1, (k + 1));

            listBox2.Items.Clear();
            for (int i = 1; i <= n; i++)
            {
                listBox2.Items.Add(Rnd);
                Rnd += k;
            }
        }

        private void textBox6_Click(object sender, EventArgs e)
        {

            textBox6.Text = " ";
        }

        private void textBox5_Click(object sender, EventArgs e)
        {

            textBox5.Text = " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Text = "Bayes yöntemi ile çözülebilir.";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "Gerçekleşme olasılıkları veriliyor, sonuç mu isteniyor ?";
            button5.Visible = false;
            button8.Visible = false;
            button9.Visible = true;
            button10.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label2.Text = "Toplam olasılık yöntemi ile çözülebilir.";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label2.Text = "Bayes yöntemi ile çözülebilir.";
        }
    }

}

