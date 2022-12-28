$ProjectPath = "p5rpc.lib.interfaces/p5rpc.lib.interfaces.csproj"
$publishBuildDirectory = "Publish/Interface/"      # Build directory for current version of the interfaces
  
# Clean anything in existing Release directory.
Remove-Item $publishBuildDirectory -Recurse -ErrorAction SilentlyContinue
New-Item $publishBuildDirectory -ItemType Directory -ErrorAction SilentlyContinue

dotnet restore $ProjectPath
dotnet clean $ProjectPath

dotnet publish $ProjectPath -c Release --self-contained false -o "$publishBuildDirectory" /p:OutputPath="..\$publishBuildDirectory"