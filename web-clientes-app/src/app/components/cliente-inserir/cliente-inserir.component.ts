import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClienteModelDTO } from 'src/app/models/cliente.model';
import { ProfissaoModel } from 'src/app/models/profissao.model';
import { ClienteService } from 'src/app/services/cliente.service';
import { ProfissaoService } from 'src/app/services/profissao.service';

@Component({
  selector: 'app-cliente-inserir',
  templateUrl: './cliente-inserir.component.html',
  styleUrls: ['./cliente-inserir.component.css']
})
export class ClienteInserirComponent implements OnInit {

  listaProfissoes: ProfissaoModel[] = []
  clienteForm: FormGroup = this.formBuilder.group({
    'nome' : [null, Validators.required],
    'sobrenome' : [null, Validators.required],
    'cpf' : [null, Validators.required],
    'dataDeNascimento' : [null, Validators.required],
    'profissao' : [null]
  });

  cpf:string = ''
  isLoading = false;

  constructor(private router: Router, 
    private _clienteService: ClienteService, 
    private _profissaoService: ProfissaoService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this._profissaoService.listar().subscribe(res => {
      this.listaProfissoes = res;
      this.isLoading = false;
    }, err => {
      this.isLoading = false;
      alert(err);
    });

  }

  adicionarCliente() {
    this.isLoading = true;

    let cliente: ClienteModelDTO ={
      id: 0,
      nome: this.clienteForm.value.nome,
      sobrenome: this.clienteForm.value.sobrenome,
      cpf: this.clienteForm.value.cpf,
      dataDeNascimento: new Date(this.clienteForm.value.dataDeNascimento),
      idProfissao: !isNaN(parseInt(this.clienteForm.value.profissao))? this.clienteForm.value.profissao : null
    }
    this._clienteService.adicionar(cliente)
      .subscribe(res => {
          const id = res;
          this.isLoading = false;
          this.router.navigate(['/cliente-detalhe', id]);
        }, (err) => {
          this.isLoading = false;
          alert(err);
        });
  }

  obterDescricaoProfissaoPorId(idProfissao: number){
    let descricao = this.listaProfissoes.find(x => x.id === idProfissao)?.descricao;

    if(descricao)
      return descricao;

    return '';
  }
}

