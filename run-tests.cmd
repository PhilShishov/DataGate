dotnet test "src\DataGate\Tests\DataGate.Services.Data.Tests\DataGate.Services.Data.Tests.csproj" --configuration Release--no-build

dotnet test "src\DataGate\Tests\DataGate.Services.Tests\DataGate.Services.Tests.csproj" --configuration Release--no-build --filter "Category!=A"