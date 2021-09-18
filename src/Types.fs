module Types

open Fable.Core

[<RequireQualifiedAccess>]
type Page =
    | Home
    | Notes

type OffcanvasPosition =
    | Left
    | Right

type Kind =
    | Primary
    | Info
    | Link
    | Success
    | Warning
    | Danger
    | Default

type MenuEntry =
    { label: string
      id: string
      kind: Kind }
