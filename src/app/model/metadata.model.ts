export interface Field{
    id: number;
    name: string;
    type: string;
    isPrimary: number;
    isForeignKeyTo: number;
}

export interface Table{
    id: number;
    name: string;
    fields: Field[];
}

export interface Collection{
    id: number;
    name: string;
    type: string;
    nodeLink: string;
}

export interface Schema{
    id: number;
    name: string;
    tables: Table[];
}

export interface Database{
    id: number;
    name: string;
    collections: Collection[];
}

export interface UnstructuredFiles{
    id: number;
    name: string;
    type: string;
    path: string;
}

export interface StructuredFiles{
    id: number;
    name: string;
    type: string;
    path: string;
}

export interface Datastore{
    id:string;
    name:string;
    schemas: Schema[];
    databases: Database[];
    unstructFiles: UnstructuredFiles[];
    structFiles: StructuredFiles[];
}
