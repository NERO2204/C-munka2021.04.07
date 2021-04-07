using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adatbazis
{
    public partial class Form1 : Form
    {
        List<Auto> autok;
        private DataTable raktarTabla;
        static int id = 0;
        public Form1()
        {
            autok = new List<Auto>();
            InitializeComponent();
            raktarTabla = new DataTable();

            autok.Add(new Auto("Del","jovo","piros"));

            tablabaAdatotrak();
            bepakol();
            dataGridView1.DataSource=raktarTabla;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
        private void bepakol()
        {
            foreach (var auto in autok)
            {
                DataRow dr = raktarTabla.NewRow();
                dr["Gyárto"] = auto.Gyarto;
                dr["Szin"] = auto.Szin;
                dr["Név"] = auto.Nev;
                dr["ID"] = id;
                
                raktarTabla.Rows.Add(dr);
                id++;
            }
           
           
        }
        private void tablabaAdatotrak()
        {

            DataColumn gyartoColumn = new DataColumn("Gyárto", typeof(string));
            DataColumn szinColumn = new DataColumn("Szin", typeof(string));
            DataColumn idColumn = new DataColumn("ID",typeof(int));

            DataColumn nevColumn = new DataColumn("Név", typeof(string));
            raktarTabla.Columns.AddRange(new DataColumn[] { gyartoColumn, szinColumn, nevColumn });
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                raktarTabla.Rows[int.Parse(txtTorol.Text)].Delete();
                raktarTabla.AcceptChanges();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            bepakol();
        }
    }
}
