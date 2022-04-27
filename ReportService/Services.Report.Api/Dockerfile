#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReportService/Services.Report.Api/Services.Report.Api.csproj", "ReportService/Services.Report.Api/"]
COPY ["Shared/Services.Shared.Authentication.Client/Services.Shared.Authentication.Client.csproj", "Shared/Services.Shared.Authentication.Client/"]
COPY ["Shared/Services.Shared.Models/Services.Shared.Models.csproj", "Shared/Services.Shared.Models/"]
COPY ["ReportService/Services.Report.EventBus/Services.Report.EventBus.csproj", "ReportService/Services.Report.EventBus/"]
COPY ["ReportService/Services.Report.Services/Services.Report.Services.csproj", "ReportService/Services.Report.Services/"]
COPY ["Shared/Services.Shared.Authentication.Helper/Services.Shared.Authentication.Helper.csproj", "Shared/Services.Shared.Authentication.Helper/"]
COPY ["ContactService/Services.Contact.Client/Services.Contact.Client.csproj", "ContactService/Services.Contact.Client/"]
COPY ["Shared/Services.Shared.Client/Services.Shared.Client.csproj", "Shared/Services.Shared.Client/"]
COPY ["ContactService/Services.Contact.Model/Services.Contact.Model.csproj", "ContactService/Services.Contact.Model/"]
COPY ["Shared/Services.Shared.EventBus/Services.Shared.EventBus.csproj", "Shared/Services.Shared.EventBus/"]
COPY ["ReportService/Services.Report.Repositories/Services.Report.Repositories.csproj", "ReportService/Services.Report.Repositories/"]
COPY ["Shared/Services.Shared.Data/Services.Shared.Data.csproj", "Shared/Services.Shared.Data/"]
COPY ["ReportService/Services.Report.Data/Services.Report.Data.csproj", "ReportService/Services.Report.Data/"]
COPY ["ReportService/Services.Report.Model/Services.Report.Model.csproj", "ReportService/Services.Report.Model/"]
RUN dotnet restore "ReportService/Services.Report.Api/Services.Report.Api.csproj"
COPY . .
WORKDIR "/src/ReportService/Services.Report.Api"
RUN dotnet build "Services.Report.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.Report.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.Report.Api.dll"]