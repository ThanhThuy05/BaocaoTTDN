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
    public partial class Form4 : Form
    {
        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLNV");
            var collection = db.GetCollection<PC>("Phancong");
            var query = collection.AsQueryable<PC>().ToList();

            dataGridView1.DataSource = query;
        }

        public Form4()
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
            var collection = db.GetCollection<PC>("Phancong");
            var query = collection.AsQueryable<PC>().ToList();

            PC p = new PC();
            p.Ho_ten = txtHoten.Text;
            p.So_phong = txtSophong.Text;
            p.Cong_viec = txtCongviec.Text;
            p.Luong = int.Parse(txtLuong.Text);

            collection.InsertOne(p);

            txtHoten.Text = "";
            txtSophong.Text = "";
            txtCongviec.Text = "";
            txtLuong.Text = txtLuong.ToString();

            LoadData();
        }
    }

    public class PC
    {
        public ObjectId id { get; set; }
        public string Ho_ten { get; set; }
        public string So_phong { get; set; }
        public string Cong_viec { get; set; }
        public int Luong { get; set; }
    }
}
