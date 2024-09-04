import { Foto } from "./Foto"

export interface Member {
  id: number
  username: string
  age: number
  fotoURL: string
  bekanntAls: string
  erstelltAm: Date
  zuletztAktiv: Date
  geschlecht: string
  vorstellung: string
  interessen: string
  suchtNach: string
  stadt: string
  land: string
  fotos: Foto[]
}
