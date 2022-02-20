import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ErrorHandler } from '../app.error-handler';
import { ProfissaoModel } from '../models/profissao.model';

@Injectable({
  providedIn: 'root'
})
export class ProfissaoService {

  url_profissao: string = `${environment.url_api}/Profissao`;
  
  constructor(private http: HttpClient) { }

  listar(): Observable<ProfissaoModel[]>{
    return this.http.get<ProfissaoModel[]>(this.url_profissao).pipe(
      map(response => response), 
      catchError(ErrorHandler.handleError)
    );
  }
}
