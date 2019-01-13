import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import

const endpointDatastores = 'http://localhost:5000/api/datastores';
const endpointDatabases = 'http://localhost:5000/api/databases';
const endpointSchemas = 'http://localhost:5000/api/schemas';
const endpointTables = 'http://localhost:5000/api/tables';
const endpointFields = 'http://localhost:5000/api/fields';

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
}
    
/*------------------------DATASTORE------------------------*/

getDatastores(): Observable<any> {
  return this.http.get(endpointDatastores).pipe(
    map(this.extractData));
}

getDatastore(id): Observable<any> {
  return this.http.get(endpointDatastores + '/' + id).pipe(
    map(this.extractData));
}
/*------------------------DATABASES------------------------*/
getDatabases(): Observable<any> {
  return this.http.get(endpointTestDatabases).pipe(
    map(this.extractData));
}

getDatabase(id): Observable<any> {
  return this.http.delete(endpointDatabases + '/' + id);
}
/*------------------------SCHEMAS------------------------*/
getSchemas(): Observable<any> {
  return this.http.get(endpointSchemas).pipe(
    map(this.extractSchemasData));
}
    
getSchema(id): Observable<any> {
  return this.http.get(endpointSchemas + '/' + id).pipe(
    map(this.extractSingleSchemaData));
}

/*------------------------TABLES------------------------*/
getTables(): Observable<any> {
  return this.http.get(endpointTables).pipe(
    map(this.extractSchemasData));
}
    
getTable(id): Observable<any> {
  return this.http.get(endpointTable + '/' + id).pipe(
    map(this.extractSingleSchemaData));
}
/*---------------------FIELDS--------------------*/
    
    
private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
    console.error(error);
    console.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}
}
