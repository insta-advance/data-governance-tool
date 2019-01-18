import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { AnnotationBase, Annotation, KeyRelationship, Datastore, MongoDatabase, PostgresDatabase, Collection, Schema, Table, Field, UnstructuredFile, StructuredFile} from '../model/metadata.model'

const endpointDatastores = 'http://localhost:5000/api/datastores';
const endpointPostgresDatabases = 'http://localhost:5000/api/postgresdatabases';
const endpointMongoDatabases = 'http://localhost:5000/api/mongodatabases';
const endpointSchemas = 'http://localhost:5000/api/schemas';
const endpointTables = 'http://localhost:5000/api/tables';
const endpointFields = 'http://localhost:5000/api/fields';
const endpointStructFiles = 'http://localhost:5000/api/structuredfiles';
const endpointUnstructFiles = 'http://localhost:5000/api/unstructuredfiles';
const endpointKeyRelationships = 'http://localhost:5000/api/keyrelationships';
const endpointCollections = 'http://localhost:5000/api/collections';
const endpointAnnotations = 'http://localhost:5000/api/annotations';
const endpointAnnotationBases = 'http://localhost:5000/api/annotationbases';

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
    addDatastore (datastore): Observable<Datastore> {
	   return this.http.post<Datastore>(endpointDatastores, datastore, httpOptions);
    }
    /*------------------------POSTGRES DATABASES------------------------*/
    getPostgresDatabases(): Observable<any> {
      return this.http.get(endpointPostgresDatabases).pipe(
        map(this.extractData));
    }

    getPostgresDatabase(id): Observable<any> {
      return this.http.get(endpointPostgresDatabases + '/' + id).pipe(
        map(this.extractData));
    }
    
    updatePostgresDatabase (id, postgresDatabase): Observable<any> {
      return this.http.put(endpointPostgresDatabases + '/' + id, httpOptions, postgresDatabase);
    }

    deletePostgresDatabase (id): Observable<PostgresDatabase> {
      return this.http.delete<PostgresDatabase>(endpointPostgresDatabases + '/' + id, httpOptions);
    }
    addPostgresDatabase (postgresDatabase): Observable<PostgresDatabase> {
	   return this.http.post<PostgresDatabase>(endpointPostgresDatabases, postgresDatabase, httpOptions);
    }
    /*------------------------MONGO DATABASES------------------------*/
    getMongoDatabases(): Observable<any> {
      return this.http.get(endpointMongoDatabases).pipe(
        map(this.extractData));
    }

    getMongoDatabase(id): Observable<any> {
      return this.http.get(endpointMongoDatabases + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateMongoDatabase (id, mongoDatabase): Observable<any> {
      return this.http.put(endpointMongoDatabases + '/' + id, httpOptions, mongoDatabase);
    }

    deleteMongoDatabase (id): Observable<MongoDatabase> {
      return this.http.delete<MongoDatabase>(endpointMongoDatabases + '/' + id, httpOptions);
    }
    addMongoDatabase (mongoDatabase): Observable<MongoDatabase> {
	   return this.http.post<MongoDatabase>(endpointMongoDatabases, mongoDatabase, httpOptions);
    }
    /*------------------------POSTGRES SCHEMAS------------------------*/
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
    /*------------------------MONGO COLLECTIONS------------------------*/
    getCollections(): Observable<any> {
      return this.http.get(endpointCollections).pipe(
        map(this.extractData));
    }

    getCollection(id): Observable<any> {
      return this.http.get(endpointCollections + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateCollection (id, collection): Observable<any> {
      return this.http.put(endpointCollections + '/' + id, httpOptions, collection);
    }

    deleteCollection (id): Observable<Collection> {
      return this.http.delete<Collection>(endpointCollections + '/' + id, httpOptions);
    }  
  
    addCollection (collection): Observable<Collection> {
	   return this.http.post<Collection>(endpointCollections, collection, httpOptions);
    }
    /*------------------------POSTGRES TABLES------------------------*/
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
    /*---------------------POSTGRES FIELDS--------------------*/
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

    addField (field): Observable<Field> {
	   return this.http.post<Field>(endpointFields, field, httpOptions);
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
    /*---------------------KEY RELATIONSHIPS--------------------*/
    getKeyRelationships(): Observable<any> {
      return this.http.get(endpointKeyRelationships).pipe(
        map(this.extractData));
    }

    getKeyRelationship(id): Observable<any> {
      return this.http.get(endpointKeyRelationships + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateKeyRelationship (id, keyRelationship): Observable<any> {
      return this.http.put(endpointKeyRelationships + '/' + id, httpOptions, keyRelationship);
    }

    deleteKeyRelationship (id): Observable<KeyRelationship> {
      return this.http.delete<KeyRelationship>(endpointKeyRelationships + '/' + id, httpOptions);
    } 
    addKeyRelationship (keyRelationship): Observable<KeyRelationship> {
	   return this.http.post<KeyRelationship>(endpointKeyRelationships, keyRelationship, httpOptions);
    }
    /*---------------------ANNOTATIONS--------------------*/
    getAnnotations(): Observable<any> {
      return this.http.get(endpointKeyRelationships).pipe(
        map(this.extractData));
    }

    getAnnotation(id): Observable<any> {
      return this.http.get(endpointAnnotations + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateAnnotation (id, annotation): Observable<any> {
      return this.http.put(endpointAnnotations + '/' + id, httpOptions, annotation);
    }

    deleteAnnotation (id): Observable<Annotation> {
      return this.http.delete<Annotation>(endpointAnnotations + '/' + id, httpOptions);
    } 
    
    addAnnotation (annotation): Observable<Annotation> {
	   return this.http.post<Annotation>(endpointAnnotations, annotation, httpOptions);
    }
    /*---------------------ANNOTATION BASES--------------------*/
    getAnnotationBases(): Observable<any> {
      return this.http.get(endpointAnnotationBases).pipe(
        map(this.extractData));
    }

    getAnnotationBase(id): Observable<any> {
      return this.http.get(endpointAnnotationBases + '/' + id).pipe(
        map(this.extractData));
    }
    
    updateAnnotationBase (id, annotationbase): Observable<any> {
      return this.http.put(endpointAnnotationBases + '/' + id, httpOptions, annotationbase);
    }

    deleteAnnotationBase (id): Observable<KeyRelationship> {
      return this.http.delete<KeyRelationship>(endpointAnnotationBases + '/' + id, httpOptions);
    }
    
    addAnnotationBase (annotationbase): Observable<KeyRelationship> {
	   return this.http.post<KeyRelationship>(endpointAnnotationBases, annotationbase, httpOptions);
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
