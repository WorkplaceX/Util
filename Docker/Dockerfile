FROM mcr.microsoft.com/dotnet/sdk:5.0
# CMD echo 'Hello world from Dockerfile'
WORKDIR /src
COPY . .
RUN dotnet build
# CMD ls -R
EXPOSE 8090
ENV MY=MyLocal
ENTRYPOINT ["dotnet", "bin/Debug/net5.0/ConsoleApp.dll"]