[<AutoOpen>]
module Bindings

open Sutil
open Types

type FsAttrs() =
    static member inline slot name = Attr.custom ("is-open", name)

    static member inline isOpen(isOpen: bool) =
        Attr.custom ("is-open", (if isOpen then "true" else ""))

    static member inline closable(closable: bool) =
        Attr.custom ("closable", (if closable then "true" else ""))

    static member inline isSelected(isSelected: bool) =
        Attr.custom ("is-selected", (if isSelected then "true" else ""))

    static member inline isClosable(isClosable: bool) =
        Attr.custom ("is-closable", (if isClosable then "true" else ""))

    static member inline fsTabItemLabel(label: string) =
        Attr.custom ("label", label)

    static member inline fsTabItemTabName(label: string) =
        Attr.custom ("tab-name", label)

    static member inline fsMsgHeader(label: string) =
        Attr.custom ("header", label)

    static member inline fsOffCanvasNoOverlay(noOverlay: bool) =
        Attr.custom ("header", (if noOverlay then "true" else ""))

    static member inline fsOffCanvasPosition(position: OffcanvasPosition) =
        let pos =
            match position with
            | Left -> "left"
            | Right -> "right"

        Attr.custom ("position", pos)

    static member inline fsKind(value: Kind) =
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

type Fs() =
    static member inline fsOffCanvas nodes =
        Html.custom ("fs-off-canvas", nodes)

    static member inline fsMessage nodes = Html.custom ("fs-message", nodes)
    static member inline fsTabHost nodes = Html.custom ("fs-tab-host", nodes)
    static member inline fsTabItem nodes = Html.custom ("fs-tab-item", nodes)
