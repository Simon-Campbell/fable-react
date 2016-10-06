module ValidationResult
    type ValidationPropertyMessage = {
        Name    : string
        Message : string
    }

    type ValidationResult = 
        | OK
        | Error of seq<ValidationPropertyMessage>