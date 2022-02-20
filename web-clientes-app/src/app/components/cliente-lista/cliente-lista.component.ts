import { Component, OnInit } from '@angular/core';
import { ClienteModel } from 'src/app/models/cliente.model';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente-lista',
  templateUrl: './cliente-lista.component.html',
  styleUrls: ['./cliente-lista.component.css']
})
export class ClienteListaComponent implements OnInit {

  displayedColumns: string[] = [ 'id', 'nome', 'cpf', 'dataDeNascimento', 'acao'];
  dataSource: ClienteModel[] = [];
  isLoading: boolean = true;

  constructor(private _clienteService: ClienteService) { }

  ngOnInit(): void {
    this._clienteService.listar().subscribe(res => {
      this.dataSource = res;
      this.isLoading = false;
    }, err => {
      this.isLoading = false;
      alert(err);
    });
  }
}
