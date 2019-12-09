using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class SecUserMap : EntityTypeConfiguration<SecUser>
    {
        public SecUserMap()
        {
            // Primary Key
            this.HasKey(t => t.SecUserID);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.PasswordQuestion)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.PasswordAnswer)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Email)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("SecUser");
            this.Property(t => t.SecUserID).HasColumnName("SecUserID");
            this.Property(t => t.UserNumber).HasColumnName("UserNumber");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.PasswordQuestion).HasColumnName("PasswordQuestion");
            this.Property(t => t.PasswordAnswer).HasColumnName("PasswordAnswer");
            this.Property(t => t.ResponsibleID).HasColumnName("ResponsibleID");
            this.Property(t => t.LastPasswordChangeDate).HasColumnName("LastPasswordChangeDate");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.LastLoginDate).HasColumnName("LastLoginDate");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            this.Property(t => t.FailedPasswordAttemptCount).HasColumnName("FailedPasswordAttemptCount");
            this.Property(t => t.FailedPasswordAttemptedWindowStart).HasColumnName("FailedPasswordAttemptedWindowStart");
            this.Property(t => t.FailedPasswordAnswerAttemptCount).HasColumnName("FailedPasswordAnswerAttemptCount");
            this.Property(t => t.FailedPasswordAnswerAttemptStart).HasColumnName("FailedPasswordAnswerAttemptStart");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.NotesEN).HasColumnName("NotesEN");
            this.Property(t => t.IsAllowedToOverride).HasColumnName("IsAllowedToOverride");
            this.Property(t => t.IsAllowedToShowOthersFilled).HasColumnName("IsAllowedToShowOthersFilled");
            this.Property(t => t.IsUserUseEServicesOnly).HasColumnName("IsUserUseEServicesOnly");
            this.Property(t => t.UserType).HasColumnName("UserType");
            this.Property(t => t.IsUserChangePassword).HasColumnName("IsUserChangePassword");
            this.Property(t => t.ConfirmationCode).HasColumnName("ConfirmationCode");
            this.Property(t => t.ConfirmationCodeNumberOfSending).HasColumnName("ConfirmationCodeNumberOfSending");
            this.Property(t => t.ConfirmationCodeIsConfirmed).HasColumnName("ConfirmationCodeIsConfirmed");
            this.Property(t => t.ConfirmationCodeLastSendingDate).HasColumnName("ConfirmationCodeLastSendingDate");


        }
    }
}