// Utility interface for creating table model

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Utilities.Services
{
    using System.Data.SqlClient;
    using System.Collections.Generic;

    public interface ICreateModel
    {
        List<string[]> Model { get; set; }

        List<string[]> CreateModelWithHeadersAndValue(SqlCommand command);
    }
}
