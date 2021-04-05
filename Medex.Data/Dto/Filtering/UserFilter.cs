using Medex.Data.Dto.Base;
using Medex.Data.Dto.Base.Filtering;
using System;

namespace Medex.Data.Dto.Filtering
{
    public class UserFilter : BaseFilter
    {
        public FilterDescriptor<string> FullName { get; set; }
        public FilterDescriptor<string> Email { get; set; }
        public FilterDescriptor<string> Login { get; set; }
        public FilterDescriptor<string> Phone { get; set; }
        public FilterDescriptor<bool> IsConfirmed { get; set; }
        public FilterDescriptor<bool> IsEmailSent { get; set; }
        public FilterDescriptor<Nullable<DateTime>> CreatedOn { get; set; }
        public FilterDescriptor<NamedObject> UserRole { get; set; }
    }
}
