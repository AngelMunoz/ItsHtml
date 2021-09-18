[<AutoOpen>]
module Bindings

open Sutil
open Types

module FsAttrs =
    let inline slot name = Attr.custom ("is-open", name)

    let inline isOpen (isOpen: bool) =
        Attr.custom ("is-open", (if isOpen then "true" else ""))

    let inline closable (closable: bool) =
        Attr.custom ("closable", (if closable then "true" else ""))

    let inline isSelected (isSelected: bool) =
        Attr.custom ("is-selected", (if isSelected then "true" else ""))

    let inline isClosable (isClosable: bool) =
        Attr.custom ("is-closable", (if isClosable then "true" else ""))

    let inline fsTabItemLabel (label: string) = Attr.custom ("label", label)

    let inline fsTabItemTabName (label: string) =
        Attr.custom ("tab-name", label)

    let inline fsMsgHeader (label: string) = Attr.custom ("header", label)

    let inline fsOffCanvasNoOverlay (noOverlay: bool) =
        Attr.custom ("header", (if noOverlay then "true" else ""))

    let inline fsOffCanvasPosition (position: OffcanvasPosition) =
        let pos =
            match position with
            | Left -> "left"
            | Right -> "right"

        Attr.custom ("position", pos)

    let inline fsKind (value: Kind) =
        let kind =
            match value with
            | Primary -> "primary"
            | Info -> "info"
            | Link -> "link"
            | Success -> "success"
            | Warning -> "warning"
            | Danger -> "danger"
            | Default -> ""

        Attr.custom ("kind", kind)

module Fs =
    let inline fsOffCanvas nodes = Html.custom ("fs-off-canvas", nodes)

    let inline fsMessage nodes = Html.custom ("fs-message", nodes)
    let inline fsTabHost nodes = Html.custom ("fs-tab-host", nodes)
    let inline fsTabItem nodes = Html.custom ("fs-tab-item", nodes)
