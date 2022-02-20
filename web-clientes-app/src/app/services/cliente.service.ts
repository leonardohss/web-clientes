import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ClienteModel, ClienteModelDTO } from '../models/cliente.model';
import { ErrorHandler } from '../app.error-handler';

@Injectable({
  providedIn: 'root'
})

export class ClienteService {

  url_cliente: string = `${environment.url_api}/Cliente`;
  
  constructor(private http: HttpClient) { }

  listar(): Observable<ClienteModel[]>{
    return this.http.get<ClienteModel[]>(this.url_cliente).pipe(
      map(response => response), 
      catchError(ErrorHandler.handleError)
    );
  }

  selecionarPorId(id: number): Observable<ClienteModel> {
    return this.http.get<ClienteModel>(`${this.url_cliente}/${id}`).pipe(
      map(response => response),
      catchError(ErrorHandler.handleError)
    );
  }

  adicionar (cliente: ClienteModelDTO): Observable<number> {
    return this.http.post<number>(this.url_cliente, cliente).pipe(
      map(response => response),
      catchError(ErrorHandler.handleError)
    );
  }

  atualizar(cliente: ClienteModelDTO): Observable<number> {
    return this.http.put<number>(this.url_cliente, cliente).pipe(
      map(response => response),
      catchError(ErrorHandler.handleError)
    );
  }

  deletar(id: number): Observable<any> {
    return this.http.delete(`${this.url_cliente}/${id}`).pipe(
      map(response => response),
      catchError(ErrorHandler.handleError)
    );
  }
}
