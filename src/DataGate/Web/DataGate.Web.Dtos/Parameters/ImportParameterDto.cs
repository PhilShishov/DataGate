// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.ImportParameters
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Parameter")]
    public class ImportParameterDto
    {
        [XmlElement("Name")]
        [Required]
        public string Name { get; set; }

        [XmlElement("Id")]
        public int Id { get; set; }
    }
}
