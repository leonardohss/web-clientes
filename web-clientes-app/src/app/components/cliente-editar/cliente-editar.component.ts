import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteModelDTO } from 'src/app/models/cliente.model';
import { ProfissaoModel } from 'src/app/models/profissao.model';
import { ClienteService } from 'src/app/services/cliente.service';
import { ProfissaoService } from 'src/app/services/profissao.service';

@Component({
  selector: 'app-cliente-editar',
  templateUrl: './cliente-editar.component.html',
  styleUrls: ['./cliente-editar.component.css']
})
export class ClienteEditarComponent implements OnInit {

  listaProfissoes: ProfissaoModel[] = []
  clienteForm: FormGroup = this.formBuilder.group({
    'nome' : [null, Validators.required],
    'sobrenome' : [null, Validators.required],
    'cpf' : [null, Validators.required],
    'dataDeNascimento' : [null, Validators.required],
    'profissao' : [null],
    'id': [null],
  });
  cpf:string = ''
  isLoading:boolean = true;

  constructor(private router: Router, 
    private _clienteService: ClienteService, 
    private _profissaoService: ProfissaoService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this._profissaoService.listar().subscribe(res => {
      this.listaProfissoes = res;
      this.isLoading = false;
      this.obterCliente();
    }, err => {
      this.isLoading = false;
      alert(err);
    });
  }

  obterCliente(){
    this.isLoading = true;
    
    this._clienteService.selecionarPorId(this.route.snapshot.params['id']).subscribe(res => {
      this.clienteForm.setValue({
        nome: res.nome,
        sobrenome: res.sobrenome,
        cpf: res.cpf,
        dataDeNascimento: res.dataDeNascimento,
        profissao: res.idProfissao,
        id: res.id
      });

      this.isLoading = false;
    }, err => {
      this.isLoading = false;
      alert(err);
    });
  }

  editarCliente() {
    this.isLoading = true;

    console.log(parseInt(this.clienteForm.value.profissao, 10))

    let cliente: ClienteModelDTO ={
      id: this.clienteForm.value.id,
      nome: this.clienteForm.value.nome,
      sobrenome: this.clienteForm.value.sobrenome,
      cpf: this.clienteForm.value.cpf,
      dataDeNascimento: new Date(this.clienteForm.value.dataDeNascimento),
      idProfissao: !isNaN(parseInt(this.clienteForm.value.profissao)) ? this.clienteForm.value.profissao : null
    }
    this._clienteService.atualizar(cliente)
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
