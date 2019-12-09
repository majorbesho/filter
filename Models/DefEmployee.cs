using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class DefEmployee
    {
        public DefEmployee()
        {
            this.DefEmployee1 = new List<DefEmployee>();
           // this.PrlBonus = new List<PrlBonu>();
           // this.PrlDeductions = new List<PrlDeduction>();
            //this.PrlInstallmentTransactions = new List<PrlInstallmentTransaction>();
           // this.PrlInstallmentTransLines = new List<PrlInstallmentTransLine>();
           // this.PrlOtherPayments = new List<PrlOtherPayment>();
           // this.PrlPayments = new List<PrlPayment>();
           // this.PrlPrepareSummaries = new List<PrlPrepareSummary>();
          //  this.PrlProfits = new List<PrlProfit>();
          //  this.PrlSalaries = new List<PrlSalary>();
          //  this.PrlSCCalculations = new List<PrlSCCalculation>();
          //  this.PrlTaxSettlements = new List<PrlTaxSettlement>();
          //  this.PslAbsences = new List<PslAbsence>();
           // this.PslChangeStatus = new List<PslChangeStatu>();
           // this.PslContractsRenewals = new List<PslContractsRenewal>();
          //  this.PslCustodyDetails = new List<PslCustodyDetail>();
          //  this.PslDocumentArchives = new List<PslDocumentArchive>();
          //  this.PslEmployeeCategories = new List<PslEmployeeCategory>();
          //  this.PslEscorts = new List<PslEscort>();
            //this.PslPenalties = new List<PslPenalty>();
            //this.PslSupportTransactions = new List<PslSupportTransaction>();
            //this.PslTerminations = new List<PslTermination>();
            //this.PslTransferedPenalties = new List<PslTransferedPenalty>();
            //this.PslVacations = new List<PslVacation>();
            //this.PslVacationOpeningBalances = new List<PslVacationOpeningBalance>();
            //this.PslVacationTravels = new List<PslVacationTravel>();
            //this.PslVacations1 = new List<PslVacation>();
            //this.GlCustodies = new List<GlCustody>();
            //this.GlCustodies1 = new List<GlCustody>();
            //this.GlCustodies2 = new List<GlCustody>();
            //this.InvTransactions = new List<InvTransaction>();
            //this.TaEmpPaths = new List<TaEmpPath>();
            //this.TaEmpSchedules = new List<TaEmpSchedule>();
            //this.TaPermissions = new List<TaPermission>();
            //this.TaTranslations = new List<TaTranslation>();
            //this.PslMobileRequests = new List<PslMobileRequest>();
            //this.TaEmployeeHolidays = new List<TaEmployeeHoliday>();

            //this.GlChequeBookRecipient = new List<GlChequeBook>();
            //this.GlChequeBookChequeBookUser = new List<GlChequeBook>();

            //  this.TaCancelLates = new List<TaCancelLate>();
            //this.TaEmpAttendanceRules = new List<TaEmpAttendanceRule>();
            //this.TaEmployeeHolidays = new List<TaEmployeeHoliday>();
            //this.TaMachineDatas = new List<TaMachineData>();
            //this.TaMachineContacts = new List<TaMachineContact>();

            //this.TaEmployeeLates = new HashSet<TaEmployeeLate>();
            //this.TaEmployeeOverTimes = new HashSet<TaEmployeeOverTime>();
            //this.TaEmployeeMissions = new HashSet<TaEmployeeMission>();

            //this.TaEmployeeActualWorkingHours = new List<TaEmployeeActualWorkingHour>();
            //this.TaWorkingHoursSystemRules = new List<TaWorkingHoursSystemRule>();
        }


        public long DefEmployeeID { get; set; }
        public long EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNameEN { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string BirthPlaceEN { get; set; }
        public Nullable<int> PslNationalityID { get; set; }
        public Nullable<int> PslSocialStatusID { get; set; }
        public Nullable<int> DefDepartmentID { get; set; }
        public Nullable<int> PslTitleID { get; set; }
        public Nullable<long> DefEmployeeIDReportTo { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<int> PslCareerLevelID { get; set; }
        public Nullable<short> Casual { get; set; }
        public Nullable<short> StaffManager { get; set; }
        public Nullable<short> ServiceChargeStatus { get; set; }
        public Nullable<int> DefBranchID { get; set; }
        public Nullable<int> PslWorkPlaceID { get; set; }
        public Nullable<short> InsuranceStatus { get; set; }
        public Nullable<short> MemberOfHealthInsurance { get; set; }
        public Nullable<System.DateTime> InsuranceDate { get; set; }
        public Nullable<long> InsuranceNo { get; set; }
        public Nullable<int> PslInsuranceOfficeID { get; set; }
        public Nullable<decimal> FixedInsurance { get; set; }
        public Nullable<decimal> VariableInsurance { get; set; }
        public Nullable<short> EmployeeStatus { get; set; }
        public Nullable<int> DefCurrencyID { get; set; }
        public Nullable<decimal> EmployeeNetSalary { get; set; }
        public Nullable<decimal> GrossUpSalary { get; set; }
        public Nullable<decimal> TotalGross { get; set; }
        public Nullable<short> SecurityLevelCode { get; set; }
        public byte[] EmployeePhoto { get; set; }
        public virtual Branch DefBranch { get; set; }
        public virtual DefCurrency DefCurrency { get; set; }
       // public virtual DefDepartment DefDepartment { get; set; }
        public virtual ICollection<DefEmployee> DefEmployee1 { get; set; }
        public virtual DefEmployee DefEmployee2 { get; set; }
        //public virtual ICollection<PrlBonu> PrlBonus { get; set; }
        //public virtual ICollection<PrlDeduction> PrlDeductions { get; set; }
        //public virtual ICollection<PrlInstallmentTransaction> PrlInstallmentTransactions { get; set; }
        //public virtual ICollection<PrlInstallmentTransLine> PrlInstallmentTransLines { get; set; }
        //public virtual ICollection<PrlOtherPayment> PrlOtherPayments { get; set; }
        //public virtual ICollection<PrlPayment> PrlPayments { get; set; }
        //public virtual ICollection<PrlPrepareSummary> PrlPrepareSummaries { get; set; }
        //public virtual ICollection<PrlProfit> PrlProfits { get; set; }
        //public virtual ICollection<PrlSalary> PrlSalaries { get; set; }
        //public virtual ICollection<PrlSCCalculation> PrlSCCalculations { get; set; }
        //public virtual ICollection<PrlTaxSettlement> PrlTaxSettlements { get; set; }
        //public virtual ICollection<PslAbsence> PslAbsences { get; set; }
        //public virtual ICollection<PslChangeStatu> PslChangeStatus { get; set; }
        //public virtual ICollection<PslContractsRenewal> PslContractsRenewals { get; set; }
        //public virtual ICollection<PslCustodyDetail> PslCustodyDetails { get; set; }
        //public virtual ICollection<PslDocumentArchive> PslDocumentArchives { get; set; }
        //public virtual PslEmployee PslEmployee { get; set; }
        //public virtual ICollection<PslEmployeeCategory> PslEmployeeCategories { get; set; }
        //public virtual ICollection<PslEscort> PslEscorts { get; set; }
        //public virtual ICollection<PslPenalty> PslPenalties { get; set; }
        //public virtual ICollection<PslSupportTransaction> PslSupportTransactions { get; set; }
        //public virtual ICollection<PslTermination> PslTerminations { get; set; }
        //public virtual ICollection<PslTransferedPenalty> PslTransferedPenalties { get; set; }
        //public virtual ICollection<PslVacation> PslVacations { get; set; }
        //public virtual ICollection<PslVacationOpeningBalance> PslVacationOpeningBalances { get; set; }
        //public virtual ICollection<PslVacationTravel> PslVacationTravels { get; set; }
        //public virtual ICollection<PslVacation> PslVacations1 { get; set; }
        //public virtual ICollection<GlCustody> GlCustodies { get; set; }
        //public virtual ICollection<GlCustody> GlCustodies1 { get; set; }
        //public virtual ICollection<GlCustody> GlCustodies2 { get; set; }
        //public virtual ICollection<InvTransaction> InvTransactions { get; set; }
        //public virtual ICollection<TaEmpPath> TaEmpPaths { get; set; }
        //public virtual ICollection<TaEmpSchedule> TaEmpSchedules { get; set; }
        //public virtual ICollection<TaPermission> TaPermissions { get; set; }
        //public virtual ICollection<TaTranslation> TaTranslations { get; set; }
        //public virtual PslCareerLevel PslCareerLevel { get; set; }
        //public virtual PslInsuranceOffice PslInsuranceOffice { get; set; }
        //public virtual PslNationality PslNationality { get; set; }
        //public virtual PslSocialStatu PslSocialStatu { get; set; }
        //public virtual PslTitle PslTitle { get; set; }
        //public virtual PslWorkPlace PslWorkPlace { get; set; }

        /// <summary>
        /// is deleted flage employee in service or not
        /// </summary>
        public virtual Nullable<short> IsDeleted { get; set; }

        //public virtual ICollection<GlChequeBook> GlChequeBookRecipient { get; set; }
        //public virtual ICollection<GlChequeBook> GlChequeBookChequeBookUser { get; set; }

        //public virtual ICollection<FaSite> FaSites { get; set; }


        //public virtual ICollection<PslMobileRequest> PslMobileRequests { get; set; }

        // public virtual ICollection<TaCancelLate> TaCancelLates { get; set; }
        //public virtual ICollection<TaEmpAttendanceRule> TaEmpAttendanceRules { get; set; }
        //public virtual ICollection<TaEmployeeHoliday> TaEmployeeHolidays { get; set; }
        //public virtual ICollection<TaMachineData> TaMachineDatas { get; set; } 
        //public ICollection<TaMachineContact> TaMachineContacts { get; set; }

        //public virtual ICollection<TaEmployeeLate> TaEmployeeLates { get; set; }
        //public virtual ICollection<TaEmployeeOverTime> TaEmployeeOverTimes { get; set; }
        //public virtual ICollection<TaEmployeeMission> TaEmployeeMissions { get; set; }

        //public virtual ICollection<TaEmployeeActualWorkingHour> TaEmployeeActualWorkingHours { get; set; }
        //public virtual ICollection<TaWorkingHoursSystemRule> TaWorkingHoursSystemRules { get; set; }
    }
}