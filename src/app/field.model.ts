export class Field{
    constructor(
        public Id: number,
        public Name: string,
        public Type: string,
        public KeyRelationshipFrom: [
            {BaseFromId: number},
            {BaseToId: number},
            {Type: string} 
            ],
        ) { }
}