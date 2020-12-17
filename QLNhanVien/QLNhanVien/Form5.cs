using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace QLNhanVien
{
    public partial class Form5 : Form
    {
        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLNV");
            var collection = db.GetCollection<TN>("ThanNhan");
            var query = collection.AsQueryable<TN>().ToList();

            dataGridView1.DataSource = query;
        }

        public Form5()
        {
            InitializeComponent();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLNV");
            var collection = db.GetCollection<TN>("ThanNhan");
            var query = collection.AsQueryable<TN>().ToList();

            TN t = new TN();
            t.Hoten = txtHoten.Text;
            t.Tuoi = int.Parse(txtTuoi.Text);
            t.Diachi = txtDiachi.Text;
            t.Gioi_tinh = txtGioitinh.Text;
            t.Nghe_nghiep = txtNghenghiep.Text;

            collection.InsertOne(t);

            txtHoten.Text = "";
            txtTuoi.Text = txtTuoi.ToString();
            txtDiachi.Text = "";
            txtGioitinh.Text = "";
            txtNghenghiep.Text = "";

            LoadData();

        }
    }

    public class TN
    {
        public ObjectId id { get; set; }
        public string Hoten { get; set; }
        public int Tuoi { get; set; }
        public string Diachi { get; set; }
        public string Gioi_tinh { get; set; }
        public string Nghe_nghiep { get; set; }
    }
}
