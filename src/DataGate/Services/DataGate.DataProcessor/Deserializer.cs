// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ReportProcessor.DataProcessor
{
    using System.IO;
    using System.Xml.Serialization;

    using ReportProcessor.DataProcessor.ImportDto;

    public class Deserializer
    {
        public static Provider ImportHeaders(string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProviderDto[]),
                                            new XmlRootAttribute(GlobalConstants.XmlRoot));

            var providersDto = (ImportProviderDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var provider = new Provider();

            foreach (var dto in providersDto)
            {
                provider.Id = dto.Provider;
                provider.Title = dto.Title;

                foreach (var headerDto in dto.Headers)
                {
                    provider.Headers.Add(new Header
                    {
                        Name = headerDto.Name.Trim(),
                        Id_TS = headerDto.Id_TS,
                    });
                }
            }

            return provider;
        }
    }
}
