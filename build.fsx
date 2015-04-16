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
let projectInUnity = Path.Combine("Assets", project)
let examples = Path.Combine("Assets", "Examples")
let provisioningId = "eceff215-f35c-45a6-bed8-09bb562401e9"
let provisioningName = "GenericInHouse"

Target "clean" (fun () ->
    Exec "git" "reset --hard HEAD"
    Exec "git" "clean -d -f"
)

Target "dll" (fun () ->
    let output = Path.Combine(project, "bin", "Release")
    let csproj = Path.Combine(project, project + ".csproj")
    MSBuild output "Build" [ ("Configuration", "Release") ] [ csproj ] |> ignore
)

Target "ios-player" (fun () ->
    Unity "-executeMethod BuildScript.iOS"
)
 
Target "ios64-player" (fun () ->
    Unity "-executeMethod BuildScript.iOS64"
)

Target "ios-archive" (fun () ->
    DeleteDir ("Scratch/Xcode/" + project + ".xarchive/")
    Xcode ("-project Scratch/Xcode/Unity-iPhone.xcodeproj -scheme Unity-iPhone archive -archivePath Scratch/Xcode/" + project + " PROVISIONING_PROFILE=" + provisioningId)
)

Target "tests" (fun () ->
    CreateDir "build"
    DeleteFile ("build/" + project + ".ipa")
    Xcode ("-exportArchive -archivePath Scratch/Xcode/" + project + ".xcarchive -exportPath build/" + project + ".ipa -exportProvisioningProfile " + provisioningName)
    TeamCityHelper.PublishArtifact (project + ".ipa")
)

Target "tests-64" (fun () ->
    CreateDir "build"
    DeleteFile ("build/" + project + ".ipa")
    Xcode ("-exportArchive -archivePath Scratch/Xcode/" + project + ".xcarchive -exportPath build/" + project + "-64.ipa -exportProvisioningProfile " + provisioningName)
    TeamCityHelper.PublishArtifact (project + "-64.ipa")
)

Target "unity" (fun () ->
    CleanDir projectInUnity
    File.Copy(Path.Combine(project, "bin", "Release", project + ".dll"), Path.Combine(projectInUnity, project + ".dll"))
    Copy projectInUnity (Directory.GetFiles(examples))
    CleanDir examples
    UnityPackage projectInUnity
)

"ios-archive" ==> "tests"
"ios-archive" ==> "tests-64"
"dll" ==> "unity"

RunTarget()
