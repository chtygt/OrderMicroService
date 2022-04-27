#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductService/Services.Product.Api/Services.Product.Api.csproj", "ProductService/Services.Product.Api/"]
COPY ["ProductService/Services.Product.Repositories/Services.Product.Repositories.csproj", "ProductService/Services.Product.Repositories/"]
COPY ["ProductService/Services.Product.Model/Services.Product.Model.csproj", "ProductService/Services.Product.Model/"]
COPY ["Shared/Services.Shared.Models/Services.Shared.Models.csproj", "Shared/Services.Shared.Models/"]
COPY ["ProductService/Services.Product.Data/Services.Product.Data.csproj", "ProductService/Services.Product.Data/"]
RUN dotnet restore "ProductService/Services.Product.Api/Services.Product.Api.csproj"
COPY . .
WORKDIR "/src/ProductService/Services.Product.Api"
RUN dotnet build "Services.Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.Product.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.Product.Api.dll"]