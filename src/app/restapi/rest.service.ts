import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { Metadata } from '../model/metadata.model'

//endpoints
const endpoint = 'http://localhost:5000/api/intopalo';

const endpointSchemas = 'http://localhost:5000/api/intopalo/schemas';
/*const endpointDatabase = ;

const endpointSingleShema = ;
const endpointSingleDatabase = ;

const endpointTable = ;
const endpointCollection = ;

const endpointStructFiles = ;
const endpointUnstructFiles = ;*/

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',

  })
};

@Injectable({
  providedIn: 'root',
})

export class RestService {

metadata: Metadata[]=[];  
    
constructor(private http: HttpClient) { }


private extractData(res: Response) {
  let meta = res;
  return meta || { };
    //to do mapping for the model
}

private extractSchemasData(res: Response) {
  let schemas = res;
  return schemas || { };
    //to do mapping for the model
}
//get call
getMeta(): Observable<any> {
  return this.http.get(endpoint).pipe(
    map(this.extractData));
}
//get call for schemas
getSchemas(): Observable<any> {
  return this.http.get(endpointSchemas).pipe(
    map(this.extractSchemasData));
}
//get call for a single schema
getSingleSchema(id): Observable<any> {
  return this.http.get(endpointSchemas + '/' + id).pipe(
    map(this.extractData));
}

/*getBlock(id): Observable<any> {
  return this.http.get(endpoint).pipe(
    map(this.extractData));
}

//post call
addBlock (product): Observable<any> {
  console.log(product);
  return this.http.post<any>(endpoint, JSON.stringify(product), httpOptions).pipe(
    tap((product) => console.log(`added item w/ id=${some.id}`)),
    catchError(this.handleError<any>('addProduct'))
  );
}

//put call
updateBlock (id, product): Observable<any> {
  return this.http.put(endpoint + '/' + id, JSON.stringify(some), httpOptions).pipe(
    tap(_ => console.log(`updated item id=${id}`)),
    catchError(this.handleError<any>('updateProduct'))
  );
}

//delete call
deleteBlock (id): Observable<any> {
  return this.http.delete<any>(endpoint + '/' + id, httpOptions).pipe(
    tap(_ => console.log(`deleted item id=${id}`)),
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