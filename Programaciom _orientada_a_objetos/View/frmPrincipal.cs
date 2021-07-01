using MaterialSkin;
using MaterialSkin.Controls;
using Model.SQLSERVERContext;
using System;

namespace Proyecto
{
    public partial class frmPrincipal : MaterialForm
    {
        public Controller.LoginController loginController = new Controller.LoginController();
        public Controller.PrincipalAppointmentProcessController principalAppointmentProcessController = new Controller.PrincipalAppointmentProcessController();
        public Administrator administratorRef;
        public Cabin cabinRef;
        public Employee employeeRef;
        public LoginTime loginTimeRef;
        public Citizen citizenRef;
        public frmPrincipal(Administrator administrator, Cabin cabin, LoginTime loginTime)
        {
            this.cabinRef = cabin;
            this.administratorRef = administrator;
            this.loginTimeRef = loginTime;
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
            lblDirectionC.Text = cabinRef.AddressCabin.ToString();
            lblPhone.Text = cabinRef.Phone.ToString();
            lblInCharge.Text = cabinRef.Manager.ToString();
            lblEmailC.Text = cabinRef.Email.ToString();
            lblDateTime.Text = $"Log In: {loginTimeRef.DateTimeLogin.ToString()}";
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            citizenRef.NameCitizen = txtName.Text.ToString();
            citizenRef.Dui = Int32.Parse(txtDui.Text);
            citizenRef.Email = txtEmail.Text.ToString();
            citizenRef.AddressCitizen = txtDirection.Text.ToString();
            citizenRef.Phone = Int32.Parse(txtTelephone.Text);
            principalAppointmentProcessController.SetCitizen(citizenRef);
        }
    }
}
