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
    
    public partial class Form2 : Form
    {
        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLNV");
            var collection = db.GetCollection<NV>("Nhanvien");
            var query = collection.AsQueryable<NV>().ToList();

            dataGridView1.DataSource = query;
        }

        public Form2()
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
            var collection = db.GetCollection<NV>("Nhanvien");
            var query = collection.AsQueryable<NV>().ToList();

            NV n = new NV();
            n.Ho_ten = txtHoten.Text;
            n.Tuoi = int.Parse(txtTuoi.Text);
            n.Gioi_tinh = txtGioitinh.Text;
            n.Dchi = txtDiachi.Text;
            n.Chuc_vu = txtChucvu.Text;

            collection.InsertOne(n);

            txtHoten.Text = "";
            txtTuoi.Text = txtTuoi.ToString();
            txtGioitinh.Text = "";
            txtDiachi.Text = "";
            txtChucvu.Text = "";

            LoadData();
        }
    }

    public class NV
    {
        public ObjectId id { get; set; }
        public string Ho_ten { get; set; }
        public int Tuoi { get; set; }
        public string Gioi_tinh { get; set; }
        public string Dchi { get; set; }
        public string Chuc_vu { get; set; }
    }
}
