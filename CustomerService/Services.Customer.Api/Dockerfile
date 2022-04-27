#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomerService/Services.Customer.Api/Services.Customer.Api.csproj", "CustomerService/Services.Customer.Api/"]
COPY ["CustomerService/Services.Customer.Repositories/Services.Customer.Repositories.csproj", "CustomerService/Services.Customer.Repositories/"]
COPY ["CustomerService/Services.Customer.Model/Services.Customer.Model.csproj", "CustomerService/Services.Customer.Model/"]
COPY ["Shared/Services.Shared.Models/Services.Shared.Models.csproj", "Shared/Services.Shared.Models/"]
COPY ["CustomerService/Services.Customer.Data/Services.Customer.Data.csproj", "CustomerService/Services.Customer.Data/"]
RUN dotnet restore "CustomerService/Services.Customer.Api/Services.Customer.Api.csproj"
COPY . .
WORKDIR "/src/CustomerService/Services.Customer.Api"
RUN dotnet build "Services.Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.Customer.Api.dll"]