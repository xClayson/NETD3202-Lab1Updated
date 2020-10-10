/*
 * Name: Ryan Clayson
 * Date: 10/08/2020
 * Course: NETD 3202
 * Purpose: Second window to allow user to edit a project already created.  
 */
using BillingApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NETD3202_Lab1
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {      
        public ObservableCollection<Program> projects;
        public int projectSelect;
        public object sender;

        public SecondWindow(ObservableCollection<Program> projects, int projectSelect, object sender)
        { 
            InitializeComponent();
            this.projects = projects;
            this.projectSelect = projectSelect;
            this.sender = sender;

            //Creates project of projects already created
            Program project = projects[projectSelect];

            //Used to display attributes of the project
            txtProjectNameEdit.Text = project.ProjectName;
            txtBudgetEdit.Text = project.Budget.ToString();
            txtSpentEdit.Text = project.AmountSpent.ToString();
            txtEstHoursRemainingEdit.Text = project.HoursRemaining.ToString();
            cmbStatusEdit.SelectedIndex = project.ProjectStatus;
        }

         // When alter button is clicked, saves the users edits in the input fields.
        private void btnAlterProject_Click(object sender, RoutedEventArgs e)
        {
            projects = CreateProject();
        }
        //Button used to close second window when clicked
        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }      

        public ObservableCollection<Program> CreateProject()
        {
            //Similar to MainWindow declare varaibles 
            //Variable declarations 
            string projectName;
            double budget;
            double amountSpent;
            double hoursRemaining;
            int projectStatus;

            projectStatus = cmbStatusEdit.SelectedIndex;

            //checks to see if Project name is empty
            if (txtProjectNameEdit.Text.Trim() != string.Empty)
            {
                projectName = txtProjectNameEdit.Text;

                //checks to see if Budget is numeric/empty
                if (double.TryParse(txtBudgetEdit.Text.Trim(), out budget))
                {
                    //checks to see if Amount Spent is numeric/empty
                    if (double.TryParse(txtSpentEdit.Text.Trim(), out amountSpent))
                    {
                        //checks to see if Hours Remaining is numeric/empty
                        if (double.TryParse(txtEstHoursRemainingEdit.Text.Trim(), out hoursRemaining))
                        {
                            //checks to see if budget it greater than 0
                            if (budget >= 0)
                            {
                                //checks to see if amount spent is greater than 0
                                if (amountSpent >= 0)
                                {
                                    if (hoursRemaining >= 0)
                                    {
                                        //checks to see if hours remaining is 0
                                        if (hoursRemaining == 0)
                                        {
                                            //If hours equals 0. "Completed" status is automatically selected
                                            cmbStatusEdit.SelectedIndex = 5;
                                            projectStatus = cmbStatusEdit.SelectedIndex;
                                        }
                                            //If user selects completed, changes that value of Est. Hours to 0 for validation
                                            if (cmbStatusEdit.SelectedIndex == 5)                                            
                                            {
                                                hoursRemaining = 0;
                                                txtEstHoursRemainingEdit.Text = hoursRemaining.ToString();
                                            }

                                            //All validation passes, adds to list, listbox items are cleared
                                            projects[projectSelect] = new Program(projectName, budget, amountSpent, hoursRemaining, projectStatus);
                                        
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hours Remaining must be greater than 0.");
                                        txtEstHoursRemainingEdit.Text = "";
                                        txtEstHoursRemainingEdit.Focus();
                                    }
                                }
                                else
                                {
                                    //Amount Spent is less than 0
                                    MessageBox.Show("Amount Spent must be greater than 0.");
                                    txtSpentEdit.Text = "";
                                    txtSpentEdit.Focus();
                                }
                            }
                            else
                            {
                                //Budget is less than 0
                                MessageBox.Show("Budget must be greater than 0.");
                                txtBudgetEdit.Text = "";
                                txtBudgetEdit.Focus();
                            }
                        }
                        else
                        {
                            //Error Msg. User entered non numeric value or empty
                            MessageBox.Show("Hours Remaining must be numeric.");
                            txtEstHoursRemainingEdit.Text = "";
                            txtEstHoursRemainingEdit.Focus();
                        }
                    }
                    else
                    {
                        //Error Msg. User entered non numeric value or empty
                        MessageBox.Show("Amount Spent must be numeric.");
                        txtSpentEdit.Text = "";
                        txtSpentEdit.Focus();
                    }
                }
                else
                {
                    //Error Msg. User entered a string 
                    MessageBox.Show("Budget must be numeric.");
                    txtBudgetEdit.Text = "";
                    txtBudgetEdit.Focus();
                }
            }
            else
            {
                //Error Msg. User did not enter a project name
                MessageBox.Show("Please enter a Project Name.");
                txtProjectNameEdit.Focus();
            }
            
            
            CollectionViewSource.GetDefaultView(projects).Refresh();
            return projects;
        }

        
    }
}
