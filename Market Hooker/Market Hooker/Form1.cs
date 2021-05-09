using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Market_Hooker
{
    public partial class Form1 : Form
    {
        string programcurrentdirectory = Environment.CurrentDirectory;


        public Form1()
        {
            InitializeComponent();
        }
        private string REQUEST_GET(string url)
        {
            WebRequest request = WebRequest.Create(url); //Create Request
            WebResponse response = request.GetResponse(); //Send request & get response
            Stream stream = response.GetResponseStream(); //Connect Stream
            StreamReader output = new StreamReader(stream); //Stream Reader
            string result = output.ReadToEnd();
            output.Close();
            return result;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message mouse = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref mouse);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = REQUEST_GET("https://pastebin.com/raw/ALJepgUk");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(programcurrentdirectory + "\\Market"))
                File.Delete(programcurrentdirectory + "\\Market");
            File.WriteAllText(programcurrentdirectory + "\\Market", REQUEST_GET("https://pastebin.com/raw/KFZrAH3R"));
            File.AppendAllText(programcurrentdirectory + "\\Market", REQUEST_GET("https://pastebin.com/raw/0P5vcmPM"));
            Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + programcurrentdirectory + "\\Market"));
        }
    }
}
