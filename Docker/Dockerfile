FROM mcr.microsoft.com/dotnet/sdk:5.0
# CMD echo 'Hello world from Dockerfile'
WORKDIR /application
COPY . .
RUN dotnet build
# CMD ls -R
EXPOSE 8090
ENV MY=MyLocal
VOLUME /myshare

# See also https://docs.docker.com/samples/aspnet-mssql-compose/
# ENTRYPOINT ["dotnet", "Application.Server/bin/Debug/net5.0/Application.Server.dll"] 
RUN chmod +x Dockerfile-entrypoint.sh
CMD ./Dockerfile-entrypoint.sh