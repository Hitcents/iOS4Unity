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
let files = [|"Assets/Plugins/iOS4Unity.dll"|]
let cleanFiles = [|
  "iOS4Unity/bin";
  "iOS4Unity/obj";
  "Assets/Plugins";
  "Assets/Plugins.meta"
  "iOS4Unity.unityPackage"
|]
let projectInUnity = "Assets/" + project

Target "clean" (fun () ->

    for file in cleanFiles do
        if File.Exists(file) then
            File.Delete(file)
        else if Directory.Exists(file) then
            Directory.Delete(file, true)

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
    Exec "mkdir" "Assets/Plugins"
    Exec "cp" (Path.Combine(project, "bin", "Release", (project + ".dll")) + " Assets/Plugins")
    Unity(String.Join(" ", files))
)

"clean" ==> "dll"
"dll" ==> "unity"

RunTarget()
