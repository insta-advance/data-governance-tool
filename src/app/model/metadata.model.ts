export interface Field{

}

export interface Table{
    tableName: string;
    schema: string;
    schemaId: number;
    key: Field[];
    fields: Field[];
    name: string;
    primaryKeyTo: number;
    foreignKeyTo: number;
    annotations: number;
    id: number;
}

export interface Collection{

}

export interface Schema{
    schemaName: string;
    database: string;
    databaseId: number;
    tables: Table[];
    name: string;
    primaryKeyTo: number;
    foreignKeyTo: number;
    annotations: string;
    id: number;
}

export interface MongoDatabase{

}


export interface RelationalDatabase{
    schemas: Schema[];
}

export interface NonrelationalDatabase{
    mongos: MongoDatabase[];
}
 
export interface UnstructuredFile{

}

export interface StructuredFile{

}   
export interface Datastore{
    name: string;
    databases: string;
    structuredFiles: string;
    unstructuredFiles: string;
    id: string;
}  

export interface Datastores{
    datastores: Datastore[];
}
