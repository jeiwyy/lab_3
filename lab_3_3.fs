//Вывести самое длинное название файла в указанном каталоге.
open System
open System.IO

let rec inpDir () = 
    printf "Введите путь к каталогу: "
    let ourDir = Console.ReadLine()
    let extName elem =
        let i = String.length(elem)
        elem[String.length(ourDir)..i]
    if Directory.Exists(ourDir) then
        let dirSeq =
            Directory.EnumerateFiles ourDir
            |> Seq.map extName
        dirSeq
    else 
        printfn "Такая директория не найдена, попробуйте еще раз"
        inpDir ()

let finMax acc elem =
    if String.length(elem) > String.length(acc) then
        elem
    else
        acc

[<EntryPoint>]
let main args =
    let dirSeq = inpDir ()
    let result = Seq.fold finMax "" dirSeq
    printfn "Самая длинное название: %s" result
    0
