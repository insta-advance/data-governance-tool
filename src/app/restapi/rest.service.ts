import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { Schema } from '../model/metadata.model'


const endpointSchemas = 'http://localhost:4200/assets/anothertest/schemas.json';
const endpointSchema = 'http://localhost:4200/assets/anothertest/schema2.json';
const endpointDatastore = 'http://localhost:4200/assets/anothertest/datastores.json';

const endpointTestSchemas = 'http://localhost:5000/api/schemas';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',

  })
};

@Injectable({
  providedIn: 'root',
})

export class RestService {
    
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

private extractSingleSchemaData(res: Response) {
  let schema = res;
  return schema || { };
    //to do mapping for the model
}
    
/*------------------------META------------------------*/
getDatastore(): Observable<any> {
  return this.http.get(endpointDatastore).pipe(
    map(this.extractData));
}
/*------------------------SCHEMAS------------------------*/
getSchemas(): Observable<any> {
  return this.http.get(endpointTestSchemas).pipe(
    map(this.extractSchemasData));
}
    
getSingleSchema(id): Observable<any> {
  return this.http.get(endpointTestSchemas + '/' + id).pipe(
    map(this.extractSingleSchemaData));
}
    
deleteSchema(id): Observable<any> {
    return this.http.delete(endpointTestSchemas + '/' + id );
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