// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.ShareClasses
{
    using DataGate.Services.Mapping;

    public class ShareClassForeignKeysDto : IMapFrom<EditShareClassInputModel>, IMapFrom<CreateShareClassInputModel>
    {
        public string Status { get; set; }

        public string InvestorType { get; set; }

        public string ShareType { get; set; }

        public string CountryIssue { get; set; }

        public string CountryRisk { get; set; }
    }
}
