<h1 align="center">
	<img src="https://github.com/Chlorine-trifluoride/Auto-CS/raw/master/AutoSDL/media/car_img.png" width="256"/>
	<br/>
	Auto-CS
</h1>

### AutoConsole Build
- Requires .NET Core 3.1
Open AutoConsole.csproj in Visual Studio or from command line:
```bash
dotnet run --configuration Release
```

### AutoSDL Windows Build

- Requirements
	- .NET Core 3.1 SDK
	- SDL2 dlls are included for Windows x64

Open AutoSDL.csproj in Visual Studio or from command line:
```
dotnet run --configuration Release
```

### AutoSDL Linux/Unix Build

AutoSDL depends on three external libraries: libSDL2, libSDL2_image and libSDL2_ttf.
Install them using your package manager.

```bash
apt install libsdl2-2.0-0 libsdl2-image-2.0-0 libsdl2-ttf-2.0-0
```
The post build script tries to add symlink to the libs. If it fails do it manually.

```bash
ln -s /path/to/lib /path/to/build/bin
```

Build and run the program with the following command:
```bash
dotnet run --configuration Release
```