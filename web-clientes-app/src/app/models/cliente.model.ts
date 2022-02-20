import { ProfissaoModel } from "./profissao.model";

export interface ClienteModel {
    id: number,
    nome: string,
    sobrenome: string,
    cpf: string,
    dataDeNascimento: Date,
    idade: number,
    idProfissao?: number,
    profissao?: ProfissaoModel
}

export interface ClienteModelDTO {
    id: number,
    nome: string,
    sobrenome: string,
    cpf: string,
    dataDeNascimento: Date,
    idProfissao?: number,
}