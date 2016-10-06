module UserDetails
    open System
    
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Import
    open Fable.Import.Browser
    open Fable.Import.React
    open Fable.Helpers.React.Props

    open ValidationResult

    module R = Fable.Helpers.React

    type UserDetails = {
        Id : int
        FirstName : string
        LastName : string
        BirthDate : System.DateTime
    }

    type FormProps = {
        Default : UserDetails
    }

    let validateErrors entity =
        let err name msg =
            {   Name = name; 
                Message = msg }

        seq {
            if entity.FirstName |> Seq.isEmpty then  yield err "FirstName" "No first name"
            if entity.LastName |> Seq.isEmpty then yield err "LastName" "No last name"
        }

    // It would be interesting to re-use this logic both client 
    // side and server side. No reason why it shouldn't be possible
    let validate entity =
        let errors = validateErrors entity
        if errors |> Seq.isEmpty then ValidationResult.OK
        else ValidationResult.Error errors 


    let validateCss state field =
        match validate state with
            | ValidationResult.Error(x) -> 
                if x |> Seq.exists(fun y -> y.Name = field) 
                    then "error" 
                    else "ok"

            | ValidationResult.OK -> "ok"

    // This is the key react magic where I define a React component. The
    //  target?value is provided by Fable.Core.JsInterop
    type Form(props, ctx) as this = 
        inherit Component<FormProps, UserDetails>(props, ctx)
        do this.state <- props.Default

        member this.updateFirstName (e: React.FormEvent)  =
            this.setState({ this.state with FirstName = string e.target?value })

        member this.updateLastName (e: React.FormEvent) = 
            this.setState({ this.state with LastName = string e.target?value})

        member this.updateBirthDate (e: React.FormEvent) = 
            this.setState({ this.state with BirthDate = DateTime.Parse(string e.target?value) } )

        member this.render () =
            let validateCurrent = 
                validateCss this.state

            // Markup can be done using a DSL instead of using JSX
            R.div [] [
                R.input [ 
                    ClassName (validateCurrent "FirstName")
                    // This U2.Case1 constructor is not easily discoverable. I am 
                    //still not sure why it is neccesary
                    Value (U2.Case1 this.state.FirstName)
                    OnChange this.updateFirstName ] [ ];
                R.input [
                    ClassName (validateCurrent "LastName")
                    Value (U2.Case1 this.state.LastName)
                    OnChange this.updateLastName ] [ ];
                R.input [ 
                    ClassName (validateCurrent "BirthDate")
                    Value (U2.Case1 (this.state.BirthDate.ToString()) ) 
                    OnChange this.updateBirthDate ] [ ]
            ]