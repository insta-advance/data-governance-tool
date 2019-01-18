export interface Field{
    Type: string;
    StructureId: number;
    Fields: Field[];
    Name: string;
    Id: number;
}

export interface Table{
    SchemaId: number;
    Fields: Field[];
    Name: string;
    Id: number;
}

export interface Collection{
    DatabaseId: number;
    Fields: Field[];
    Name: string;
    Id: number;
}


export interface Schema{
    databaseId: number;    
    tables: Table[];
    name: string;
    id: number;
}

export interface PostgresDatabase{
    type: string;
    schemas: Schema[];
    datastoreId: number;
    name: string;
    id: number;
}

export interface MongoDatabase{
    Type: string;
    Collections: Collection[];
    DatastoreId: number;
    Name: string;
    Id: number;
}
 
export interface UnstructuredFile{
	DatastoreId: number;
    FilePath: string;
}

export interface StructuredFile{
	DatastoreId: number;
    	FilePath: string;
}   
export interface Datastore{
    Name: string;
    PostgresDatabases: PostgresDatabase[];
    MongoDatabases: MongoDatabase[];
    StructuredFiles: StructuredFile[];
    UnstructuredFiles: UnstructuredFile[];
    Id: string;
}  


export interface KeyRelationship{
	FromId: number;
	ToId: number;
	Type: string;
    	Id: number;
}

export interface Annotation{
	Description: string;
    Id: number;
}

export interface AnnotationBase{
	BaseId: string;
    AnnotationId: number;
}

