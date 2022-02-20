import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente-detalhe',
  templateUrl: './cliente-detalhe.component.html',
  styleUrls: ['./cliente-detalhe.component.css']
})
export class ClienteDetalheComponent implements OnInit {

  cliente: any = null;
  isLoading:boolean = true;
  constructor(private router: Router, private route: ActivatedRoute, private _clienteService: ClienteService) { }

  ngOnInit() {
    this.selecionarClientePorId(this.route.snapshot.params['id']);
  }

  selecionarClientePorId(id: number) {
    this._clienteService.selecionarPorId(id)
      .subscribe(data => {
        this.cliente = data;
        this.isLoading = false;
      }, err => {
        this.isLoading = false;
        alert(err);
      });
  }

  deletarCliente(id: number) {
    this.isLoading = true;
    this._clienteService.deletar(id)
      .subscribe(res => {
          this.isLoading = false;
          this.router.navigate(['/clientes']);
        }, (err) => {
          this.isLoading = false;
          alert(err);
        }
      );
  }
}
