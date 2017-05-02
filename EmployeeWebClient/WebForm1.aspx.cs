using EmployeeWebClient.EmployeeService;
using System;

namespace EmployeeWebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeServiceClient client = new EmployeeServiceClient();

            Employee employee =
              client.GetEmployee(Convert.ToInt32(txtID.Text));

            txtName.Text = employee.Name;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                ID = Convert.ToInt32(txtID.Text),
                Name = txtName.Text,
                Gender = txtGender.Text,
                DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text)
            };

            EmployeeServiceClient client = new EmployeeServiceClient();
            client.SaveEmployee(employee);
        }
    }
}