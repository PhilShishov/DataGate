// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Timelines
{
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;
    using Ganss.XSS;

    public class TimelineViewModel : IMapFrom<TimelineDto>
    {
        public int Id { get; set; }

        public string InitialDate { get; set; }

        public string EndDate { get; set; }

        public string Comment { get; set; }

        public string Title { get; set; }

        public string SanitizedComment => new HtmlSanitizer().Sanitize(this.Comment);
    }
}
