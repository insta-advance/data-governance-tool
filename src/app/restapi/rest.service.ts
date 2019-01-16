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
const endpointStructFiles = 'http://localhost:5000/api/structuredfiles';
const endpointUnstructFiles = 'http://localhost:5000/api/unstructuredfiles';
const endpointAnnotations = 'http://localhost:5000/api/annotations';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
	"Access-Control-Allow-Origin": "*",
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
      return this.http.get(endpointDatabases + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateDatabase (id, database): Observable<any> {
      return this.http.put(endpointDatabases + '/' + id, httpOptions, database);
    }

    deleteDatabase (id): Observable<Database> {
      return this.http.delete<Database>(endpointDatabases + '/' + id, httpOptions);
    }
    addDatabase (database): Observable<Database> {
	return this.http.post<Database>(endpointDatabases, database, httpOptions);
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
    addSchema (schema): Observable<Schema> {
	return this.http.post<Schema>(endpointSchemas, schema, httpOptions);
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
    /*---------------------STRUCTURED FILES--------------------*/
    getStructFiles(): Observable<any> {
      return this.http.get(endpointStructFiles).pipe(
        map(this.extractData));
    }

    getStructFile(id): Observable<any> {
      return this.http.get(endpointStructFiles + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateStructFile (id, structFile): Observable<any> {
      return this.http.put(endpointStructFiles + '/' + id, httpOptions, structFile);
    }

    deleteStructFile (id): Observable<StructuredFile> {
      return this.http.delete<StructuredFile>(endpointStructFiles + '/' + id, httpOptions);
    } 
    addStructFile (structFile): Observable<StructuredFile> {
	return this.http.post<StructuredFile>(endpointStructFiles, structFile, httpOptions);
    }
    /*---------------------UNSTRUCTURED FILES--------------------*/
    getUnstructFiles(): Observable<any> {
      return this.http.get(endpointUnstructFiles).pipe(
        map(this.extractData));
    }

    getUnstructFile(id): Observable<any> {
      return this.http.get(endpointUnstructFiles + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateUnstructFile (id, unstructFile): Observable<any> {
      return this.http.put(endpointUnstructFiles + '/' + id, httpOptions, unstructFile);
    }

    deleteUnstructFile (id): Observable<UnstructuredFile> {
      return this.http.delete<UnstructuredFile>(endpointUnstructFiles + '/' + id, httpOptions);
    } 
    addUnstructFile (unstructFile): Observable<UnstructuredFile> {
	return this.http.post<UnstructuredFile>(endpointUnstructFiles, unstructFile, httpOptions);
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
