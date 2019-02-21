using System;

namespace Checkout.Models.Audit
{
    public class AuditCreatorModifier
    {
        public DateTime Created { get; set; } = DateTime.Now;

        public long? CreatorId { get; set; }

        public DateTime Updated { get; set; } = DateTime.Now;

        public long? Modified { get; set; }
    }
}