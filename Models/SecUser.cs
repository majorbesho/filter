using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class SecUser
    {
        public SecUser()
        {
            //this.SecUserAllowedDeniedPrivileges = new List<SecUserAllowedDeniedPrivilege>();
            //this.SecUserGroups = new List<SecUserGroup>();
            //this.SecUserBranchs = new List<SecUserBranch>();
            //this.SecUserOwnershipUsers = new List<SecUserOwnershipUsers>();
            //this.SecUserOwnershipUsers1 = new List<SecUserOwnershipUsers>();
        }

        public long SecUserID { get; set; }
        public long UserNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public Nullable<long> ResponsibleID { get; set; }
        public Nullable<System.DateTime> LastPasswordChangeDate { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> FailedPasswordAttemptCount { get; set; }
        public Nullable<System.DateTime> FailedPasswordAttemptedWindowStart { get; set; }
        public Nullable<int> FailedPasswordAnswerAttemptCount { get; set; }
        public Nullable<System.DateTime> FailedPasswordAnswerAttemptStart { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public string NotesEN { get; set; }
        public bool IsAllowedToOverride { get; set; }
        public bool IsAllowedToShowOthersFilled { get; set; }
        public short UserType { get; set; }
        public Nullable<bool> IsUserUseEServicesOnly { get; set; }

        //public virtual ICollection<SecUserAllowedDeniedPrivilege> SecUserAllowedDeniedPrivileges { get; set; }
        //public virtual ICollection<SecUserGroup> SecUserGroups { get; set; }
        //public virtual ICollection<SecUserBranch> SecUserBranchs { get; set; }
        //public virtual ICollection<SecUserOwnershipUsers> SecUserOwnershipUsers { get; set; }
        //public virtual ICollection<SecUserOwnershipUsers> SecUserOwnershipUsers1 { get; set; }
        /// <summary>
        /// is user change pss word or not
        /// this option use when create default pass word for employee request by Eng.Mahoumd 2015.12 Development by Kerollos Adel 2015.12.09
        /// </summary>
        public Nullable<bool> IsUserChangePassword { get; set; }

        public Nullable<System.DateTime> ConfirmationCodeLastSendingDate { get; set; }
        public Nullable<System.Int16> ConfirmationCodeIsConfirmed { get; set; }
        public System.String ConfirmationCode { get; set; }
        public Nullable<Int32> ConfirmationCodeNumberOfSending { get; set; }
    }
}