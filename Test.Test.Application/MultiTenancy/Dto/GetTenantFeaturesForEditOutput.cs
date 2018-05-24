using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Test.Test.Editions.Dto;

namespace Test.Test.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}