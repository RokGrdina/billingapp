using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingApp.DAL
{
    public class BillingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BillingContext>
    {
        protected override void Seed(BillingContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_Sender UNIQUE(SenderCompanyId)");
            context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_Reciever UNIQUE(RecieverCompanyId)");
            context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_StartingLocation UNIQUE(StartingLocationId)");
            context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_EndingLocation UNIQUE(EndingLocationId)");
            base.Seed(context);
        }
    }
}