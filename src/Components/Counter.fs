[<RequireQualifiedAccess>]
module Components.Counter

open Browser.Types
open Lit
open Haunted

let private counter (props: {| initial: int option |}) =
    let count, setCount =
        Haunted.useState (defaultArg props.initial 0)

    let messageTpl =
        match count with
        | count when count > 100 ->
            html
                $"""
                <fs-message header="Danger high count!" kind="danger" is-open>
                    <p>I don't want to be that guy but... that's a high count!</p>
                </fs-message>
                """
        | count when count < 0 ->
            html
                $"""
                <fs-message header="Warning low count!" kind="warning" is-open>
                    <p>I don't want to be that guy but... that's a low count!</p>
                </fs-message>
                """
        | _ -> Lit.nothing


    html
        $"""
        <p>Home: {count}</p>
        <button @click={fun _ -> setCount (count + 1)}>Increment</button>
        <button @click={fun _ -> setCount (count - 1)}>Decrement</button>
        <button @click={fun _ -> setCount (defaultArg props.initial 0)}>Reset</button>
        <div @fs-close-message={fun (e: Event) -> (e.target :?> HTMLElement).remove ()}>
            {messageTpl}
        </div>
        """

let register () =
    defineComponent "flit-counter" (Haunted.Component counter)
