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
    
/*------------------------META------------------------*/
getMeta(): Observable<any> {
  return this.http.get(endpoint).pipe(
    map(this.extractData));
}
/*------------------------SCHEMAS------------------------*/
getSchemas(): Observable<any> {
  return this.http.get(endpointSchemas).pipe(
    map(this.extractSchemasData));
}

getSingleSchema(id): Observable<any> {
  return this.http.get(endpointSchemas + '/' + id).pipe(
    map(this.extractData));
}

addSchema (data): Observable<any> {
    return this.http.post(endpointSchemas, data);
}

deleteSchema (id): Observable<any> {
    return this.http.delete(endpointSchemas + '/' + id);
}
    
updateSchema(data) {
    return this.http.put(endpointSchemas + '/' + data.id, data);
  }
/*------------------------COLLECTIONS------------------------*/

/*---------------------UNSTRUCTURED FILES--------------------*/
    
/*----------------------STRUCTURED FILES---------------------*/
    
    
private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
    console.error(error);
    console.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}
}