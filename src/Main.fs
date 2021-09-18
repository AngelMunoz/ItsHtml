module Main

open Fable.Core.JsInterop
open Pages
open Components

importSideEffects "./styles.css"
let registerAll: unit -> unit = importMember "fsharp-components"

registerAll ()

// register your custom elements here
Home.register ()
Counter.register ()
Icons.register ()
App.start ()
