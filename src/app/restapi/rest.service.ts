import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { Datastores, Datastore, Database, Schema, Table, Field, UnstructuredFile, StructuredFile} from '../model/metadata.model'

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
    
    updateDatastore (id, datastore): Observable<any> {
      return this.http.put(endpointDatastores + '/' + id, httpOptions, datastore);
    }

    deleteDatastore (id): Observable<Datastore> {
      return this.http.delete<Datastore>(endpointDatastores + '/' + id, httpOptions);
    }
    /*------------------------DATABASES------------------------*/
    getDatabases(): Observable<any> {
      return this.http.get(endpointDatabases).pipe(
        map(this.extractData));
    }

    getDatabase(id): Observable<any> {
      return this.http.delete(endpointDatabases + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateDatabase (id, database): Observable<any> {
      return this.http.put(endpointDatabases + '/' + id, httpOptions, database);
    }

    deleteDatabase (id): Observable<Database> {
      return this.http.delete<Database>(endpointDatabases + '/' + id, httpOptions);
    }
    /*------------------------SCHEMAS------------------------*/
    getSchemas(): Observable<any> {
      return this.http.get(endpointSchemas).pipe(
        map(this.extractData));
    }

    getSchema(id): Observable<any> {
      return this.http.get(endpointSchemas + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateSchema (id, schema): Observable<any> {
      return this.http.put(endpointSchemas + '/' + id, httpOptions, schema);
    }

    deleteSchema (id): Observable<Schema> {
      return this.http.delete<Schema>(endpointSchemas + '/' + id, httpOptions);
    }
    /*------------------------TABLES------------------------*/
    getTables(): Observable<any> {
      return this.http.get(endpointTables).pipe(
        map(this.extractData));
    }

    getTable(id): Observable<any> {
      return this.http.get(endpointTables + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateTable (id, table): Observable<any> {
      return this.http.put(endpointTables + '/' + id, httpOptions, table);
    }

    deleteTable (id): Observable<Table> {
      return this.http.delete<Table>(endpointTables + '/' + id, httpOptions);
    }  
  
    addTable (table): Observable<Table> {
	return this.http.post<Table>(endpointTables, table, httpOptions);
    }
    /*---------------------FIELDS--------------------*/
    getFields(): Observable<any> {
      return this.http.get(endpointFields).pipe(
        map(this.extractData));
    }

    getField(id): Observable<any> {
      return this.http.get(endpointFields + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateField (id, field): Observable<any> {
      return this.http.put(endpointFields + '/' + id, httpOptions, field);
    }

    deleteField (id): Observable<Field> {
      return this.http.delete<Field>(endpointFields + '/' + id, httpOptions);
    } 
    /*---------------------ERROR HANDLING--------------------*/
    private handleError<T> (operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {
        console.error(error);
        console.log(`${operation} failed: ${error.message}`);

        // Let the app keep running by returning an empty result.
        return of(result as T);
      };
    }
}
