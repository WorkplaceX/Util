# Docker
Docker console app listening on port 8090 and MS-SQL Express Database.

## Build
```cmd
docker build . --tag myapp
```

Console app with database:
```cmd
docker-compose up
```

## Setup
Enable Docker Desktop WSL 2 Backend

Enable nested virtualization. Run on physical Hype-V host:
```cmd
Set-VMProcessor -VMName "Windows 10 Development" -ExposeVirtualizationExtensions $true
```

Increase memory

See also: https://docs.microsoft.com/en-us/virtualization/hyper-v-on-windows/user-guide/nested-virtualization
