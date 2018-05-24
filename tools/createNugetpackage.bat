cd ..\src\Torken.ORMRepository.EntityFramework
dotnet pack -o "../../tools"

cd ..\Torken.ORMRepository.Core
dotnet pack -o "../../tools"

cd ..\Torken.ORMRepository.Interfaces
dotnet pack -o "../../tools"