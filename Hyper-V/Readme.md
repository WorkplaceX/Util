# Shrink (*.vhd) File

Run CMD as Administrator

```cmd
diskpart
select vdisk file="C:\my.vhd"
attach vdisk readonly
compact vdisk
detach vdisk
```

# Add (*.vhdx) to Windows Dual Boot
* Shutdown virtual machine 
* Open Disk Management
* Click Action > Attach VHD
* Select (*.vhdx) file.
* New Disk F: is shown
* Open cmd as admin

```cmd
bcdboot F:\Windows
```

Restart PC. Dual boot is shown. Remove it again by clicking delete in "System Configuration".

Show dual boot
```cmd
bcdedit
```

# Install Windows with Windows PE
## Technician PC
- Install Windows ADK
- Install Windows PE add-on for the Windows ADK
```cmd
C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools>copype amd64 C:\Temp\PE
// Extract Win11_English_x64v1.iso to C:\Temp\PE\media\My\Win11
C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools>MakeWinPEMedia /ISO C:\Temp\PE C:\Temp\PE.iso
```

## Destination PC
Hyper-V Generation 2; 8192 Memory; 64 GB Disk; Security Tab enable TPM; Processor 12;

DISKPART
```cmd
select disk 0
convert gpt
create partition primary
format fs=ntfs
assign
exit
``` 

```cmd
dism /Get-ImageInfo /ImageFile:D:\My\Win11\sources\install.wim
DISM /Apply-Image /Imagefile:D:\My\Win11\sources\install.wim /Index:6 /ApplyDir:C:
Wpeutil Shutdown
```

## ToDo
D:\My\Win11\setup.exe
DISM /Apply-Image /Imagefile:D:\My\Win11\sources\install.wim /Index:6 /ApplyDir:C:
dism /Mount-image /Imagefile:D:\My\Win11\sources\install.wim /Index:6 /MountDir:C:\

create partition primary size=100
select partition 1
format fs=ntfs quick label=system
active

create partition primary
select partition 2
format fs=ntfs quick label=windows
assign letter=C

C:\Windows\System32\bcdboot C:\Windows
C:\Windows\System32\bcdboot C:\Windows /s S: /f ALL
