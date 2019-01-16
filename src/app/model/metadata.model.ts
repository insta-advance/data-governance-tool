export interface Field{
    type: string;
    structureId: number;
    fields: Field[];
    name: string;
    id: number;
}

export interface Table{
    SchemaId: number;
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

export interface Database{
    type: string;
    schemas: Schema[];
    datastoreId: number;
    name: string;
    id: number;
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
    name: string;
    databases: Database[];
    structuredFiles: Database[];
    unstructuredFiles: Database[];
    id: string;
}  

export interface Datastores{
    datastores: Datastore[];
}
