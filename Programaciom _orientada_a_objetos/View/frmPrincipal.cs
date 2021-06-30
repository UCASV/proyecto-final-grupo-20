using MaterialSkin;
using MaterialSkin.Controls;
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
    }
}
