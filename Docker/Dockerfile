FROM mcr.microsoft.com/dotnet/sdk:5.0
# CMD echo 'Hello world from Dockerfile'
WORKDIR /application
COPY . .
RUN dotnet build
# CMD ls -R
EXPOSE 8090
ENV MY=MyLocal
# RUN dotnet run --project Application.Cli/Application.Cli.csproj
ENTRYPOINT ["dotnet", "Application.Server/bin/Debug/net5.0/Application.Server.dll"]