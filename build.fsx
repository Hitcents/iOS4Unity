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
let files = [|"Assets/iOS4Unity.dll"|]
let projectInUnity = "Assets/" + project

Target "clean" (fun () ->
    Exec "rm" "-Rf iOS4Unity/bin iOS4Unity/obj Assets/iOS4Unity.dll Assets/iOS4Unity.dll.meta iOS4Unity.unityPackage"
    if not(Directory.Exists(projectInUnity)) then
        Exec "git" "reset --hard HEAD"
)

Target "dll" (fun () ->
    let output = Path.Combine(project, "bin", "Release")
    let csproj = Path.Combine(project, project + ".csproj")
    MSBuild output "Build" [ ("Configuration", "Release") ] [ csproj ] |> ignore
)

Target "unity" (fun () ->
    Exec "rm" ("-Rf " + projectInUnity)
    Exec "cp" (Path.Combine(project, "bin", "Release", (project + ".dll")) + " Assets/")
    Unity(String.Join(" ", files))
)

"clean" ==> "dll"
"dll" ==> "unity"

RunTarget()
