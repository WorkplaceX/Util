# Docker

Enable Docker Desktop WSL 2 Backend

Enable nested virtualization. Run on physical Hype-V host:
```cmd
Set-VMProcessor -VMName "Windows 10 Development" -ExposeVirtualizationExtensions $true
```

See also: https://docs.microsoft.com/en-us/virtualization/hyper-v-on-windows/user-guide/nested-virtualization
