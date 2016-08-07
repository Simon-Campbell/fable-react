module FableReact
    open System

    open Fable.Core
    open Fable.Import

    open UserDetails

    // Ensure that newer JS langiage shims are available for older 
    // browsers
    Node.require.Invoke("core-js") |> ignore

    module R = Fable.Helpers.React

    let user = { 
                Id = 0
                FirstName = "Simon"
                LastName = "Campbell" 
                BirthDate = DateTime.Now }
    
    let props = { Default = user }

    ReactDom.render(
        // R.com is rendering a React component, this was a bug bear where
        // it was hard to discover this API
        R.com<UserDetails.Form, _, _> props [], 
        Browser.document.getElementById "main"
    ) |> ignore