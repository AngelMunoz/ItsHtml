[<RequireQualifiedAccess>]
module App

open Browser.Types
open Sutil
open Sutil.Attr
open Sutil.DOM
open Sutil.Styling

open Types

open type Fs
open type FsAttrs

open Pages.Notes
open Components.Icons


let private tabItemTemplate item =
    fsTabItem [
        fsTabItemLabel item.label
        fsTabItemTabName item.id
        fsKind item.kind
    ]

let private getPage page =
    match page with
    | Page.Home -> Html.custom ("flit-home", [])
    | Page.Notes -> Notes()

let private onTabSelected page (ev: CustomEvent<{| tabName: string |}>) =
    let tabName =
        ev.detail
        |> Option.map (fun i -> i.tabName)
        |> Option.defaultValue "home"

    match tabName with
    | "notes" -> page <~ Page.Notes
    | "home"
    | _ -> page <~ Page.Home

let private offCanvasItemTemplate page item =

    let onSelected newPage _ = page <~ newPage

    let getPage id =
        match id with
        | "home" -> Page.Home
        | "notes" -> Page.Notes
        | _ -> Page.Home

    Html.li [
        onClick (onSelected (getPage item.id)) []
        Html.a [ Html.text item.label ]
    ]

let private menuStyle =
    rule
        "app-icon[name=menu]"
        [ Css.floatRight
          Css.cursorPointer
          Css.height (32)
          Css.width (32) ]

let private app () =
    let page = Store.make Page.Home
    let menuOpen = Store.make false

    let entries =
        Store.make (
            [ { label = "Home"
                id = "home"
                kind = Link }
              { label = "Notes"
                id = "notes"
                kind = Link } ]
        )

    Html.app [
        disposeOnUnmount [ page; entries ]
        Html.article [
            fsOffCanvas [
                on "fs-close-off-canvas" (fun _ -> menuOpen <~ false) []
                closable true
                Html.h3 [
                    Attr.slot "header-text"
                    Html.text "Type Safe components and seamless interop!"
                ]
                Bind.each (entries, offCanvasItemTemplate page)
                Bind.attr ("isOpen", menuOpen)
            ]
            Html.custom (
                "app-icon",
                [ Attr.name $"{Menu}"
                  onClick (fun _ -> menuOpen <~ true) [] ]
            )
            fsTabHost [
                fsKind Link
                onCustomEvent "on-fs-tab-selected" (onTabSelected page) []
                Html.nav [
                    Attr.slot "tabs"
                    Bind.each (entries, tabItemTemplate)
                ]
                Bind.el page getPage
            ]
        ]
    ]
    |> withStyle [
        rule "a" [ Css.cursorPointer ]
        menuStyle
       ]

let start () =
    Program.mountElement "sutil-app" (app ())
