#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderService/Services.Order.Api/Services.Order.Api.csproj", "OrderService/Services.Order.Api/"]
COPY ["OrderService/Services.Order.Repositories/Services.Order.Repositories.csproj", "OrderService/Services.Order.Repositories/"]
COPY ["OrderService/Services.Order.Model/Services.Order.Model.csproj", "OrderService/Services.Order.Model/"]
COPY ["Shared/Services.Shared.Models/Services.Shared.Models.csproj", "Shared/Services.Shared.Models/"]
COPY ["OrderService/Services.Order.Data/Services.Order.Data.csproj", "OrderService/Services.Order.Data/"]
RUN dotnet restore "ContactService/Services.Order.Api/Services.Order.Api.csproj"
COPY . .
WORKDIR "/src/OrderService/Services.Order.Api"
RUN dotnet build "Services.Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.Order.Api.dll"]