// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.Slug
{
    using Xunit;
    using DataGate.Services.Slug;

    public class SlugGeneratorTests
    {
        [Theory]
        [InlineData(" 20140301 - MULTI STARS SICAV - Central Admin. & Dom. Agreement - MS&PM Lux&UBS - Signed WITHOUT APPENDIX I.pdf")]
        [InlineData("2016 07 13 - PHARUS SICAV - Central Administration Agreement - EDRA & PM Lux & PS - signed.pdf")]
        public void GenerateSlug_ShouldTrimResultTo100Characters(string fileName)
        {
            var slugGenerator = new SlugGenerator();
            var fileNameToDisplay = slugGenerator.Get(fileName);
            Assert.True(fileNameToDisplay.Length <= 100);
        }

        [Fact]
        public void GenerateSlug_ShouldReturnTrimmedResult()
        {
            string fileName =
                "2016 07 13 - PHARUS SICAV - Central Administration Agreement - EDRA & PM Lux & PS - signed.pdf";
            string expected = 
                "2016-07-13-PHARUS-SICAV-Central-Administration-Agreement-EDRA-&-PM-Lux-&-PS-signed.pdf";

            var slugGenerator = new SlugGenerator();
            var actual = slugGenerator.Get(fileName);
            Assert.Equal(expected, actual);
        }
    }
}
