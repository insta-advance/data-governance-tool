import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { Datastore } from '../model/metadata.model'

//endpoints
const endpoint = 'http://localhost:4200/assets/get.json';
/*const endpointSchema = ;
const endpointDatabase = ;
const endpointTable = ;
const endpointCollection = ;
const endpointStructFiles = ;
const endpointUnstructFiles = ;*/

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root',
})

export class RestService {

metadata: Datastore[]=[];  
    
constructor(private http: HttpClient) { }


private extractData(res: Response) {
  let body = res;
  return body || { };
    //to do mapping for the model
}

//get call
getBlocks(): Observable<any> {
  return this.http.get(endpoint).pipe(
    map(this.extractData));
}

//get call for a singular id
/*getBlock(id): Observable<any> {
  return this.http.get(endpoint).pipe(
    map(this.extractData));
}

//post call
addBlock (product): Observable<any> {
  console.log(product);
  return this.http.post<any>(endpoint, JSON.stringify(product), httpOptions).pipe(
    tap((product) => console.log(`added block w/ id=${product.id}`)),
    catchError(this.handleError<any>('addProduct'))
  );
}

//put call
updateBlock (id, product): Observable<any> {
  return this.http.put(endpoint + '/' + id, JSON.stringify(product), httpOptions).pipe(
    tap(_ => console.log(`updated block id=${id}`)),
    catchError(this.handleError<any>('updateProduct'))
  );
}

//delete call
deleteBlock (id): Observable<any> {
  return this.http.delete<any>(endpoint + '/' + id, httpOptions).pipe(
    tap(_ => console.log(`deleted block id=${id}`)),
    catchError(this.handleError<any>('deleteProduct'))
  );
}*/

private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
    console.error(error);
    console.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}
}