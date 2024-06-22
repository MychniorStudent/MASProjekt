interface AddOrderDTO{
dataWyruszenia: Date;
planowanaDataDostraczenia: Date;
adresDostawy : string;
idTransportu : number;
idProduktow : Array<number>
}

export default AddOrderDTO