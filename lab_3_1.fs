// Получить список из длин строк, содержащихся в исходной последовательности
open System

let rec readSequence () = seq {
    printf "Введите добавляемое значение (ctrl+d(z) - конец): "
    let addVal = Console.ReadLine()
    if addVal <> null then
        yield addVal
        yield! readSequence()
}

[<EntryPoint>]
let main args = 
    printfn "Создание последовательности: "
    let ourSeq = readSequence()
    let resSeq = 
        ourSeq 
        |> Seq.map String.length 
        |> Seq.cache
    printfn "Исходная последовательность: %A" (ourSeq |> Seq.toList)
    printfn "Список длин строк: %A" (resSeq |> Seq.toList)
    0