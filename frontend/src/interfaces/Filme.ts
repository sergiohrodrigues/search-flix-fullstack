import IAtor from "./Ator"

export default interface IFilme {
    id: number
    titulo: string
    descricao: string
    categoria: string
    urlTrailler: string
    atorId: number
    ator: IAtor
}