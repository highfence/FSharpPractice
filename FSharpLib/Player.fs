
namespace FSharpLib

open System.Runtime.Serialization

module Player =

    [<DataContract(Name="LOLScore")>]
    type LOLScore = {

        [<field : DataMember(Name="top")>]
        top : int

        [<field : DataMember(Name="jungle")>]
        jungle : int

        [<field : DataMember(Name="mid")>]
        mid : int

        [<field : DataMember(Name="adCarry")>]
        adCarry : int

        [<field : DataMember(Name="support")>]
        support : int
    }

    [<AutoSerializable(true)>]
    [<DataContract(Name="Player")>]
    type Player = {

        [<field : DataMember(Name="name")>]
        name : string

        [<field : DataMember(Name="score")>]
        score : LOLScore
    }
