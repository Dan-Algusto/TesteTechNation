#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TesteTechNation/TesteTechNation.csproj", "TesteTechNation/"]
RUN dotnet restore "TesteTechNation/TesteTechNation.csproj"
COPY . .
WORKDIR "/src/TesteTechNation"
RUN dotnet build "TesteTechNation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteTechNation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteTechNation.dll"]

# Copiar o script SQL para o container
COPY criar_tabelas.sql /tmp/criar_tabelas.sql

# Configurar o ponto de entrada para executar o script SQL e iniciar o aplicativo
ENTRYPOINT ["dotnet", "TesteTechNation.dll"]
CMD ["/opt/mssql-tools/bin/sqlcmd", "-S", "localhost", "-U", "sa", "-i", "/tmp/criar_tabelas.sql"]
