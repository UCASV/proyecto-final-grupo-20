using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using Model.SQLSERVERContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmPrincipal : MaterialForm
    {
        public Controller.LoginController loginController = new Controller.LoginController();
        public Administrator administratorRef;
        public Employee employeeRef;
        public frmPrincipal(Administrator administrator)
        {
            this.administratorRef = administrator;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            employeeRef = loginController.GetEmployee(administratorRef);

            lblId.Text = employeeRef.Id.ToString();
            lblName.Text = employeeRef.NameEmployee.ToString();
            lblEmail.Text = employeeRef.InstitutionalEmail.ToString();
            lblDirection.Text = employeeRef.AddressEmployee.ToString();
            lblTypeEmployee.Text = loginController.GetTypeEmployee(employeeRef).ToString();
            lblDirectionC.Text = employeeRef.Id.ToString();
            lblPhone.Text = employeeRef.Id.ToString();
            lblInCharge.Text = employeeRef.Id.ToString();
            lblEmailC.Text = employeeRef.Id.ToString();

            updateDataGridViewArrival();
            updateDataGridViewVaccination();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel12_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel14_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel19_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel19_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void updateDataGridViewArrival()
        {
            var db = new ProyectDBContext();

            var listTimesArrival = db.Vaccinations.Include(a => a.ArrivalTime).ToList();

            foreach (Vaccination at in listTimesArrival)
            {
                listTimesArrival.Add(at.ArrivalTime);
            }

            dgvSalaEspera.DataSource = null;
            dgvSalaEspera.DataSource = listTimesArrival;
        }

        private void updateDataGridViewVaccination()
        {
            var db = new ProyectDBContext();

            var listTimeVaccination = db.Vaccinations.Include(a => a.VaccinationTime).ToList();

            foreach (Vaccination vt in listTimeVaccination)
            {
                listTimeVaccination.Add(vt.VaccinationTime);
            }

            dgvVacunaciones.DataSource = null;
            dgvVacunaciones.DataSource = listTimeVaccination;
        }
    }
}
