namespace TeamBuilder.Data.Configuration
{
    using TeamBuilder.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasOne(iu => iu.InvitedUser)
                   .WithMany(ri => ri.ReceivedInvitations)
                   .HasForeignKey(fk => fk.InvitedUserId);
        }
    }
}