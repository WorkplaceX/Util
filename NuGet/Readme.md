# Add and Consume Content Files (*.html; *.css) with NuGet in .NET Core
With NuGet it is possible to package and distribute content files similar to npm package manager. The following steps show how to add and consume a content folder.

In the (*.csproj) add the following three lines of code. It adds MyContent folder to the class library that should be packet as a (*.nupkg) file. Then create the package by running Pack.

```xml
<ItemGroup>
  <None Include="MyContent\**" Pack="true" />
</ItemGroup>
```

![Add content folder to NuGet](Doc/NuGetPackage.png)

## How does NuGet internally store files?
To verify files are packet into NuGet as expected rename any (*.nupkg) file to (*.nupkg.zip) and open it.
![Unzip NuGet package](Doc/NuGetZip.png)

## Unlock Content Files (*.html; *.css) in Consuming Application
In the consuming application add the (*.nupkg) file. This alone however is not enough. Unlike npm for NuGet the consumer explicitly has to unlock the content files. In our example the MyContent folder.
* First set Generate Path Property of the referenced package to Yes
* Second add the following three lines to the consuming (*.csproj) file

```xml
<ItemGroup>
  <None Include="$(PkgClassLibrary)\content\**">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

![Unlock content files from NuGet package in consuming application](Doc/NuGetPackageUnlockContent.png)

After building the application the content folder MyContent is in the destination build output folder bin\Debug

![Consuming application with content folder from NuGet package in build output folder](Doc/BuildOutput.png)
