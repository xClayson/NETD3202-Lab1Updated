/*
 * Name: Ryan Clayson
 * Date: 10/01/2020
 * Course: NETD 3202
 * Purpose: Main window to allow user to create project. 
 */
using BillingApp;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NETD3202_Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //txtProjectName.Focus();
            lstProjects.ItemsSource = projects;
        }

        //Creates a new list of object Program
        public ObservableCollection<Program> projects = new ObservableCollection<Program>();

        /// <summary>
        /// Called when a user clicks the create button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            projects = CreateProject();
        }

        private void lstProjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = lstProjects.SelectedIndex;
            SecondWindow newWindowDisplay = new SecondWindow(projects, selectedIndex, sender);
            newWindowDisplay.Show();

        }

        public ObservableCollection<Program> CreateProject()
        {
            //Variable declarations 
            string projectName;
            double budget;
            double amountSpent;
            double hoursRemaining;
            int projectStatus;
            
            projectStatus = cmbStatus.SelectedIndex;

            //checks to see if Project name is empty
            if (txtProjectName.Text.Trim() != string.Empty)
            {
                projectName = txtProjectName.Text;

                //checks to see if Budget is numeric/empty
                if (double.TryParse(txtBudget.Text.Trim(), out budget))
                {
                    //checks to see if Amount Spent is numeric/empty
                    if(double.TryParse(txtSpent.Text.Trim(), out amountSpent))
                    {
                        //checks to see if Hours Remaining is numeric/empty
                        if(double.TryParse(txtEstHoursRemaining.Text.Trim(), out hoursRemaining))
                        {
                            //checks to see if budget it greater than 0
                            if(budget >= 0)
                            {
                                //checks to see if amount spent is greater than 0
                                if(amountSpent >= 0)
                                {
                                    if (hoursRemaining >= 0)
                                    {
                                        //checks to see if hours remaining is 0
                                        if (hoursRemaining == 0)
                                        {
                                            //If hours equals 0. "Completed" status is automatically selected
                                            cmbStatus.SelectedIndex = 5;
                                            projectStatus = cmbStatus.SelectedIndex;             
                                        }
                                        // If completed is selected. Automatically change user input for Est. Hours to 0
                                        if(cmbStatus.SelectedIndex == 5)
                                        {
                                            hoursRemaining = 0;
                                            txtEstHoursRemaining.Text = hoursRemaining.ToString();
                                        }

                                        //All validation passes, creates object for project, retrieves all user inputted information
                                        projects.Add(new Program(projectName, budget, amountSpent, hoursRemaining, projectStatus));
                                        //resets form
                                        txtProjectName.Text = ""; txtBudget.Text = ""; txtSpent.Text = "";
                                        txtEstHoursRemaining.Text = ""; cmbStatus.SelectedIndex = 0;                                        
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hours Remaining must be greater than 0.");
                                        txtEstHoursRemaining.Text = "";
                                        txtEstHoursRemaining.Focus();
                                    }
                                }
                                else
                                {
                                    //Amount Spent is less than 0
                                    MessageBox.Show("Amount Spent must be greater than 0.");
                                    txtSpent.Text = "";
                                    txtSpent.Focus();
                                }
                            }
                            else
                            {
                                //Budget is less than 0
                                MessageBox.Show("Budget must be greater than 0.");
                                txtBudget.Text = "";
                                txtBudget.Focus();
                            }
                        }
                        else
                        {
                            //Error Msg. User entered non numeric value or empty
                            MessageBox.Show("Hours Remaining must be numeric.");
                            txtEstHoursRemaining.Text = "";
                            txtEstHoursRemaining.Focus();
                        }
                    }
                    else
                    {
                        //Error Msg. User entered non numeric value or empty
                        MessageBox.Show("Amount Spent must be numeric.");
                        txtSpent.Text = "";
                        txtSpent.Focus();
                    }
                }
                else
                {
                    //Error Msg. User entered a string 
                    MessageBox.Show("Budget must be numeric.");
                    txtBudget.Text = "";
                    txtBudget.Focus();                    
                }
            }
            else
            {
                //Error Msg. User did not enter a project name
                MessageBox.Show("Please enter a Project Name.");
                txtProjectName.Focus();
            }

            return projects;
        }

        //Below used for Lab1 pop up window

        ///// <summary>
        ///// Event handler to show Project Information
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void lstProjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    //shows a message box with all users information shows for the project created
        //    MessageBox.Show("Project Name: " + lstProjects.SelectedItem.ToString() +
        //                    "\nBudget: " + allProjects[lstProjects.SelectedIndex].Budget +
        //                    "\nSpent: " + allProjects[lstProjects.SelectedIndex].AmountSpent +
        //                    "\nHours Remaining: " + allProjects[lstProjects.SelectedIndex].HoursRemaining +
        //                    "\nStatus: " + allProjects[lstProjects.SelectedIndex].ProjectStatus);                          
        //}
    }
}
