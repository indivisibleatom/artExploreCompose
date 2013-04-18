using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace DataCreator
{
    public partial class SpecifyImageParameters : Form
    {
        string m_filePath;

        public SpecifyImageParameters(string path)
        {
            InitializeComponent();
            m_filePath = path;
        }

        private void createXML()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
                createXML();
             
                //string url = "http://localhost:8888/getInsertID";
                //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                //httpWebRequest.Method = "GET";
                //httpWebRequest.KeepAlive = true;
                //httpWebRequest.ContentType = "text/xml; encoding='utf-8'";
               
                //WebResponse response = httpWebRequest.GetResponse();
                //Stream objStream = response.GetResponseStream();
                //objStream.Read(b, 0, (int)response.ContentLength);
                //string id = BitConverter.ToString(b, 0);
                //objStream.Close();

                string url = "http://localhost:8888/uploadXML";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.ContentType = "text/xml; encoding='utf-8'";
                Stream memStream = new MemoryStream();
                string[] files = { m_filePath };
                foreach (string file in files)
                {
                    FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        memStream.Write(buffer, 0, bytesRead);
                    }
                    fileStream.Close();
                }
                httpWebRequest.ContentLength = memStream.Length;
                Stream requestStream = httpWebRequest.GetRequestStream();
                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();

                m_filePath = m_filePath.Replace(".xml",".dat");
                url = "http://localhost:8888/uploadDAT";
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.ContentType = "application/octet-stream";
                memStream = new MemoryStream();
                string[] files1 = { m_filePath };
                foreach (string file in files1)
                {
                    FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        memStream.Write(buffer, 0, bytesRead);
                    }
                    fileStream.Close();
                }
                httpWebRequest.ContentLength = memStream.Length;
                requestStream = httpWebRequest.GetRequestStream();
                memStream.Position = 0;
                tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();

                url = "http://localhost:8888/updateDBs?LATITUDE="+textBox1.Text+"&LONGITUDE="+textBox2.Text+"&X_SIZE="+textBox5.Text+"&Y_SIZE="+textBox6.Text+"&Z_SIZE="+textBox7.Text+"&WIDTH="+textBox3.Text+"&HEIGHT="+textBox4.Text;
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.ContentType = "text/xml; encoding='utf-8'";
                Stream objStream = httpWebRequest.GetResponse().GetResponseStream();
        }

        private void SpecifyImageParameters_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
