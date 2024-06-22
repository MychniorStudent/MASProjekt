import { useEffect, useState } from "react";
import GetProductsDTO from "../types/GetProductsDTO";

function Products() {
  const [data, setData] = useState<Array<GetProductsDTO>>([]);

  useEffect(() => {
    fetch("https://localhost:7155/api/Product/GetProducts")
      .then((response) => response.json())
      .then((json) => {
        let jsonObject = json as Array<GetProductsDTO>;
        console.log(jsonObject);
        setData(jsonObject);
      })
      .catch((error) => console.log(error));
  }, []);

  return (
    <>
      <ul className="list-group list-group-horizontal ml-2 ">
        <li className="list-group-item col-sm-1">ID</li>
        <li className="list-group-item col-sm-2">Nazwa</li>
        <li className="list-group-item col-sm-2 ">Kategoria</li>
        <li className="list-group-item col-sm-2">Czy niebezpieczny</li>
        <li className="list-group-item col-sm-2 ">Ilosc</li>
      </ul>
      {data.map((item, index) => (
        <ul className="list-group list-group-horizontal ml-2">
          <li className="list-group-item col-sm-1">{item.id}</li>
          <li className="list-group-item col-sm-2">{item.nazwa}</li>
          <li className="list-group-item col-sm-2 ">{item.kategoria}</li>
          <li className="list-group-item col-sm-2">
            {item.czyNiebezpieczny ? "tak" : "nie"}
          </li>
          <li className="list-group-item col-sm-2 ">{item.ilosc}</li>
        </ul>
      ))}
    </>
  );
}
export default Products;
