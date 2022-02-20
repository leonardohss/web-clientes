import { throwError} from "rxjs";

export class ErrorHandler{
  static handleError(error: Response | any){
    let errorMessage: string;

    errorMessage = error.toString();
    if(error.error)
      errorMessage = error.error.toString();

    return throwError(() => errorMessage);
  }
}