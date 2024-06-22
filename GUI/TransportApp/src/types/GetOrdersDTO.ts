interface GetOrdersDTO{
    id : number;
    nazwisko : string;
    status : string
    dataWyruszenia : Date;
    planowanaDataDostarczenia :Date;
    dataDostarczenia :Date|null;
    adres :string;
}

export default GetOrdersDTO