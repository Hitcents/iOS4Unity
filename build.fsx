#r @"packages/FAKE.3.5.4/tools/FakeLib.dll"
#load "build-helpers.fsx"
open Fake
open System
open System.IO
open System.Linq
open BuildHelpers
open Fake.XamarinHelper

let version = "1.0.0"
let project = "iOS4Unity"
let files = [|"Assets/Plugins/iOS4Unity/iOS4Unity.dll"; "Assets/Plugins/iOS4Unity/Examples.cs"; "Assets/Plugins/iOS4Unity/Examples.unity"|]
let projectInUnity = "Assets/" + project

Target "clean" (fun () ->
    if not(Directory.Exists(projectInUnity)) then
        Exec "git" "reset --hard HEAD"
        Exec "git" "clean -d -f"
)

Target "dll" (fun () ->
    let output = Path.Combine(project, "bin", "Release")
    let csproj = Path.Combine(project, project + ".csproj")
    MSBuild output "Build" [ ("Configuration", "Release") ] [ csproj ] |> ignore
)

Target "unity" (fun () ->
    Exec "rm" ("-Rf " + projectInUnity)
    Exec "cp" (Path.Combine(project, "bin", "Release", (project + ".dll")) + " Assets/Plugins/iOS4Unity")
    Unity(String.Join(" ", files))
)

"clean" ==> "dll"
"dll" ==> "unity"

RunTarget()
