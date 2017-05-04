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

            if (employee.Type == EmployeeType.FullTime)
            {
                txtAnnualSalary.Text = ((FullTimeEmployee)employee).AnnualSalary.ToString();
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                txtHourlyPay.Text = ((PartTimeEmployee)employee).HourlyPay.ToString();
                txtHoursWorked.Text = ((PartTimeEmployee)employee).HoursWorked.ToString();
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }

            ddlEmployeeType.SelectedValue = ((int)employee.Type).ToString();
            txtName.Text = employee.Name;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = null;

            if ((EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue) == EmployeeType.FullTime)
            {
                employee = new FullTimeEmployee
                {
                    AnnualSalary = Convert.ToInt32(txtAnnualSalary.Text),
                    Type = EmployeeType.FullTime
                };
            }
            else
            {
                employee = new PartTimeEmployee
                {
                    HourlyPay = Convert.ToInt32(txtHourlyPay.Text),
                    HoursWorked = Convert.ToInt32(txtHoursWorked.Text),
                    Type = EmployeeType.PartTime
                };
            }

            employee.ID = Convert.ToInt32(txtID.Text);
            employee.Name = txtName.Text;
            employee.Gender = txtGender.Text;
            employee.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);

            EmployeeServiceClient client = new EmployeeServiceClient();
            client.SaveEmployee(employee);

            lblMessage.Text = "Employee saved";
        }

        protected void ddlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            trAnnualSalary.Visible = (ddlEmployeeType.SelectedValue == "1");
            trHourlPay.Visible = (ddlEmployeeType.SelectedValue == "2");
            trHoursWorked.Visible = (ddlEmployeeType.SelectedValue == "2");
        }

        protected void btnGetEmployeeMessageContract_Click(object sender, EventArgs e)
        {
            IEmployeeService client = new EmployeeServiceClient();
            EmployeeRequest request = new EmployeeRequest("KEY12345", Convert.ToInt32(txtID.Text));
            EmployeeInfo employeeInfo = client.GetEmployeeMessageContract(request);

            if (employeeInfo.Type == EmployeeType.FullTime)
            {
                txtAnnualSalary.Text = employeeInfo.AnnualSalary.ToString();
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                txtHourlyPay.Text = employeeInfo.HourlyPay.ToString();
                txtHoursWorked.Text = employeeInfo.HoursWorked.ToString();
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }

            ddlEmployeeType.SelectedValue = ((int)employeeInfo.Type).ToString();
            txtName.Text = employeeInfo.Name;
            txtGender.Text = employeeInfo.Gender;
            txtDateOfBirth.Text = employeeInfo.DOB.ToShortDateString();
        }

        protected void btnSaveEmployeeContract_Click(object sender, EventArgs e)
        {
            EmployeeService.IEmployeeService client = new
    EmployeeService.EmployeeServiceClient();
            EmployeeService.EmployeeInfo employeeInfo = new EmployeeService.EmployeeInfo();

            if (ddlEmployeeType.SelectedValue == "-1")
                lblMessage.Text = "Please select Employee Type";
            else
            {
                if (((EmployeeService.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue))
                  == EmployeeService.EmployeeType.FullTime)
                {
                    employeeInfo.AnnualSalary = Convert.ToInt32(txtAnnualSalary.Text);
                    employeeInfo.Type = EmployeeService.EmployeeType.FullTime;
                }
                else if (((EmployeeService.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue))
                  == EmployeeService.EmployeeType.PartTime)
                {
                    employeeInfo.HourlyPay = Convert.ToInt32(txtHourlyPay.Text);
                    employeeInfo.HoursWorked = Convert.ToInt32(txtHoursWorked.Text);
                    employeeInfo.Type = EmployeeService.EmployeeType.PartTime;
                }

                employeeInfo.ID = Convert.ToInt32(txtID.Text);
                employeeInfo.Name = txtName.Text;
                employeeInfo.Gender = txtGender.Text;
                employeeInfo.DOB = Convert.ToDateTime(txtDateOfBirth.Text);

                client.SaveEmployeeMessageContract(employeeInfo);
                lblMessage.Text = "Employee saved";
            }
        }
    }
}