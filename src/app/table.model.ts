import { Field } from "./field.model";

export class Table{
    constructor(
        public Id: number,
        public Name: string,
        public Fields: Field [] = [],
        
        ) { }
}