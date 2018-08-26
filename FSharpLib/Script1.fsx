#r "System.Runtime.Serialization.dll"

open System.Collections.Generic

#load "Player.fs"
#load "IO.fs"

open FSharpLib
open Player

let binaryDumpPath = @"D:\Dev\BinaryDump.txt";

let score = { top = 9; jungle = 8; mid = 6; adCarry = 4; support = 7; }
let player = { name = "hide on bush"; score = score; }

let json = Json.Serialize(player);

printfn "%A" json

let clone = Json.Deserialize<Player>(json);

let binary = Binary.SerializeToFile<Player>(binaryDumpPath, player)

printfn "Okay"
let readDump = Binary.DeserializeFromFile<Player>(binaryDumpPath);