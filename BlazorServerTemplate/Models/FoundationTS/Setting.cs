using System;
using System.Collections.Generic;

namespace BlazorServerTemplate.Models.FoundationTS
{
    public partial class Setting
    {
        public int? PartyStatusCodeCountLimit { get; set; }
        public bool? ProcessTimeEntries { get; set; }
        public bool? ProcessImages { get; set; }
        public int? RelatedPartyCountLimit { get; set; }
        public DateTime? MatterDateLimit { get; set; }
        public DateTime? TimeEntryBeginDate { get; set; }
    }
}
