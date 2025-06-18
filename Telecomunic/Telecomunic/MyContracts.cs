using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using SLRDbConnector;


namespace Telecomunic
{
    public partial class MyContracts : UserControl
    {
        DbConnector db;
        String id1;
        static public int id;
        String nume;
        String pass;
        String adresa;
        String localitate;
        String strada;
        String casa;
        String apartament;
        String abonament;
        String start;
        String end;
        String cost1;
        String cost2;
        String contracts;

        public MyContracts()
        {
            InitializeComponent();
            db = new DbConnector();
            nume = MainApp.name;
            pass = MainApp.pass;
            db.getSingleValue("SELECT id FROM Abonati where nume = '" + nume + "' and parola='" + pass + "'", out id1, 0);
            id = Int32.Parse(id1);


        }


        public void UpdateDetails()
        {
            name.Text = nume;
            db.getSingleValue("SELECT a.localitate from Adrese a join Abonati b on a.id = b.idAdresa where b.id = " + id + "", out localitate, 0);
            db.getSingleValue("SELECT a.strada from Adrese a join Abonati b on a.id = b.idAdresa where b.id = " + id + "", out strada, 0);
            db.getSingleValue("SELECT a.nrCasa from Adrese a join Abonati b on a.id = b.idAdresa where b.id = " + id + "", out casa, 0);
            db.getSingleValue("SELECT a.apartament from Adrese a join Abonati b on a.id = b.idAdresa where b.id = " + id + "", out apartament, 0);
            adresa = localitate + " " + strada + " " + casa + " ap." + apartament;
            address.Text = adresa;
            db.getSingleValue("SELECT denumire FROM Abonamente a JOIN Contracte c ON a.id=c.idAbonament JOIN Abonati ab ON c.idAbonat = ab.id WHERE ab.id = " + id + " and a.id < 5", out abonament, 0);
            subscription.Text = abonament;
            start = db.getSingleValue("SELECT dataStart FROM Contracte where idAbonat = " + id + "  and idAbonament < 5", out start, 0);
            if (start != null)
                start = start.Split(' ')[0];
            dataStart.Text = start;
            end = db.getSingleValue("SELECT dataEnd FROM Contracte where idAbonat = " + id + "", out end, 0);
            if (end != null)
                end = end.Split(' ')[0];
            dataEnd.Text = end;
            cost1 = db.getSingleValue("SELECT cost FROM Abonamente where denumire = '" + abonament + "'", out cost1, 0);
            if (cost1 != null)
                cost.Text = cost1 + "$";
            else cost.Text = "";

            db.getSingleValue("SELECT COUNT(idAbonat) FROM Contracte where idAbonat = " + id + " GROUP BY idAbonat", out contracts, 0);
            if(contracts != null)
            if (Int32.Parse(contracts) > 1)
            {
                db.getSingleValue("SELECT denumire FROM Abonamente a JOIN Contracte c ON a.id=c.idAbonament JOIN Abonati ab ON c.idAbonat = ab.id WHERE ab.id = " + id + " and a.id > 4", out abonament, 0);
                subMobile.Text = abonament;
                start = db.getSingleValue("SELECT dataStart FROM Contracte where idAbonat = " + id + " and idAbonament > 4", out start, 0);
                if (start != null)
                    start = start.Split(' ')[0];
                startMobile.Text = start;
                end = db.getSingleValue("SELECT dataEnd FROM Contracte where idAbonat = " + id + " and idAbonament > 4", out end, 0);
                if (end != null)
                    end = end.Split(' ')[0];
                endMobile.Text = end;
                cost2 = db.getSingleValue("SELECT cost FROM Abonamente where denumire = '" + abonament + "'", out cost2, 0);
                if (cost2 != null)
                    costMobile.Text = cost2 + "$";
                else cost.Text = "";
            }
            if (cost1 != null && cost2 != null)
            {
                totalPay.Text = (Int32.Parse(cost1) + Int32.Parse(cost2)).ToString() + "$";
            }
            else if (cost1 != null && cost2 == null)
            {
                totalPay.Text = (Int32.Parse(cost1)).ToString() + "$";
            }
            else if (cost2 != null && cost1 == null)
            {
                totalPay.Text = (Int32.Parse(cost2)).ToString() + "$";
            }
            else
            {
                totalPay.Text = " ";
            }




        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
