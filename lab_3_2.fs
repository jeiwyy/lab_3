//Найти сумму тех элементов последовательности, в которых встречается заданная цифра.

open System

let rec createSeq () = seq {
    printf "Введите добавляемое значение(не число - конец): "
    let addVal = System.Int32.TryParse(Console.ReadLine())
    match addVal with
    | (true, intVal) -> 
        yield intVal
        yield! createSeq()
    | _ ->
        ()
}

let rec findVal ourInt finVal = 
    let ten = if ourInt >= 0 then 10 else -10
    match ourInt with
    | 0 -> false
    | _ ->
        if finVal = ourInt % ten then 
            true
        else 
            findVal (ourInt / ten) finVal


let sumSeq finVal acc elem = 
    match findVal elem finVal with
    | true -> acc + elem
    | false -> acc

let rec inpFigure () = 
    printf "Введите цифру, которая должна быть в числе: "
    match System.Int32.TryParse(Console.ReadLine()) with
    | (true, x) when x >= 0 && x < 10 -> x
    | _ ->
        printfn "Ошибка ввода."
        inpFigure ()

[<EntryPoint>]
let main args = 
    let ourSeq = createSeq () |> Seq.cache
    printfn "Последовательность: %A" (ourSeq |> Seq.toList)
    let finVal = inpFigure ()
    let sumSeqFold = sumSeq finVal
    let resInt = Seq.fold sumSeqFold 0 ourSeq
    printfn "Сумма чисел содержащие '%i' = %i" finVal resInt
    0