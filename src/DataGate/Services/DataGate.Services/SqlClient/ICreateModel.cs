// Utility interface for creating table model

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.SqlClient
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public interface ICreateModel
    {
        List<string[]> Model { get; set; }

        List<string[]> CreateModelWithHeadersAndValue(SqlCommand command);
    }
}
