
namespace FSharpLib

open System.IO
open System.Runtime.Serialization.Formatters.Binary
open System.Runtime.Serialization.Json
open System.Collections.Generic

module IOCommon = 

    let ToString = System.Text.Encoding.UTF8.GetString
    let ToBytes (x : string) = System.Text.Encoding.UTF8.GetBytes x


module Json =

    let Serialize<'a> (x : 'a) =
        let jsonSerializer = new DataContractJsonSerializer(typedefof<'a>)

        use stream = new MemoryStream()
        jsonSerializer.WriteObject(stream, x)
        IOCommon.ToString <| stream.ToArray()

    let Deserialize<'a> (json : string) =
        let jsonSerializer = new DataContractJsonSerializer(typedefof<'a>)

        use stream = new MemoryStream(IOCommon.ToBytes json)
        jsonSerializer.ReadObject(stream) :?> 'a

    let SerializeToFile<'a> (filePath : string, x : 'a) = 

        let jsonFile = Serialize<'a>(x)
        File.WriteAllText(filePath, jsonFile) |> ignore


module Binary = 

    open System.Runtime.InteropServices
    open Player

    let Serialize<'a> (x : 'a) =
        let binFormatter = new BinaryFormatter()

        use stream = new MemoryStream()
        binFormatter.Serialize(stream, x)
        stream.ToArray()

    let Deserialize<'a> (arr : byte[]) : 'a = 
        let binFormatter = new BinaryFormatter()

        use stream = new MemoryStream()
        binFormatter.Deserialize(stream) :?> 'a
        
    let SerializeToFile<'a> (filePath : string, x : 'a) =

        let binaryFile = Serialize<'a>(x)
        File.WriteAllBytes(filePath, binaryFile) |> ignore

    let DeserializeFromFile<'a> (filePath : string) : List<'a>  =

        let byteStream = File.OpenRead(filePath)
        let ret = new List<'a>() 

        use reader = new BinaryReader(byteStream, System.Text.Encoding.UTF8)
        // TODO : 여기서부터 작업 시작
        ret

            
       


        

