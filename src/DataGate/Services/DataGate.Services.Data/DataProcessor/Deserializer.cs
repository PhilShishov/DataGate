// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    using DataGate.Common;
    using DataGate.Data.Models.Parameters;
    using DataGate.Web.Dtos.ImportParameters;

    public class Deserializer
    {
        public static List<Parameter> ImportParameters(string type)
        {
            var parametersPath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.Datasets);
            var xmlPath = File.ReadAllText(parametersPath + string.Format(GlobalConstants.XmlParameterFileName, type));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportParameterDto[]),
                                            new XmlRootAttribute(GlobalConstants.XmlRootParameters));

            var parametersDto = (ImportParameterDto[])xmlSerializer.Deserialize(new StringReader(xmlPath));

            var parameters = new List<Parameter>();

            foreach (var dto in parametersDto)
            {
                var parameter = new Parameter
                {
                    Id = dto.Id,
                    Name = dto.Name.Trim(),
                };
                parameters.Add(parameter);
            }

            return parameters;
        }
    }
}
