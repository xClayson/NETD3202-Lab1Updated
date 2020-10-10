using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace BillingApp
{
    public class Program
    {
        #region "Variable Declarations"

        //Private data members
        private string projectName;
        private double budget;
        private double amountSpent;
        private double hoursRemaining;
        private int projectStatus;

        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor for Project Object
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="budget"></param>
        /// <param name="amountSpent"></param>
        /// <param name="hoursRemaining"></param>
        /// <param name="projectStatus"></param>
        public Program(string projectName, double budget, double amountSpent, double hoursRemaining, int projectStatus)
        {
            this.projectName = projectName;
            this.budget = budget;
            this.amountSpent = amountSpent;
            this.hoursRemaining = hoursRemaining;
            this.projectStatus = projectStatus;
        }
        #endregion

        #region "Getters/Setters"

        /// <summary>
        /// Getter/Setter of Project Name 
        /// </summary>
        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }
        }

        /// <summary>
        /// Getter/Setter of Budget
        /// </summary>
        public double Budget
        {
            get { return this.budget; }
            set { this.budget = value; }
        }
        /// <summary>
        /// Getter/Setter of Amount Spent
        /// </summary>
        public double AmountSpent
        {
            get { return this.amountSpent; }
            set { this.amountSpent = value; }
        }
        /// <summary>
        /// Getter/Setter of Hours Remaining
        /// </summary>
        public double HoursRemaining
        {
            get { return this.hoursRemaining; }
            set { this.hoursRemaining = value; }
        }
        /// <summary>
        /// Getter/Setter for Project Status
        /// </summary>
        public int ProjectStatus
        {
            get { return this.projectStatus; }
            set { this.projectStatus = value; }
        }

        #endregion
    }
}
