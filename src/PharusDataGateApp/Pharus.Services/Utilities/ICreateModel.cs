
namespace Pharus.Services.Utilities
{
    using System.Data.SqlClient;
    using System.Collections.Generic;

    public interface ICreateModel
    {
        List<string[]> Model { get; set; }

        List<string[]> CreateModelWithHeadersAndValue(SqlCommand command);
    }
}
