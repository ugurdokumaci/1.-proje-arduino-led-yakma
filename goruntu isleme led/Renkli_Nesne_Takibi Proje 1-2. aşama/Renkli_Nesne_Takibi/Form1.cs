using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.IO.Ports;


namespace Renkli_Nesne_Takibi
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection webcam;//webcam isminde tanımladığımız değişken bilgisayara kaç kamera bağlıysa onları tutan bir dizi.
        private VideoCaptureDevice Finalvideo;//Finalvideo ise bizim kullanacağımız aygıt
        Bitmap bolgeliresim;
        int bolge;
        Color cisimrengi;
        int cisimxkordinati;
        int cisimykordinati;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            portCombo.DataSource = SerialPort.GetPortNames();
            toolStripLabel1.Text = "";
            portKes.Enabled = false;
            ledYak.Enabled = false;
            

            int portSayisi = 0;
            portSayisi = portCombo.Items.Count;
            if (portSayisi < 1)
            {
                portBagla.Enabled = false;
                toolStripLabel1.Text = "Aygıt bulunamadı. Bağlantıyı kontrol et!!";
            }
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);//webcam dizisine mevcut kameraları dolduruyoruz.
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);//kameraları combobox a dolduruyoruz.
            }
            comboBox1.SelectedIndex = 0; //Comboboxtaki ilk index numaralı kameranın ekranda görünmesi için
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Finalvideo = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            Finalvideo.NewFrame += new NewFrameEventHandler(Finalvideo_NewFrame);
            Finalvideo.DesiredFrameRate = 20;//saniyede kaç görüntü alsın istiyorsanız. FPS
            Finalvideo.DesiredFrameSize = new Size(320, 240);//görüntü boyutları
            Finalvideo.Start();      
        }
        void Finalvideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image1 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = image;   
            if (radioButton1.Checked)
            {
                EuclideanColorFiltering filter = new EuclideanColorFiltering();//filtreyi oluşturuyoruz
                filter.CenterColor = new RGB(Color.FromArgb(255,10, 10)); //merkez renkgi belirliyoruz
                filter.Radius = 130; //filtrenin uygulayacagı yarıçap uzunlugu
                filter.ApplyInPlace(image1);//filtreyi resme uyguluyoruz
                BlobCounter bc = new BlobCounter();
                bc.ProcessImage(image1);
                Rectangle[] rects = bc.GetObjectsRectangles();
                foreach (Rectangle rect in rects)
                {
                    cisimxkordinati = rect.X;
                    cisimykordinati = rect.Y;
                }
                cisimrengi = Color.FromArgb(255, 10, 10);
                bolgeliresim = image1;
                pictureBox2.Image = image1;
                int w = pictureBox2.Image.Size.Width;
                int h = pictureBox2.Image.Size.Height;
                double satırbulucu = (h / 3);
                double sutunbulucu = (w / 3);

                if (cisimxkordinati <= sutunbulucu && cisimykordinati <= satırbulucu)
                {
                    bolge = 1;
                    serialPort1.Write("1");
                }
                  else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati <= satırbulucu)
            {
                bolge = 2;
                serialPort1.Write("2");

            }
            else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati <= satırbulucu)
            {
                bolge = 3;
                serialPort1.Write("3");

            }
            else if (cisimxkordinati <= sutunbulucu && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
            {
                bolge = 4;
                serialPort1.Write("4");

            }
            else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
            {
                bolge = 5;
                serialPort1.Write("5");

            }
            else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
            {
                bolge = 6;
                serialPort1.Write("6");

            }
            else if (cisimxkordinati <= sutunbulucu && cisimykordinati > (2 * satırbulucu))
            {
                bolge = 7;
                serialPort1.Write("7");

            }
            else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati > (2 * satırbulucu))
            {
                bolge = 8;
                serialPort1.Write("8");

            }
            else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati > (2 * satırbulucu))
            {
                bolge = 9;
                serialPort1.Write("9");

            }
            else 
            { bolge = 0;
                serialPort1.Write("0");
            }
            }
            if (radioButton2.Checked)
            {
                EuclideanColorFiltering filter = new EuclideanColorFiltering();//filtreyi oluşturuyoruz
                filter.CenterColor = new RGB(Color.FromArgb(0, 215, 0));//merkez renkgi belirliyoruz
                filter.Radius = 100;//filtrenin uygulayacagı yarıçap uzunlugu
                filter.ApplyInPlace(image1);//filtreyi resme uyguluyoruz
                BlobCounter bc = new BlobCounter();
                bc.ProcessImage(image1);
                Rectangle[] rects = bc.GetObjectsRectangles();
                foreach (Rectangle rect in rects)
                {
                    cisimxkordinati = rect.X;
                    cisimykordinati = rect.Y;
                }
                cisimrengi = Color.FromArgb(0, 215, 0);
                bolgeliresim = image1;
                pictureBox2.Image = image1;
            }
            if (radioButton3.Checked)
            {
                EuclideanColorFiltering filter = new EuclideanColorFiltering();//filtreyi oluşturuyoruz
                filter.CenterColor = new RGB(Color.FromArgb(30, 144, 255));//merkez renkgi belirliyoruz
                filter.Radius = 100;//filtrenin uygulayacagı yarıçap uzunlugu
                filter.ApplyInPlace(image1);//filtreyi resme uyguluyoruz
                BlobCounter bc = new BlobCounter();
                bc.ProcessImage(image1);
                Rectangle[] rects = bc.GetObjectsRectangles();
                foreach (Rectangle rect in rects)
                {
                    cisimxkordinati = rect.X;
                    cisimykordinati = rect.Y;
                }
                cisimrengi = Color.FromArgb(30, 144, 255);
                bolgeliresim = image1;
                pictureBox2.Image = image1;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Finalvideo.IsRunning)//çalışan kamerayı durduruyoruz
            {
                Finalvideo.Stop();
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Finalvideo.IsRunning) //kamera açıksa kapatıyoruz.
            {
                Finalvideo.Stop(); //kamera açıksa kapatıyoruz.
            }
            Application.Exit();//uygulamadan çıkış
        }      
        private void bolgebulucu()
        {
            int w = pictureBox2.Image.Size.Width;
            int h = pictureBox2.Image.Size.Height;
            double satırbulucu = (h / 3);
            double sutunbulucu = (w / 3);

                    if (cisimxkordinati <= sutunbulucu && cisimykordinati <= satırbulucu )
                    {
                       bolge = 1;
               


            }
                    else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati <= satırbulucu )
                    {
                        bolge = 2;
                
                
            }
                    else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati <= satırbulucu )
                    {
                        bolge = 3;
                
               
            }
                    else if (cisimxkordinati <= sutunbulucu && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
                    {
                        bolge = 4;
                
                
            }
                    else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
                    {
                        bolge = 5;
                
               
            }
                    else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
                    {
                        bolge = 6;
                
               
            }
            else if (cisimxkordinati <= sutunbulucu && cisimykordinati > (2*satırbulucu))
            {
                bolge = 7;
                
                
            }
            else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati > (2*satırbulucu))
            {
                bolge = 8;
                
                
            }
            else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati > (2*satırbulucu))
            {
                bolge = 9;
                
                
            }
            else
                    { bolge = 0; }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bolgebulucu();
            label1.Text = Convert.ToString(bolge);       
        }

        private void portBagla_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = portCombo.SelectedItem.ToString();
            serialPort1.Open();
            if (serialPort1.IsOpen == true)
            {
                toolStripLabel1.Text = serialPort1.PortName + " portuna bağlandı.";
                portKes.Enabled = true;
                ledYak.Enabled = true;
                
                portBagla.Enabled = false;

            }
            else
            {
                toolStripLabel1.Text = "Porta bağlamadı. Kontrol et!!";
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ledYak_Click(object sender, EventArgs e)
        {
            int w = pictureBox2.Image.Size.Width;
            int h = pictureBox2.Image.Size.Height;
            double satırbulucu = (h / 3);
            double sutunbulucu = (w / 3);

            if (cisimxkordinati <= sutunbulucu && cisimykordinati <= satırbulucu)
            {
                bolge = 1;
                serialPort1.Write("1");


            }
            else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati <= satırbulucu)
            {
                bolge = 2;
                serialPort1.Write("2");

            }
            else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati <= satırbulucu)
            {
                bolge = 3;
                serialPort1.Write("3");

            }
            else if (cisimxkordinati <= sutunbulucu && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
            {
                bolge = 4;
                serialPort1.Write("4");

            }
            else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
            {
                bolge = 5;
                serialPort1.Write("5");

            }
            else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati > satırbulucu && cisimykordinati <= (2 * satırbulucu))
            {
                bolge = 6;
                serialPort1.Write("6");

            }
            else if (cisimxkordinati <= sutunbulucu && cisimykordinati > (2 * satırbulucu))
            {
                bolge = 7;
                serialPort1.Write("7");

            }
            else if (cisimxkordinati > sutunbulucu && cisimxkordinati <= (2 * sutunbulucu) && cisimykordinati > (2 * satırbulucu))
            {
                bolge = 8;
                serialPort1.Write("8");

            }
            else if (cisimxkordinati > (2 * sutunbulucu) && cisimykordinati > (2 * satırbulucu))
            {
                bolge = 9;
                serialPort1.Write("9");

            }
            else 
            { bolge = 0;
                serialPort1.Write("0");
            }
            
        }
        private void portKes_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            toolStripLabel1.Text = "Bağlantı Kesildi";
            portKes.Enabled = false;
            ledYak.Enabled = false;
            
            portBagla.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}



