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
    public partial class Form3 : Form
    {
        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLNV");
            var collection = db.GetCollection<PB>("Phongban");
            var query = collection.AsQueryable<PB>().ToList();

            dataGridView1.DataSource = query;
        }

        public Form3()
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
            var collection = db.GetCollection<PB>("Phongban");
            var query = collection.AsQueryable<PB>().ToList();

            PB p = new PB();
            p.So_phong = txtSophong.Text;
            p.Ten_phong = txtTenphong.Text;
            p.Cong_viec = txtCongviec.Text;

            collection.InsertOne(p);

            txtSophong.Text = "";
            txtTenphong.Text = "";
            txtCongviec.Text = "";

            LoadData();
        }
    }

    public class PB
    {
        public ObjectId id { get; set; }
        public string So_phong { get; set; }
        public string Ten_phong { get; set; }
        public string Cong_viec { get; set; }
    }
}
