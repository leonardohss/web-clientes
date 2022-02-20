import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteDetalheComponent } from './components/cliente-detalhe/cliente-detalhe.component';
import { ClienteEditarComponent } from './components/cliente-editar/cliente-editar.component';
import { ClienteInserirComponent } from './components/cliente-inserir/cliente-inserir.component';
import { ClienteListaComponent } from './components/cliente-lista/cliente-lista.component';

const routes: Routes = [{
  path: 'clientes',
  component: ClienteListaComponent,
  data: { title: 'Lista de Clientes' }
},
{
  path: 'cliente-detalhe/:id',
  component: ClienteDetalheComponent,
  data: { title: 'Detalhe do Cliente' }
},
{
  path: 'cliente-inserir',
  component: ClienteInserirComponent,
  data: { title: 'Adicionar Novo Cliente' }
},
{
  path: 'cliente-editar/:id',
  component: ClienteEditarComponent,
  data: { title: 'Editar o Cliente' }
},
{ path: '',
  redirectTo: '/clientes',
  pathMatch: 'full'
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
